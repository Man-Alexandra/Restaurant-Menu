using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Menu.Models
{
    public class ConfigSettings
    {
        [Column("id")] public int Id { get; set; } = 1;
        [Column("menudiscountpercent")] public decimal? MenuDiscountPercent { get; set; }
        [Column("orderminvaluefordiscount")] public decimal? OrderMinValueForDiscount { get; set; }
        [Column("ordersrequiredfordiscount")] public int? OrdersRequiredForDiscount { get; set; }
        [Column("discounttimeperioddays")] public int? DiscountTimePeriodDays { get; set; }
        [Column("orderdiscountpercent")] public decimal? OrderDiscountPercent { get; set; }
        [Column("deliverythresholdvalue")] public decimal? DeliveryThresholdValue { get; set; }
        [Column("deliveryfee")] public decimal? DeliveryFee { get; set; }
        public int? LowStockThresholdGrams { get; set; }
    }
}
