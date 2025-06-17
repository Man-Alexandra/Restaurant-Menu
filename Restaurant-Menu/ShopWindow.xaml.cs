using Restaurant_Menu.Data;
using Restaurant_Menu.Models;
using Restaurant_Menu.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Restaurant_Menu.Service;
using Restaurant_Menu.Helpers;


namespace Restaurant_Menu
{
    public partial class ShopWindow : Window
    {
        public ShopWindow()
        {
            InitializeComponent();
            DataContext = new ShopViewModel(); // Hook up ViewModel
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is ProductViewModel vm)
            {
                string keyword = SearchTextBox.Text.Trim();
                vm.FilterProducts(keyword);
            }
        }

        private void CartButton_Click(object sender, RoutedEventArgs e)
        {
            CartWindow mainWindow = new CartWindow();
            mainWindow.Show();
            this.Close();
        }

        private void OrdersButton_Click(object sender, RoutedEventArgs e)
        {
            OrdersWindow mainWindow = new OrdersWindow();
            mainWindow.Show();
            this.Close();
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
