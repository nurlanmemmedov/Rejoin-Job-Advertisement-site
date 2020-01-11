using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rejoin.ViewModels;
using Rejoin.Models;
using Rejoin.Data;


namespace Rejoin.Controllers
{
    public class ContactUsController : BaseController
    {
        private readonly RejionDBContext _context;
        public ContactUsController(RejionDBContext context):base(context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            BreadCrumbViewModel breadCrumb = new BreadCrumbViewModel
            {
                Title = "Əlaqə",
                Parents = new Dictionary<string, List<string>>()
                    {
                        { "Ana səhifə", new List<string>() { "home", "index" } },
                    }
            };
            ViewBag.BreadCrumb = breadCrumb;
            return View();
        }

        public IActionResult SendMessage(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                Contact contact = new Contact
                {
                    Name = model.Name,
                    Email = model.Email,
                    Message = model.Message
                };
                _context.Contacts.Add(contact);
                _context.SaveChanges();
                return RedirectToAction("index","home");
            }
            BreadCrumbViewModel breadCrumb = new BreadCrumbViewModel
            {
                Title = "Əlaqə",
                Parents = new Dictionary<string, List<string>>()
                    {
                        { "Ana səhifə", new List<string>() { "home", "index" } },
                    }
            };
            ViewBag.BreadCrumb = breadCrumb;
            return View("~/Views/ContactUs/Index.cshtml");
        }

    }
}