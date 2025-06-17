using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Menu.Models
{
    public class Product
    {
        [Column("productid")] public int ProductId { get; set; }
        [Column("name")] public string Name { get; set; } = string.Empty;
        [Column("price")] public decimal Price { get; set; }
        [Column("portionqtygrams")] public int PortionQtyGrams { get; set; }
        [Column("totalqtygrams")] public int TotalQtyGrams { get; set; }
        [Column("categoryid")] public int CategoryId { get; set; }
        [Column("description")] public string Description { get; set; }
        [NotMapped] public string FirstImagePath => $"/images/{ProductImages.FirstOrDefault()?.ImagePath ?? "placeholder.png"}";
        [NotMapped] public string AllergenSummary => string.Join(", ", ProductAllergens.Select(pa => pa.Allergen.Name));

        public Category Category { get; set; } = null!;
        public ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
        public ICollection<ProductAllergen> ProductAllergens { get; set; } = new List<ProductAllergen>();
        public ICollection<MenuProduct> MenuProducts { get; set; } = new List<MenuProduct>();
        public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}
