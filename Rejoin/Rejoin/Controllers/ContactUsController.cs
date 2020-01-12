using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Rejoin.ViewModels;
using Rejoin.Models;
using Rejoin.Data;


namespace Rejoin.Controllers
{
    public class ContactUsController : BaseController
    {
        private readonly RejionDBContext _context;
        
        //constructor of contactuscontroller
        public ContactUsController(RejionDBContext context):base(context)
        {
            _context = context;
        }

        //returns the conact page
        public IActionResult Index()
        {
            //to show the breadcrumb of contact page
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

        //send message to ceo
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

            //to show the breadcrumb of home page after sending message
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