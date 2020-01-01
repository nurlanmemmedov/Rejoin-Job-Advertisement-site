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
using Rejoin.ViewModels;

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

        [HttpPost]
        public IActionResult CreateCompanyProfil(CompanyViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = string.Empty;
                if (model.Upload != null)
                {
                    string uploadsFolder = Path.Combine(_env.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Upload.FileName;
                    string FilePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Upload.CopyTo(new FileStream(FilePath, FileMode.Create));
                }
                Company company = new Company
                {
                    Name = model.Name,
                    Email = model.Email,
                    Website = model.Website,
                    Phone = model.Phone,
                    Location = model.Location,
                    UserId = _auth.User.Id,
                    Info = model.Info,
                    Photo = uniqueFileName
                };

                _context.Companies.Add(company);
                _context.SaveChanges();
                return RedirectToAction("index", "companydashboard");
            }
            return View("~/Views/CompanyDashboard/index.cshtml");
        }

        public IActionResult EditCompany(CompanyViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = string.Empty;
                if (model.Upload != null)
                {
                    string uploadsFolder = Path.Combine(_env.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Upload.FileName;
                    string FilePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Upload.CopyTo(new FileStream(FilePath, FileMode.Create));
                }
                Company company = _context.Companies.FirstOrDefault(c => c.UserId == _auth.User.Id);

                company.Name = model.Name;
                company.Email = model.Email;
                company.Website = model.Website;
                company.Phone = model.Phone;
                company.Location = model.Location;
                company.UserId = _auth.User.Id;
                company.Info = model.Info;
                company.Photo = uniqueFileName;


                
                _context.SaveChanges();
                return RedirectToAction("index", "companydashboard");
            }
            return View("~/Views/CompanyDashboard/index.cshtml");
        }
    }
}