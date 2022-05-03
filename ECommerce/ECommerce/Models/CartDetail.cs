namespace ECommerce.Models
{
    public partial class CartDetail
    {
        public Cart? Cart { get; set; }
        public IEnumerable<Sale>? Sales { get; set; }
        public double? SubtotalAmount { get; set; }
        public double? DiscountPercentage { get; set; }
        public double? DiscountAmount { get; set; }
        public double? TotalAmount { get; set; }
        public double? Tax { get; set; }

    }
}
