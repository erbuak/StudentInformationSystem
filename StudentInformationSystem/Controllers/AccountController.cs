using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentInformationSystem.Models;
using StudentInformationSystem.ViewModels.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StudentInformationSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Login(UserLoginViewModel userLoginViewModel)
        {
            ClaimsIdentity claimsIdentity = null;
            bool isAuthenticate = false;
            if (ModelState.IsValid)
            {
                User user = _context.Users.FirstOrDefault(x => x.Username == userLoginViewModel.UserName && x.Password == userLoginViewModel.Password);
                
                if(user != null)
                {
                    if (user.Type == false)
                    {
                        claimsIdentity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Role,"Admin"),
                        new Claim("Id" , user.Id.ToString()),
                        new Claim(type: "UserId", value: user.Id.ToString())
                    }, CookieAuthenticationDefaults.AuthenticationScheme);
                        isAuthenticate = true;
                    }
                    else
                    {
                        claimsIdentity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Role,"Student"),
                        new Claim("Id" , user.Id.ToString()),
                        new Claim(type: "UserId", value: user.Id.ToString())
                    }, CookieAuthenticationDefaults.AuthenticationScheme);
                        isAuthenticate = true;
                    }
                } 
                else
                {
                    ViewBag.loginFailMessage = "Kullanıcı adı ve/veya şifre yanlış!";
                    return View();
                }
                
                if(isAuthenticate)
                {
                    var principal = new ClaimsPrincipal(claimsIdentity);
                    var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
