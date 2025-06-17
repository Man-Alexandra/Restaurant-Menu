using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Menu.Models
{
    public class MenuProduct
    {
        [Column("menuid")] public int MenuId { get; set; }
        [Column("productid")] public int ProductId { get; set; }
        [Column("productqtygrams")] public int ProductQtyGrams { get; set; }

        public Menu Menu { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }
}
