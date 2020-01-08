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
        private readonly IFileManager _fileManager;
        private readonly IWebHostEnvironment _env;

        public CompanyDashboardController(IAuth auth, RejionDBContext context, IWebHostEnvironment env, IFileManager fileManager)
        {
            _auth = auth;
            _env = env;
            _fileManager = fileManager;
            _context = context;
        }
        public IActionResult Index()
        {
            BreadCrumbViewModel breadCrumb = new BreadCrumbViewModel
            {
                Title = "Profilim",
                Parents = new Dictionary<string, List<string>>()
                {
                    { "Ana səhifə", new List<string>() { "home", "index" } },
                }
            };
            ViewBag.BreadCrumb = breadCrumb;
            return View();
        }

        [HttpPost]
        public JsonResult CreateCompany(Company company)
        {

            if (company.Upload != null)
            {
                try
                {
                    company.Photo = _fileManager.Upload(company.Upload);

                }
                catch(Exception e)
                {
                    return Json(new
                    {
                        status = "OK",
                        StatusCode = 500,
                        message = "Şirkət profili yaradıldı",
                        data = "sirket"
                    }) ; 
                }
            }
            company.UserId = _auth.User.Id;
            _context.Companies.Add(company);
            _context.SaveChanges();
            return Json(new
            {
                status = "OK",
                code = 200,
                message = "Şirkət profili yaradıldı",
                data = company
            });


        }

        [HttpPost]
        public IActionResult CreateCompanyProfil(CompanyViewModel model)
        {
            Company company = new Company();
            if (model.Upload != null)
            {
                try
                {
                    company.Photo = _fileManager.Upload(model.Upload);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("Upload",e.Message );
                }
            }
            if (ModelState.IsValid)
            {
                company.Name = model.Name;
                company.Email = model.Email;
                company.Website = model.Website;
                company.Phone = model.Phone;
                company.Location = model.Location;
                company.UserId = _auth.User.Id;
                company.Info = model.Info;

                _context.Companies.Add(company);
                _context.SaveChanges();

                return RedirectToAction("index", "companydashboard");
            }

            BreadCrumbViewModel breadCrumb = new BreadCrumbViewModel
            {
                Title = "Profilim",
                Parents = new Dictionary<string, List<string>>()
                {
                    { "Ana səhifə", new List<string>() { "home", "index" } },
                }
            };
            ViewBag.BreadCrumb = breadCrumb;

            return View("~/Views/CompanyDashboard/index.cshtml");
        }

        public IActionResult EditCompany(CompanyViewModel model)
        {
            Company company = _context.Companies.FirstOrDefault(c => c.UserId == _auth.User.Id);
            if (model.Upload != null)
            {
                try
                {
                    company.Photo = _fileManager.Upload(model.Upload);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("Upload", e.Message);

                }
            }
            if (ModelState.IsValid)
            {


                company.Name = model.Name;
                company.Email = model.Email;
                company.Website = model.Website;
                company.Phone = model.Phone;
                company.Location = model.Location;
                company.UserId = _auth.User.Id;
                company.Info = model.Info;

                _context.SaveChanges();
                return RedirectToAction("index", "companydashboard");
            }

            BreadCrumbViewModel breadCrumb = new BreadCrumbViewModel
            {
                Title = "Profilim",
                Parents = new Dictionary<string, List<string>>()
                {
                    { "Ana səhifə", new List<string>() { "home", "index" } },
                }
            };
            ViewBag.BreadCrumb = breadCrumb;

            return View("~/Views/CompanyDashboard/index.cshtml");
        }
    }
}