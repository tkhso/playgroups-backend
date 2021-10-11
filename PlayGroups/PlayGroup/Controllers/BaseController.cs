using Playgroup.Data;
using Playgroup.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Playgroup.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly AppSettings AppSettings;
        public ClaimsIdentity Identity => this.User.Identity as ClaimsIdentity;

        public BaseController(IOptions<AppSettings> appSettings)
        {
            this.AppSettings = appSettings.Value;
        }

        protected int? GetUserID()
        {
            return this.Identity.GetUserID();
        }
    }

    public abstract class BaseAuthController : BaseController
    {
        protected readonly AuthHelper<User> AuthManager;

        public BaseAuthController(IOptions<AppSettings> appSettings) : base(appSettings)
        {
        }

        public BaseAuthController(IOptions<AppSettings> appSettings, AuthHelper<User> authManager)
            :base(appSettings)
        {
            this.AuthManager = authManager;
        }
    }
}
