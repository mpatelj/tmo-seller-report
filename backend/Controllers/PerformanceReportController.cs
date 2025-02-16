using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using TmoTask.Services;
using TmoTask.Models;
using System.Linq;

namespace TmoTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PerformanceReportController : ControllerBase
    {
        private readonly ISellerOrderService _sellerOrderService;

        public PerformanceReportController(ISellerOrderService sellerOrderService)
        {
            _sellerOrderService = sellerOrderService;
        }

        /*[HttpGet]
        public IActionResult Get(string branch)
        {
            throw new NotImplementedException();
        }*/

        [HttpGet]
        public IActionResult Get(string branch)
        {
            if (string.IsNullOrWhiteSpace(branch))
            {
                return BadRequest("Branch parameter is required");
            }

            var report = _sellerOrderService.GetTopSellersByMonth(branch);

            if (report == null || !report.Any())
            {
                return NotFound("No data found for the specified branch.");
            }

            return Ok(report);
        }

        [HttpGet("branches")]
        public IActionResult GetBranches()
        {
            var branches = _sellerOrderService.GetBranches();
            return Ok(branches);
        }
    }
}
