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
   public class DessertsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ProductDisplay> Products { get; set; } = new();

        public DessertsViewModel()
        {
            FilterProducts("");
        }

        public void FilterProducts(string keyword)
        {
            using var context = new RestaurantDbContext();

            var filtered = context.Products
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .Include(p => p.ProductAllergens)
                    .ThenInclude(pa => pa.Allergen)
                .Where(p => p.Category.Name == "Desserts" &&
                            (string.IsNullOrEmpty(keyword) || p.Name.ToLower().Contains(keyword.ToLower())))
                .ToList();

            Products.Clear();

            foreach (var product in filtered)
            {
                Products.Add(new ProductDisplay
                {
                    Name = product.Name,
                    Description = product.Description,
                    PortionQtyGrams = product.PortionQtyGrams,
                    Price = product.Price,
                    FirstImagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", product.ProductImages.FirstOrDefault()?.ImagePath),
                    AllergenSummary = string.Join(", ", product.ProductAllergens.Select(pa => pa.Allergen.Name))
                });
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public class ProductDisplay
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public int PortionQtyGrams { get; set; }
            public decimal Price { get; set; }
            public string? FirstImagePath { get; set; }
            public string AllergenSummary { get; set; }
        }
    }
}
