using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rejoin.ViewModels;
using Rejoin.Data;

namespace Rejoin.Controllers
{
    public class AboutController : BaseController
    {
        private readonly RejionDBContext _context;

        public AboutController(RejionDBContext context):base(context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            BreadCrumbViewModel breadCrumb = new BreadCrumbViewModel
            {
                Title = "Haqqımızda",
                Parents = new Dictionary<string, List<string>>()
                    {
                        { "Ana səhifə", new List<string>() { "home", "index" } },
                    }
            };
            ViewBag.BreadCrumb = breadCrumb;
            ViewBag.Users = _context.Users.ToList();
            ViewBag.Candidates = _context.Candidates.ToList();
            ViewBag.Companies = _context.Companies.ToList();
            ViewBag.Jobs = _context.Jobs.ToList();
            return View();
        }
    }
}