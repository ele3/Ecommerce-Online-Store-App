using System.Runtime.InteropServices;

namespace ECommerce.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
            Sales = new HashSet<Sale>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}