using Restaurant_Menu.Models;
using Restaurant_Menu.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Restaurant_Menu
{
    public partial class CartWindow : Window
    {
        public ObservableCollection<CartItem> CartItems => CartService.CartItems;

        public CartWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        private void OrdersButton_Click(object sender, RoutedEventArgs e)
        {
            OrdersWindow mainWindow = new OrdersWindow();
            mainWindow.Show();
            this.Close();
        }

        private void CartButton_Click(object sender, RoutedEventArgs e)
        {
            ShopWindow mainWindow = new ShopWindow();
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
        private void Increase_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button)?.DataContext is CartItem item)
            {
                CartService.IncreaseQuantity(item.Product);
            }
        }

        private void Decrease_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button)?.DataContext is CartItem item)
            {
                CartService.DecreaseQuantity(item.Product);
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button)?.DataContext is CartItem item)
            {
                CartService.RemoveFromCart(item.Product);
            }
        }
    }
}
