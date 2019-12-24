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
    public class HomeController : Controller
    {
        private readonly RejionDBContext _context;
        private readonly IAuth _auth;
        public HomeController(IAuth auth, RejionDBContext context)
        {
            _auth = auth;
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Jobs = _context.Jobs.Include("Company").ToList();
            return View();
        }
    }
}
