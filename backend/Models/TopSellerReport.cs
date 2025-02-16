namespace TmoTask.Models
{
    public class TopSellerReport
    {
        public string Month { get; set; }
        public string Seller { get; set; }

        public int TotalOrders { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
