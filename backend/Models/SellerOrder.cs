using System.Runtime.CompilerServices;

namespace TmoTask.Models
{
    public class SellerOrder
    {
        public string Seller { get; set; }
        public string Product { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }
        public string Branch { get; set; }
    }
}
