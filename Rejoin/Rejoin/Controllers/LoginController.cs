using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rejoin.ViewModels;
using Rejoin.Models;
using Rejoin.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using CryptoHelper;

namespace Rejoin.Controllers
{

    public class LoginController : Controller
    {
        private readonly RejionDBContext _context;

        public LoginController(RejionDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

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

            return View("~/Views/Login/Index.cshtml");
        }
    }
}