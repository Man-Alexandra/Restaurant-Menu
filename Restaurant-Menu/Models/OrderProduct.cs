using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Menu.Models
{
    public class OrderProduct
    {
        [Column("orderid")] public int OrderId { get; set; }
        [Column("productid")] public int ProductId { get; set; }
        [Column("quantity")] public int Quantity { get; set; }

        public Order Order { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }
}
