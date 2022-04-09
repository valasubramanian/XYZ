using System.Security.Claims;
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
using Newtonsoft.Json;
using IdentityModel.Client;

namespace XYZ.UI.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public ProfileController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.IdToken = await GetIdToken();
            ViewBag.IsAuthenticated = HttpContext.User.Identity.IsAuthenticated;
            ViewBag.Claims = HttpContext.User.Claims;
            ViewBag.AllClaims = await GetAllClaimsFromUserEndpoint();
            GetUsersFromApi();
            return View();
        }

        public async Task Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
        }

        private async Task<string> GetIdToken()
        {
            var idToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken);
            return idToken;
        }

        private async Task<string> GetAccessToken()
        {
            var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            return accessToken;
        }

        private async Task<List<Claim>> GetAllClaimsFromUserEndpoint()
        {
            return null;
        }

        private async void GetUsersFromApi()
        {
            string accessToken = await GetAccessToken();
            var client = _httpClientFactory.CreateClient("X.API");
            client.SetBearerToken(accessToken);

            var buffer = System.Text.Encoding.UTF8.GetBytes("{ 'UserId': '1' }");
            var byteContent = new ByteArrayContent(buffer);
            var response = await client.PostAsync("/api/getusers", byteContent);
            if (response.IsSuccessStatusCode)
            {
               var responseMessage = await response.Content.ReadAsStringAsync();
            }
        }
    }
}
