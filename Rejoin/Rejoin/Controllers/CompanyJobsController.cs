using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rejoin.Data;
using Rejoin.Injections;
using Rejoin.ViewModels;

using Rejoin.Models;

namespace Rejoin.Controllers
{
    public class CompanyJobsController : BaseController
    {
        private readonly RejionDBContext _context;
        private readonly IAuth _auth;

        //controller of companjobscontroller
        public CompanyJobsController(IAuth auth, RejionDBContext context):base(context)
        {
            _auth = auth;
            _context = context;
        }

        //returns the advertisements of company
        public IActionResult Index()
        {
            if (_auth.User == null || _auth.User.UserType == UserType.Employee)
            {
                return View("~/Views/Shared/NotFound.cshtml");
            }

            //to show the breadcrumb of companyjobs
            BreadCrumbViewModel breadCrumb = new BreadCrumbViewModel
            {
                Title = "Elanlarım",
                Parents = new Dictionary<string, List<string>>()
                {
                    { "Ana səhifə", new List<string>() { "home", "index" } },
                    { "Profilim", new List<string>() { "companydashboard", "index" } },
                }
            };
            ViewBag.BreadCrumb = breadCrumb;
            ViewBag.Jobs = _context.Jobs.Include("Company").Where(j => j.CompanyId == _auth.User.Company.Id).OrderByDescending(j=>j.CreatedAt).ToList();
            return View();
        }
    }
}