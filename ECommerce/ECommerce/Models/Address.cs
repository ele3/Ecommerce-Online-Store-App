using System.Runtime.InteropServices;

namespace ECommerce.Models
{
    public partial class Address
    {
        public Address()
        {
            Users = new HashSet<User>();
        }

        public int AddressId { get; set; }
        public string Zip { get; set; } = null!;
        public string StreetAddress { get; set; } = null!;
        public string City { get; set; } = null!;
        public int? StateId { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; } = null!;
        public virtual State? State { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
