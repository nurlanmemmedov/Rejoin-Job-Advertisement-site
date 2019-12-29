using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Rejoin.Controllers
{
    public class CompanyJobsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}