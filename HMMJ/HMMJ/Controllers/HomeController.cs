using HMMJ.Helpers;
using HMMJ.Models;
using HMMJ.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HMMJ.Controllers
{
    public class HomeController : BaseAuthController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(IOptions<AppSettings> appSettings, ILogger<HomeController> logger)
            : base(appSettings)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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
    }
}
