using System.Runtime.InteropServices;

namespace ECommerce.Models
{
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            Products = new HashSet<Product>();
        }

        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}