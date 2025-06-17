using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Restaurant_Menu.Models
{
    public class User
    {
        [Column("userid")] public int UserId { get; set; }
        [Column("firstname")] public string FirstName { get; set; } = string.Empty;
        [Column("lastname")] public string LastName { get; set; } = string.Empty;
        [Column("email")] public string Email { get; set; } = string.Empty;
        [Column("phone")] public string? Phone { get; set; }
        [Column("address")] public string? Address { get; set; }
        [Column("passwordhash")] public string PasswordHash { get; set; } = string.Empty;
        [Column("role")] public string Role { get; set; } = "Client";

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
