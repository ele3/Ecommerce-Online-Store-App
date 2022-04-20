using System.Runtime.InteropServices;

namespace ECommerce.Models
{
    public partial class Email
    {
        public int EmailId { get; set; }
        public string Address { get; set; } = null!;
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
    }
}