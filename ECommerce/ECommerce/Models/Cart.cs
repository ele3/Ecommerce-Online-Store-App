using System;
using System.Runtime.InteropServices;

namespace ECommerce.Models
{
    public partial class Cart
    {
        public Cart()
        {
            Cartproducts = new HashSet<Cartproduct>();
        }

        public int CartId { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Cartproduct> Cartproducts { get; set; }
    }
}