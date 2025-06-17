using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurant_Menu.Data;

namespace Restaurant_Menu.ViewModels
{
    public class MenusViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ProductDisplay> Products { get; set; } = new();
        public ObservableCollection<MenuDisplay> Menus { get; set; } = new();


        public MenusViewModel()
        {
            FilterProducts("");
        }

        public void FilterProducts(string keyword)
        {
            Menus.Clear();

            using var context = new RestaurantDbContext();

            var menus = context.Menus
                .Include(m => m.MenuProducts)
                    .ThenInclude(mp => mp.Product)
                        .ThenInclude(p => p.ProductImages)
                .Include(m => m.MenuProducts)
                    .ThenInclude(mp => mp.Product)
                        .ThenInclude(p => p.ProductAllergens)
                            .ThenInclude(pa => pa.Allergen)
                .ToList();

            foreach (var menu in menus)
            {
                var menuDisplay = new MenuDisplay
                {
                    Name = menu.Name
                };

                foreach (var mp in menu.MenuProducts)
                {
                    var product = mp.Product;

                    // Apply the filter here
                    if (string.IsNullOrEmpty(keyword) || product.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                    {
                        menuDisplay.Products.Add(new ProductDisplay
                        {
                            Name = product.Name,
                            Description = product.Description,
                            PortionQtyGrams = product.PortionQtyGrams,
                            Price = product.Price,
                            FirstImagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", product.ProductImages.FirstOrDefault()?.ImagePath ?? ""),
                            AllergenSummary = string.Join(", ", product.ProductAllergens.Select(pa => pa.Allergen.Name))
                        });
                    }
                }

                if (menuDisplay.Products.Any())
                {
                    Menus.Add(menuDisplay);
                }
            }
        }



        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

