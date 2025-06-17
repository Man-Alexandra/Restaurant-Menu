using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Restaurant_Menu.Models
{
    public class Category
    {
        [Column("categoryid")] public int CategoryId { get; set; }
        [Column("name")] public string Name { get; set; } = string.Empty;

        public ICollection<Product> Products { get; set; } = new List<Product>();
        public ICollection<Menu> Menus { get; set; } = new List<Menu>();
    }
}
