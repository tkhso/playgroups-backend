using HMMJ.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMMJ.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseAuthAdminController
    {
        public HomeController(IOptions<AppSettings> appSettings)
            : base(appSettings)
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
