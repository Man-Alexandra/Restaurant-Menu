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

namespace Restaurant_Menu
{
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Category_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is string category)
            {
                Window categoryWindow = null;

                switch (category)
                {
                    case "Appetizers":
                        categoryWindow = new StartersWindow();
                        break;
                    case "MainCourses":
                        categoryWindow = new MainCoursesWindow();
                        break;
                    case "Desserts":
                        categoryWindow = new DessertsWindow();
                        break;
                    case "Drinks":
                        categoryWindow = new DrinksWindow();
                        break;
                    case "Menus":
                        categoryWindow = new MenusWindow();
                        break;
                    default:
                        MessageBox.Show("Unknown category.");
                        return;
                }

                categoryWindow?.Show();
                this.Close(); // Close the current MenuWindow
            }
        }


    }
}
