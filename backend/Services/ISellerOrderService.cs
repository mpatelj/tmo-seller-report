using TmoTask.Models;
using System.Collections.Generic;

namespace TmoTask.Services
{
    public interface ISellerOrderService
    {
        public IEnumerable<TopSellerReport> GetTopSellersByMonth(string branch);
        public IEnumerable<string> GetBranches();
    }
}
