using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoHelper;
using Microsoft.AspNetCore.Mvc;
using Rejoin.Data;
using Rejoin.Filters;
using Rejoin.Injections;
using Rejoin.Models;
using Rejoin.ViewModels;

namespace Rejoin.Controllers
{
    public class AccountController : Controller
    {
        private readonly RejionDBContext _context;

        private readonly IAuth _auth;

        public AccountController(RejionDBContext context, IAuth auth)
        {
            _context = context;
            _auth = auth;
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginUser(LoginViewModel Login)
        {

            if (ModelState.IsValid)
            {

                User user = _context.Users.FirstOrDefault(u => u.Email == Login.Email);

                if (user != null)
                {
                    if (Crypto.VerifyHashedPassword(user.Password, Login.Password))
                    {
                        user.Token = Guid.NewGuid().ToString();
                        _context.SaveChanges();

                        Response.Cookies.Append("token", user.Token, new Microsoft.AspNetCore.Http.CookieOptions
                        {
                            Expires = DateTime.Now.AddYears(1),
                            HttpOnly = true
                        });

                        return RedirectToAction("index", "home");
                    }
                }

                ModelState.AddModelError("Password", "e-poçt və ya şifrə yanlışdır");
            }

            return View("~/Views/Account/Login.cshtml");
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterUser(RegisterViewModel Register)
        {

            if (ModelState.IsValid)
            {
                if (!_context.Users.Any(u => u.Email == Register.Email))
                {
                    var user = new User
                    {
                        Fullname = Register.Fullname,
                        Email = Register.Email,
                        Password = Crypto.HashPassword(Register.Password),
                        Token = Guid.NewGuid().ToString(),
                        UserType = Register.UserType
                    };

                    Response.Cookies.Append("token", user.Token, new Microsoft.AspNetCore.Http.CookieOptions
                    {
                        Expires = DateTime.Now.AddYears(1),
                        HttpOnly = true
                    });

                    _context.Users.Add(user);
                    _context.SaveChanges();
                    return RedirectToAction("index", "home");
                }
                ModelState.AddModelError("Email", "Bu e-poçt artıq qeydiyyatdan keçib");
            }

            return View("~/Views/Account/Register.cshtml");


        }

        [TypeFilter(typeof(CheckAuth))]
        public IActionResult Logout()
        {
            User user = _context.Users.Find(_auth.User.Id);
            user.Token = null;
            _context.SaveChanges();

            Response.Cookies.Delete("token");

            return RedirectToAction("index" ,"home");
        }
    }
}