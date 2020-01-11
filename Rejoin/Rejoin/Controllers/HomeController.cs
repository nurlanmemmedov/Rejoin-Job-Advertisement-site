using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rejoin.Models;
using Rejoin.Injections;
using Rejoin.ViewModels;
using Rejoin.Data;
using Microsoft.EntityFrameworkCore;

namespace Rejoin.Controllers
{
    public class HomeController : BaseController
    {
        private readonly RejionDBContext _context;
        private readonly IAuth _auth;
        public HomeController(IAuth auth, RejionDBContext context):base(context)
        {
            _auth = auth;
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.LatestJobs = _context.Jobs.Include("Company").OrderByDescending(j=>j.CreatedAt).Take(12).ToList();
            ViewBag.TopCandidates = _context.Candidates.OrderByDescending(c=>c.ExperienceTime).Take(12).ToList();

            ViewBag.Categories = _context.Categories.Include("Jobs").ToList();
            ViewBag.Users = _context.Users.ToList();
            ViewBag.Candidates = _context.Candidates.ToList();
            ViewBag.Companies = _context.Companies.ToList();
            ViewBag.Jobs = _context.Jobs.ToList();
            return View();
        }
    }
}
