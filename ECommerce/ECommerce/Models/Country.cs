using System.Runtime.InteropServices;

namespace ECommerce.Models
{
    public partial class Country
    {
        public Country()
        {
            Addresses = new HashSet<Address>();
        }

        public int CountryId { get; set; }
        public string Country1 { get; set; } = null!;

        public virtual ICollection<Address> Addresses { get; set; }
    }
}