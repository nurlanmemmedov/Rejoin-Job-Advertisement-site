using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rejoin.Data;
using Rejoin.Injections;
using Rejoin.ViewModels;

namespace Rejoin.Controllers
{
    public class CompanyJobsController : BaseController
    {
        private readonly RejionDBContext _context;
        private readonly IAuth _auth;
        public CompanyJobsController(IAuth auth, RejionDBContext context):base(context)
        {
            _auth = auth;
            _context = context;
        }
        public IActionResult Index()
        {
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
            ViewBag.Jobs = _context.Jobs.Include("Company").Where(j => j.CompanyId == _auth.User.Company.Id).ToList();
            return View();
        }
    }
}