using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Menu.Models
{
    public class Allergen
    {
        [Column("allergenid")] public int AllergenId { get; set; }
        [Column("name")] public string Name { get; set; } = string.Empty;

        public ICollection<ProductAllergen> ProductAllergens { get; set; } = new List<ProductAllergen>();
    }
}
