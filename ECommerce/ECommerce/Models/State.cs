using System.Runtime.InteropServices;

namespace ECommerce.Models
{
    public partial class State
    {
        public State()
        {
            Addresses = new HashSet<Address>();
        }

        public int StateId { get; set; }
        public string State1 { get; set; } 

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
