using Restaurant_Menu.Models;
using System.Collections.ObjectModel;

namespace Restaurant_Menu.ViewModels
{
    public class ProductGroup
    {
        public string Category { get; set; } = string.Empty;
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();
    }
}
