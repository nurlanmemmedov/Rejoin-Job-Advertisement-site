using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Rejoin.Data;
using Rejoin.Injections;
using Rejoin.Models;
using Rejoin.ViewModels;

namespace Rejoin.Controllers
{
    public class CompanyDashboardController : BaseController
    {
        private readonly RejionDBContext _context;
        private readonly IAuth _auth;
        private readonly IFileManager _fileManager;
        private readonly IWebHostEnvironment _env;

        public CompanyDashboardController(IAuth auth, RejionDBContext context, IWebHostEnvironment env, IFileManager fileManager):base(context)
        {
            _auth = auth;
            _env = env;
            _fileManager = fileManager;
            _context = context;
        }

        //returns the view for dashboard of company
        public IActionResult Index()
        {
            if (_auth.User == null || _auth.User.UserType == UserType.Employee)
            {
                return View("~/Views/Shared/NotFound.cshtml");
            }

            //to show the breadcrumb of company dashboard
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


        //returns modal to create company profile if company doesnt have company profile
        [HttpPost]
        public JsonResult CreateCompany(Company company)
        {
            //upload the picture to company profile
            if (company.Upload != null)
            {
                try
                {
                    company.Photo = _fileManager.Upload(company.Upload);

                }
                catch(Exception e)
                {
                    //if upload is not image or is greater than 1 mb returns bad request
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


        //creates the company profile
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

            //to show breadcrumb of companydashboard
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


        //edit the company profile
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

            //to show the breadcrumb of companydashboard
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