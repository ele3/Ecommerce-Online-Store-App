using System.Runtime.InteropServices;

namespace ECommerce.Models
{
    public partial class Card
    {
        public Card()
        {
            Users = new HashSet<User>();
        }

        public int CardId { get; set; }
        public string CardNumber { get; set; } = null!;
        public string CardExpiration { get; set; } = null!;
        public string CardCcv { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}