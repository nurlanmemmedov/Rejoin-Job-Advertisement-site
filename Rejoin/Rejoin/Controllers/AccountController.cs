using System;
using System.Collections.Generic;
using System.Linq;
using CryptoHelper;
using Microsoft.AspNetCore.Mvc;
using Rejoin.Data;
using Rejoin.Filters;
using Rejoin.Injections;
using Rejoin.Models;
using Rejoin.ViewModels;

namespace Rejoin.Controllers
{
    public class AccountController : BaseController
    {
        private readonly RejionDBContext _context;

        private readonly IAuth _auth;


        //constructor of account controller
        public AccountController(RejionDBContext context, IAuth auth) : base(context)
        {
            _context = context;
            _auth = auth;
        }


        //returns login page
        public IActionResult Login()
        {

            //show breadcrumb of login page
            BreadCrumbViewModel breadCrumb = new BreadCrumbViewModel
            {
                Title = "Daxil ol",
                Parents = new Dictionary<string, List<string>>()
                    {
                        { "Ana səhifə", new List<string>() { "home", "index" } },
                    }
            };
            ViewBag.BreadCrumb = breadCrumb;
            return View();
        }


        //to Login user 
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
                        if (_auth.User != null)
                        {
                            User loggedUser = _context.Users.Find(_auth.User.Id);
                            loggedUser.Token = null;
                            _context.SaveChanges();
                            Response.Cookies.Delete("token");
                        }

                        user.Token = Guid.NewGuid().ToString();
                        _context.SaveChanges();

                        Response.Cookies.Append("token", user.Token, new Microsoft.AspNetCore.Http.CookieOptions
                        {
                            Expires = DateTime.Now.AddYears(1),
                            HttpOnly = true
                        });

                        //redirect to homepage
                        return RedirectToAction("index", "home");
                    }
                }

                ModelState.AddModelError("Password", "e-poçt və ya şifrə yanlışdır");
            }

            //returns  breadcrumb of Login page
            BreadCrumbViewModel breadCrumb = new BreadCrumbViewModel
            {
                Title = "Daxil ol",
                Parents = new Dictionary<string, List<string>>()
                    {
                        { "Ana səhifə", new List<string>() { "home", "index" } },
                    }
            };
            ViewBag.BreadCrumb = breadCrumb;

            return View("~/Views/Account/Login.cshtml");
        }


        //returns register page
        public IActionResult Register()
        {

            //show breadcrumb of register page
            BreadCrumbViewModel breadCrumb = new BreadCrumbViewModel
            {
                Title = "Qeydiyyatdan keç",
                Parents = new Dictionary<string, List<string>>()
                    {
                        { "Ana səhifə", new List<string>() { "home", "index" } },
                    }
            };
            ViewBag.BreadCrumb = breadCrumb;
            return View();
        }


        //to register user
        [HttpPost]
        public IActionResult RegisterUser(RegisterViewModel Register)
        {

            if (ModelState.IsValid)
            {
                if (!_context.Users.Any(u => u.Email == Register.Email))
                {
                    if (_auth.User != null)
                    {
                        User loggedUser = _context.Users.Find(_auth.User.Id);
                        loggedUser.Token = null;
                        _context.SaveChanges();
                        Response.Cookies.Delete("token");
                    }

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
            
            //show breadcrumb register page
            BreadCrumbViewModel breadCrumb = new BreadCrumbViewModel
            {
                Title = "Qeydiyyatdan keç",
                Parents = new Dictionary<string, List<string>>()
                    {
                        { "Ana səhifə", new List<string>() { "home", "index" } },
                    }
            };
            ViewBag.BreadCrumb = breadCrumb;
            return View("~/Views/Account/Register.cshtml");


        }


        //to logout user
        [TypeFilter(typeof(CheckAuth))]
        public IActionResult Logout()
        {
            if (_auth.User != null)
            {
                User loggedUser = _context.Users.Find(_auth.User.Id);
                loggedUser.Token = null;
                _context.SaveChanges();
                Response.Cookies.Delete("token");
            }

            //redirect to login page
            return RedirectToAction("login" ,"account");
        }
    }
}