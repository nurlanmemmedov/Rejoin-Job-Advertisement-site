using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Rejoin.Injections;
using Rejoin.Data;
using Microsoft.EntityFrameworkCore;

namespace Rejoin.Controllers
{
    public class HomeController : BaseController
    {
        private readonly RejionDBContext _context;
        private readonly IAuth _auth;
        
        //constructor of homecontroller
        public HomeController(IAuth auth, RejionDBContext context):base(context)
        {
            _auth = auth;
            _context = context;
        }

        //returns the home page
        public IActionResult Index()
        {
            ViewBag.LatestJobs = _context.Jobs.Include("Company").OrderByDescending(j=>j.CreatedAt).Take(12).ToList();
            ViewBag.TopCandidates = _context.Candidates.OrderByDescending(c=>c.ExperienceTime).Take(12).ToList();

            //to shows data in statistic part
            ViewBag.Categories = _context.Categories.Include(c=>c.Jobs).ToList();
            ViewBag.Users = _context.Users.ToList();
            ViewBag.Candidates = _context.Candidates.ToList();
            ViewBag.Companies = _context.Companies.ToList();
            ViewBag.Jobs = _context.Jobs.ToList();
            return View();
        }
    }
}
