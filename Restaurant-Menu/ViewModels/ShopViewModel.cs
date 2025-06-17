using Microsoft.EntityFrameworkCore;
using Restaurant_Menu.Data;
using Restaurant_Menu.Models;
using Restaurant_Menu.Service;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Restaurant_Menu.ViewModels
{
    public class ShopViewModel
    {
        public ObservableCollection<ProductGroup> GroupedProducts { get; set; }
        public ICommand BuyCommand { get; }
        public ShopViewModel()
        {
            LoadProducts();
            BuyCommand = new Restaurant_Menu.Helpers.RelayCommand<Product>(BuyProduct);
        }

        private void LoadProducts()
        {
            using var context = new RestaurantDbContext();

            var allProducts = context.Products
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .Include(p => p.ProductAllergens)
                    .ThenInclude(pa => pa.Allergen)
                .ToList();

            var grouped = allProducts
                .Where(p => p.Category != null)
                .GroupBy(p => p.Category.Name)
                .Select(g => new ProductGroup
                {
                    Category = g.Key,
                    Products = new ObservableCollection<Product>(g)
                });

            GroupedProducts = new ObservableCollection<ProductGroup>(grouped);
        }
        private void BuyProduct(Product product)
        {
            if (product != null)
            {
                CartService.AddToCart(product);
                MessageBox.Show($"'{product.Name}' added to cart!");
            }
        }
    }
}
