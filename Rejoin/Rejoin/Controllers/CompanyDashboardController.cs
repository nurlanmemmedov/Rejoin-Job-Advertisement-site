using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Rejoin.Data;
using Rejoin.Injections;
using Rejoin.Models;

namespace Rejoin.Controllers
{
    public class CompanyDashboardController : Controller
    {
        private readonly RejionDBContext _context;
        private readonly IAuth _auth;
        private readonly IWebHostEnvironment _env;
        public CompanyDashboardController(IAuth auth, RejionDBContext context, IWebHostEnvironment env)
        {
            _auth = auth;
            _env = env;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CreateCompany(Company company)
        {
            string uniqueFileName = string.Empty;
            if (company.Upload != null)
            {
                string uploadsFolder = Path.Combine(_env.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + company.Upload.FileName;
                string FilePath = Path.Combine(uploadsFolder, uniqueFileName);
                company.Upload.CopyTo(new FileStream(FilePath, FileMode.Create));
            }
            company.UserId = _auth.User.Id;
            company.Photo = uniqueFileName;
            _context.Companies.Add(company);
            _context.SaveChanges();
            return Json(new
            {
                status = "OK",
                code = 200,
                message = "added product",
                data = company
            });
        }
    }
}