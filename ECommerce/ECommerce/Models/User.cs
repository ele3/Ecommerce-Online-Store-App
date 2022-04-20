using System.Runtime.InteropServices;

namespace ECommerce.Models
{
    public partial class User
    {
        public User()
        {
            Carts = new HashSet<Cart>();
            Emails = new HashSet<Email>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string? UserPhoneNumber { get; set; }
        public string? AdminId { get; set; }
        public int AddressId { get; set; }
        public int? CardId { get; set; }

        public virtual Address Address { get; set; } = null!;
        public virtual Card? Card { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
    }
}