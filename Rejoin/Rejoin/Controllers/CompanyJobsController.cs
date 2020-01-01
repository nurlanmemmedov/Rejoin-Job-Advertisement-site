using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rejoin.Data;
using Rejoin.Injections;

namespace Rejoin.Controllers
{
    public class CompanyJobsController : Controller
    {
        private readonly RejionDBContext _context;
        private readonly IAuth _auth;
        public CompanyJobsController(IAuth auth, RejionDBContext context)
        {
            _auth = auth;
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Jobs = _context.Jobs.Include("Company").Where(j => j.CompanyId == _auth.User.Company.Id).ToList();
            return View();
        }
    }
}