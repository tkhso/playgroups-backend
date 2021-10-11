using HMMJ.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMMJ.Web.Controllers.Api
{
    public class BaseApiController : BaseAuthController
    {
        public BaseApiController(IOptions<AppSettings> appSettings)
            :base (appSettings)
        {}
    }
}
