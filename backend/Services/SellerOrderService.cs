using CsvHelper;
using System.Globalization;
using TmoTask.Models;


namespace TmoTask.Services
{
    public class SellerOrderService : ISellerOrderService
    {
        private readonly string _csvPath;

        public SellerOrderService(string csvPath)
        {
            _csvPath = csvPath;
        }

        public IEnumerable<TopSellerReport> GetTopSellersByMonth(string branch)
        {
            using var reader = new StreamReader(_csvPath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<SellerOrder>().ToList();

            var report = records.
                Where(o => o.Branch == branch)
                .GroupBy(o => new { o.OrderDate.Year, o.OrderDate.Month, o.Seller })
                .Select(g => new TopSellerReport
                {
                    Month = new DateTime(g.Key.Year, g.Key.Month, 1).ToString("MMMM"),
                    Seller = g.Key.Seller,
                    TotalOrders = g.Count(),
                    TotalPrice = g.Sum(o => o.Price),
                })
                .OrderBy(r => DateTime.ParseExact(r.Month, "MMMM", CultureInfo.InvariantCulture))
                .ThenByDescending(r => r.TotalPrice)
                .ThenBy(r => r.Seller)
                .ToList();

            return report;
        }

        public IEnumerable<string> GetBranches()
        {
            using var reader = new StreamReader(_csvPath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<SellerOrder>().ToList();

            var branches = records.Select(r => r.Branch).Distinct().ToList();

            return branches;
        }
    }
}