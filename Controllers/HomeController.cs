using EZmenities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EZmenities.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Pool(int chairNumber)
        {
            var data = new List<List<string>>();

            var row = new List<string>();
            row.Add("10AM - 11AM");
            row.Add("Available");
            data.Add(row);

            row = new List<string>();
            row.Add("11AM - 12PM");
            row.Add("Available");
            data.Add(row);

            row = new List<string>();
            row.Add("12AM - 1PM");
            row.Add("Reserved");
            data.Add(row);

            row = new List<string>();
            row.Add("1PM - 2PM");
            row.Add("Available");
            data.Add(row);

            row = new List<string>();
            row.Add("2PM - 3PM");
            row.Add("Reserved");
            data.Add(row);

            row = new List<string>();
            row.Add("3PM - 4PM");
            row.Add("Available");
            data.Add(row);

            row = new List<string>();
            row.Add("4PM - 5PM");
            row.Add("Available");
            data.Add(row);

            return View(data);
        }

        public IActionResult BasketBall()
        {
            var data = new List<List<string>>();

            var row = new List<string>();
            row.Add("10AM - 11AM");
            row.Add("Available");
            data.Add(row);

            row = new List<string>();
            row.Add("11AM - 12PM");
            row.Add("Available");
            data.Add(row);

            row = new List<string>();
            row.Add("12AM - 1PM");
            row.Add("Reserved");
            data.Add(row);

            row = new List<string>();
            row.Add("1PM - 2PM");
            row.Add("Available");
            data.Add(row);

            row = new List<string>();
            row.Add("2PM - 3PM");
            row.Add("Reserved");
            data.Add(row);

            row = new List<string>();
            row.Add("3PM - 4PM");
            row.Add("Available");
            data.Add(row);

            row = new List<string>();
            row.Add("4PM - 5PM");
            row.Add("Available");
            data.Add(row);

            return View(data);
        }

        public IActionResult Tennis()
        {
            var data = new List<List<string>>();

            var row = new List<string>();
            row.Add("10AM - 11AM");
            row.Add("Available");
            data.Add(row);

            row = new List<string>();
            row.Add("11AM - 12PM");
            row.Add("Available");
            data.Add(row);

            row = new List<string>();
            row.Add("12AM - 1PM");
            row.Add("Reserved");
            data.Add(row);

            row = new List<string>();
            row.Add("1PM - 2PM");
            row.Add("Available");
            data.Add(row);

            row = new List<string>();
            row.Add("2PM - 3PM");
            row.Add("Reserved");
            data.Add(row);

            row = new List<string>();
            row.Add("3PM - 4PM");
            row.Add("Available");
            data.Add(row);

            row = new List<string>();
            row.Add("4PM - 5PM");
            row.Add("Available");
            data.Add(row);

            return View(data);
        }

        public IActionResult BBQ(int grillNumber)
        {
            var data = new List<List<string>>();

            var row = new List<string>();
            row.Add("10AM - 12AM");
            row.Add("Available");
            data.Add(row);

            row = new List<string>();
            row.Add("12AM - 2PM");
            row.Add("Available");
            data.Add(row);

            row = new List<string>();
            row.Add("2AM - 4PM");
            row.Add("Reserved");
            data.Add(row);

            row = new List<string>();
            row.Add("4PM - 6PM");
            row.Add("Available");
            data.Add(row);

            row = new List<string>();
            row.Add("6PM - 8PM");
            row.Add("Reserved");
            data.Add(row);

            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost, Route("api/[controller]/[action]")]
        public IActionResult PoolRequest(int chairNumber, string time, bool isReserve, int aptlNumber)
        {
            try
            {
                return new ObjectResult(true);
            }
            catch (Exception e)
            {
                return new ObjectResult(false);
            }
        }

        [HttpPost, Route("api/[controller]/[action]")]
        public IActionResult TennisRequest(string time, bool isReserve)
        {
            try
            {
                return new ObjectResult(true);
            }
            catch (Exception e)
            {
                return new ObjectResult(false);
            }
        }

        [HttpPost, Route("api/[controller]/[action]")]
        public IActionResult BasketballRequest(string time, bool isReserve)
        {
            try
            {
                return new ObjectResult(true);
            }
            catch (Exception e)
            {
                return new ObjectResult(false);
            }
        }

        [HttpPost, Route("api/[controller]/[action]")]
        public IActionResult GrillRequest(int grillNumber, string time, bool isReserve, string aptlNumber)
        {
            try
            {
                return new ObjectResult(true);
            }
            catch (Exception e)
            {
                return new ObjectResult(false);
            }
        }
    }
}
