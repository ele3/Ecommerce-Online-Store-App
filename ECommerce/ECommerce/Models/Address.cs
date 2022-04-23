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
        public string Zip { get; set; }
        public string StreetAddress { get; set; } 
        public string City { get; set; } 
        public int? StateId { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual State? State { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
