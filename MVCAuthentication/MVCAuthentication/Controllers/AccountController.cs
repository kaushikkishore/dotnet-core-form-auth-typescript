﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace MVCAuthentication.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string userName, string password)
        {
            if (!string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(password))
            {
                return RedirectToAction("Login");
            }

            //Check the user name and password  
            //Here can be implemented checking logic from the database  
            ClaimsIdentity identity = null;
            bool isAuthenticated = false;

            if (string.Equals(userName , "Admin", StringComparison.OrdinalIgnoreCase) && string.Equals(password , "password", StringComparison.OrdinalIgnoreCase))
            {

                //Create the identity for the user  
                identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, userName),
                    new Claim(ClaimTypes.Role, "Admin")
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                isAuthenticated = true;
            }

            if (string.Equals(userName, "Mukesh", StringComparison.OrdinalIgnoreCase) && string.Equals(password, "password", StringComparison.OrdinalIgnoreCase))
            {
                //Create the identity for the user  
                identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, userName),
                    new Claim(ClaimTypes.Role, "User")
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                isAuthenticated = true;
            }

            if (isAuthenticated)
            {
                var principal = new ClaimsPrincipal(identity);

                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(2),
                    IsPersistent = false,
                    AllowRefresh = false
                });

                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        [Route("error/404")]
        public IActionResult Error404()
        {
            return View();
        }

        [Route("error/{code:int}")]
        public IActionResult Error(int code)
        {
            // handle different codes or just return the default error view
            return View();
        }
    }
}