using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Menu.Models
{
    public class ProductImage
    {
        [Column("imageid")] public int ImageId { get; set; }
        [Column("productid")] public int ProductId { get; set; }
        [Column("imagepath")] public string ImagePath { get; set; }

        public Product Product { get; set; } = null!;
    }
}
