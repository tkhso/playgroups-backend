﻿using HMMJ.Helpers;
using HMMJ.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMMJ.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BaseAuthAdminController : BaseAuthController
    {
        private readonly AppSettings Appsettings;
        public BaseAuthAdminController(IOptions<AppSettings> appSettings)
           : base(appSettings)
        {
            this.Appsettings = appSettings.Value;
        }
    }
}
