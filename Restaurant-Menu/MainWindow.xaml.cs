using Restaurant_Menu;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Restaurant_Menu
{
    public partial class MainWindow : Window
    {
        // List to store the image paths or URIs
        private List<string> imagePaths;
        private int currentImageIndex;
        public MainWindow()
        {
            InitializeComponent();
            InitializeSlider();
        }

        private void InitializeSlider()
        {
            imagePaths = new List<string>
            {
                "images/onion-pasta.jpg", 
                "images/cajun-pasta.jpg",
                "images/garlic-shrimp.jpg",
                "images/steak-garlic.jpg",
                "images/caprese-pasta.jpg",
                "images/duck-confit.jpg",
                "images/pesto-grilled.jpg",
                "images/apple-muffin.jpg",
                "images/banana-bread.jpg",
                "images/cinnamon-muffin.jpg",
                "images/coffee-muffin.jpg",
                "images/chocolate-muffin.jpg",
                "images/carrot-cake.jpg",
                "images/croissant.jpg",
                "images/chocolate-cookie.jpg",

            };

            currentImageIndex = 0; 

            // Load the first image
            LoadImages();
        }
        private void LoadImages()
        {
            // Set the sources for the three image controls based on the current index
            if (currentImageIndex < 0) currentImageIndex = 0;
            if (currentImageIndex + 2 >= imagePaths.Count) currentImageIndex = imagePaths.Count - 3; // Prevent overflow

            // Set the sources for the three images
            Image1.Source = new BitmapImage(new Uri(imagePaths[currentImageIndex], UriKind.Relative));
            Image2.Source = new BitmapImage(new Uri(imagePaths[currentImageIndex + 1], UriKind.Relative));
            Image3.Source = new BitmapImage(new Uri(imagePaths[currentImageIndex + 2], UriKind.Relative));
        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
            // Shift images to the right
            if (currentImageIndex > 0)
            {
                currentImageIndex--; 
                LoadImages(); 
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            // Shift images to the left 
            if (currentImageIndex + 3 < imagePaths.Count)
            {
                currentImageIndex++; 
                LoadImages();
            }
        }
        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow = new MenuWindow();
            menuWindow.Show(); 
            this.Close();      
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            SignUpWindow loginWindow = new SignUpWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}