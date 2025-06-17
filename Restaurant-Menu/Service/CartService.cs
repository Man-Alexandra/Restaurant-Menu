using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant_Menu.Models;
using System.Collections.ObjectModel;

namespace Restaurant_Menu.Service
{
    public static class CartService
    {
        public static ObservableCollection<CartItem> CartItems { get; } = new();

        public static void AddToCart(Product product)
        {
            var existing = CartItems.FirstOrDefault(c => c.Product.ProductId == product.ProductId);
            if (existing != null)
                existing.Quantity++;
            else
                CartItems.Add(new CartItem { Product = product, Quantity = 1 });
        }

        public static void RemoveFromCart(Product product)
        {
            var item = CartItems.FirstOrDefault(c => c.Product.ProductId == product.ProductId);
            if (item != null)
                CartItems.Remove(item);
        }

        public static void IncreaseQuantity(Product product)
        {
            var item = CartItems.FirstOrDefault(c => c.Product.ProductId == product.ProductId);
            if (item != null)
                item.Quantity++;
        }

        public static void DecreaseQuantity(Product product)
        {
            var item = CartItems.FirstOrDefault(c => c.Product.ProductId == product.ProductId);
            if (item != null)
            {
                item.Quantity--;
                if (item.Quantity <= 0)
                    CartItems.Remove(item);
            }
        }
    }
}
