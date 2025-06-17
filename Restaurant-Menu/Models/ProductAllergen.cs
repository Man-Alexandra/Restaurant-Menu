using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Menu.Models
{
    public class ProductAllergen
    {
        [Column("productid")] public int ProductId { get; set; }
        [Column("allergenid")] public int AllergenId { get; set; }

        public Product Product { get; set; } = null!;
        public Allergen Allergen { get; set; } = null!;
    }
}
