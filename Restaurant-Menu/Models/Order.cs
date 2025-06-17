using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Menu.Models
{
    public class Order
    {
        [Column("orderid")] public int OrderId { get; set; }
        [Column("userid")] public int UserId { get; set; }
        [Column("orderdate")] public DateTime OrderDate { get; set; }
        [Column("isdelivery")] public bool IsDelivery { get; set; }
        [Column("deliveryaddress")] public string? DeliveryAddress { get; set; }
        [Column("status")] public string Status { get; set; } = "Pending";

        public User User { get; set; } = null!;
        public ICollection<OrderMenu> OrderMenus { get; set; } = new List<OrderMenu>();
        public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}
