using Playgroup.Data;
using Playgroup.Helpers;
using Playgroup.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playgroup.Web.Controllers
{
    public class AccountController : BaseAuthController
    {
        private readonly IUserService UserService;

        public AccountController(IOptions<AppSettings> appSettings, AuthHelper<User> authManager, IUserService userService)
            : base(appSettings, authManager)
        {
            this.UserService = userService;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            var model = new User();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(User model)
        {
            IdentityResult res = null;
            model = this.UserService.GetUserEmail(model.Email);

            if (model.IsCreate)
            {
                model.UserName = model.Email;
                res = await this.AuthManager.UserManager.CreateAsync(model, model.Password);
            }
           
            return RedirectToAction("Index", "Home");
        }
    }
}
