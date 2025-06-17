using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Menu.ViewModels
{
    public class MenuDisplay
    {
        public string Name { get; set; }
        public ObservableCollection<ProductDisplay> Products { get; set; } = new();
    }
    public class ProductDisplay
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int PortionQtyGrams { get; set; }
        public decimal Price { get; set; }
        public string FirstImagePath { get; set; }
        public string AllergenSummary { get; set; }
    }
}
