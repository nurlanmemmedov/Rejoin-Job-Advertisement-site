using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rejoin.Data;
using Rejoin.ViewModels;
using Rejoin.Models;
using CryptoHelper;


namespace Rejoin.Controllers
{
    public class RegisterController : Controller
    {
        private readonly RejionDBContext _context;

        public RegisterController(RejionDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
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

            return View("~/Views/Register/index.cshtml");


        }
    }
}