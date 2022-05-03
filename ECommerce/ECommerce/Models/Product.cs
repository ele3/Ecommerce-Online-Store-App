using System.Runtime.InteropServices;

namespace ECommerce.Models
{
    public partial class Product
    {
        public Product()
        {
            Cartproducts = new HashSet<Cartproduct>();
            Sales = new HashSet<Sale>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string ProductImage { get; set; } = null!;
        public int ManufacturerId { get; set; }
        public string ProductDesc { get; set; } = null!;
        public double? ProductLength { get; set; }
        public double? ProductWidth { get; set; }
        public double? ProductWeight { get; set; }
        public double? ProductRating { get; set; }
        public double? ProductPrice { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual Manufacturer Manufacturer { get; set; } = null!;
        public virtual ICollection<Cartproduct> Cartproducts { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}