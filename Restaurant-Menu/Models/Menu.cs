using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Menu.Models
{
    public class Menu
    {
        [Column("menuid")] public int MenuId { get; set; }
        [Column("name")] public string Name { get; set; } = string.Empty;
        [Column("categoryid")] public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;
        public ICollection<MenuProduct> MenuProducts { get; set; } = new List<MenuProduct>();
        public ICollection<OrderMenu> OrderMenus { get; set; } = new List<OrderMenu>();
    }
}
