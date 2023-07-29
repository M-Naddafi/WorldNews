using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using WorldNews.DataLayer.Context;
using WorldNews.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WorldNews.Core.DTOs;
using WorldNews.DataLayer.Models;
using NuGet.Protocol.Plugins;
using System.Security.Claims;

namespace WorldNews.Controllers
{
    public class AccountController : Controller
    {
        #region services

        private IAccountService _service;
        public AccountController(IAccountService service)
        {
            _service = service;
        }

        #endregion

        #region Register


        [Route("/Register")]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [Route("/Register")]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(registerViewModel);
            }

            if(_service.DoesUsernameExist(registerViewModel.UserName.ToLower()))
            {
                ModelState.AddModelError("UserName", "نام کاربری وارد شده معتبر نمی باشد");
                return View(registerViewModel);
            }

            User user = new User()
            {
                UserName= registerViewModel.UserName,
                Password= registerViewModel.Password,
                IsAdmin = false,
            };

            _service.RegisterUser(user);

            return RedirectToAction("Login");
        }


        #endregion

        #region Login


        [Route("/Login")]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [Route("/Login")]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            var user = _service.LoginUser(loginViewModel.UserName.ToLower(), loginViewModel.Password);
            if (user == null)
            {
                ModelState.AddModelError("Email", "We couldn't find a user with your information");
                return View(loginViewModel);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim("IsAdmin", user.IsAdmin.ToString()),
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties
            {
                IsPersistent = loginViewModel.RememberMe
            };

            HttpContext.SignInAsync(principal, properties);

            return Redirect("/");
        }
        #endregion

        #region Logout
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Login");
        }

        #endregion
    }
}
