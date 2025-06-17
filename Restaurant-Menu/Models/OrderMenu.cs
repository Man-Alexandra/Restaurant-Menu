using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Menu.Models
{
    public class OrderMenu
    {
        [Column("orderid")] public int OrderId { get; set; }
        [Column("menuid")] public int MenuId { get; set; }
        [Column("quantity")] public int Quantity { get; set; }

        public Order Order { get; set; } = null!;
        public Menu Menu { get; set; } = null!;
    }
}
