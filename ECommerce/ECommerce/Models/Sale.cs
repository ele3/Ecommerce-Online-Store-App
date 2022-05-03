using System;
using System.Runtime.InteropServices;

namespace ECommerce.Models
{
    public partial class Sale
    {
        public int SaleId { get; set; }
        public string SaleName { get; set; } = null!;
        public int SalePercentDiscount { get; set; }
        public DateTime SaleStart { get; set; }
        public DateTime SaleEnd { get; set; }
        public int? CategoryId { get; set; }
        public int? ProductId { get; set; }

        public virtual Category? Category { get; set; }
        public virtual Product? Product { get; set; }
    }
}
