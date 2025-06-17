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
using static System.Net.Mime.MediaTypeNames;

namespace Restaurant_Menu
{
    public partial class StartersWindow : Window
    {
        public StartersWindow()
        {
            InitializeComponent();
            DataContext = new StartersViewModel(); // Set the DataContext to your ViewModel
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is StartersViewModel vm)
            {
                string keyword = SearchTextBox.Text.Trim();
                vm.FilterProducts(keyword);
            }
        }

    }
}
