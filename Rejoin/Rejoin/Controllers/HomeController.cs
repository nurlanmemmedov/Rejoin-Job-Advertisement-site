using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rejoin.Models;
using Rejoin.Injections;


namespace Rejoin.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuth _auth;
        public HomeController(IAuth auth)
        {
            _auth = auth;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
