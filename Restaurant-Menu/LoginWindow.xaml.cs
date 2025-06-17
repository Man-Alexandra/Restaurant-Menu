using Restaurant_Menu.Data;
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
using System.Security.Cryptography;

namespace Restaurant_Menu
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text.Trim();
            string password = PasswordBox.Password;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both email and password.");
                return;
            }

            using var context = new RestaurantDbContext();

            var user = context.Users.FirstOrDefault(u => u.Email == email);

            if (user != null && VerifyPassword(password, user.PasswordHash))
            {
                MessageBox.Show($"Welcome, {user.FirstName}!");

                // Redirect to main window (example)
                var menusWindow = new ShopWindow();
                menusWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid email or password.");
            }
        }

        // Verifies hash (assuming SHA256 or similar was used)
        private bool VerifyPassword(string inputPassword, string storedHash)
        {
            using var sha256 = SHA256.Create();
            var inputBytes = Encoding.UTF8.GetBytes(inputPassword);
            var inputHash = Convert.ToBase64String(sha256.ComputeHash(inputBytes));
            return inputHash == storedHash;
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
