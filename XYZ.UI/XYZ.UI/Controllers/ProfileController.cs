using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

namespace XYZ.UI.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public ProfileController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.IdToken = await GetIdentityInformation();
            ViewBag.IsAuthenticated = HttpContext.User.Identity.IsAuthenticated;
            ViewBag.Claims = HttpContext.User.Claims;
            return View();
        }

        public async Task Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
        }

        private async Task<string> GetIdentityInformation()
        {
            var idToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken);
            return idToken;
        }
    }
}
