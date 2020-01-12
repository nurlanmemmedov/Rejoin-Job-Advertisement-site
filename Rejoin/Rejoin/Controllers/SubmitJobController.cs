using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Rejoin.Injections;
using Rejoin.Models;
using Rejoin.Data;
using Microsoft.AspNetCore.Hosting;
using Rejoin.ViewModels;

namespace Rejoin.Controllers
{
    public class SubmitJobController : BaseController
    {
        //injections
        private readonly RejionDBContext _context;
        private readonly IAuth _auth;
        private readonly IWebHostEnvironment _env;
        public SubmitJobController(IAuth auth, RejionDBContext context, IWebHostEnvironment env) : base(context)
        {
            _auth = auth;
            _env = env;
            _context = context;
        }
        //Submit job, if jobId is not null return edit job view, otherwise submiting job view
        public IActionResult Index(int? JobId)
        {
            if (_auth.User == null)
            {
                return RedirectToAction("register", "account");
            }
            if (_context.Companies.FirstOrDefault(c => c.UserId == _auth.User.Id) == null)
            {
                return PartialView("~/Views/Shared/_CreateCompany.cshtml");
            }
            if (_auth.User.UserType == UserType.Employee)
            {
                return View("~/Views/Shared/NotFound.cshtml");
            }

            if (JobId != null)
            {
                if (!_context.Jobs.Any(j => j.Id == JobId))
                {
                    return View("~/Views/Shared/NotFound.cshtml");
                }

                Job job = _context.Jobs.Find(JobId);
                ViewBag.Job = job;

                //to show breadcrumb of editjob page
                BreadCrumbViewModel breadCrumb = new BreadCrumbViewModel
                {
                    Title = "Elanı redaktə et",
                    Parents = new Dictionary<string, List<string>>()
                    {
                         { "Ana səhifə", new List<string>() { "home", "index" } },
                         { "Profilim", new List<string>() { "companydashboard", "index" } },
                         { "Elanlarım", new List<string>() { "companyjobs", "index" } },
                    }
                };
                ViewBag.BreadCrumb = breadCrumb;
            }
            else
            {
                //to show breadcrumb of submitjob page
                BreadCrumbViewModel breadCrumb = new BreadCrumbViewModel
                {
                    Title = "İş elanı ver",
                    Parents = new Dictionary<string, List<string>>()
                    {
                        { "Ana səhifə", new List<string>() { "home", "index" } },
                    }
                };
                ViewBag.BreadCrumb = breadCrumb;
            }

            //to show the categories in view
            ViewBag.Categories = _context.Categories.ToList();

            //if not any user logined redirect to register page
        


            return View();
        }

        //create job
        [HttpPost]
        public IActionResult CreateJob(JobViewModel jobViewModel)
        {

            if (ModelState.IsValid)
            {
                Job job = new Job
                {
                    Title = jobViewModel.Title,
                    City = jobViewModel.City,
                    CreatedAt = DateTime.Now,
                    ViewCount = 0,
                    Address = jobViewModel.Address,
                    Description = jobViewModel.Description,
                    JobType = jobViewModel.JobType,
                    MinSalary = jobViewModel.MinSalary,
                    MaxSalary = jobViewModel.MaxSalary,
                    MaxExperience = jobViewModel.MaxExperience,
                    MinExperience = jobViewModel.MinExperience,
                    CategoryId = 1,
                    CompanyId = _auth.User.Company.Id,
                    isActive = true
                };
                _context.Jobs.Add(job);
                _context.SaveChanges();
                return RedirectToAction("index", "CompanyJobs");
            }
            //to show the breadcrumb of submitjob
            BreadCrumbViewModel breadCrumb = new BreadCrumbViewModel
            {
                Title = "İş elanı ver",
                Parents = new Dictionary<string, List<string>>()
                    {
                        { "Ana səhifə", new List<string>() { "home", "index" } },
                    }
            };
            ViewBag.BreadCrumb = breadCrumb;

            ViewBag.Categories = _context.Categories.ToList();
            return View("~/Views/SubmitJob/Index.cshtml");

        }

        //edit job
        [HttpPost]
        public IActionResult EditJob(JobViewModel jobViewModel, int? JobId)
        {
            if (_auth.User == null || _auth.User.UserType == UserType.Employee)
            {
                return View("~/Views/Shared/NotFound.cshtml");
            }
            if (!_context.Jobs.Any(j=>j.Id == JobId))
            {
                return View("~/Views/Shared/NotFound.cshtml");
            }

            if (ModelState.IsValid)
            {
                Job job = _context.Jobs.FirstOrDefault(j => j.Id == JobId);

                job.Title = jobViewModel.Title;
                job.City = jobViewModel.City;
                job.Address = jobViewModel.Address;
                job.Description = jobViewModel.Description;
                job.JobType = jobViewModel.JobType;
                job.MinSalary = jobViewModel.MinSalary;
                job.MaxSalary = jobViewModel.MaxSalary;
                job.MaxExperience = jobViewModel.MaxExperience;
                job.MinExperience = jobViewModel.MinExperience;
                job.CategoryId = jobViewModel.CategoryId;
                job.CompanyId = _auth.User.Company.Id;
                job.isActive = true;

                _context.SaveChanges();
                return RedirectToAction("index", "CompanyJobs");
            }
            ViewBag.Categories = _context.Categories.ToList();

            //to show the breadcrumb of editingjob
            BreadCrumbViewModel breadCrumb = new BreadCrumbViewModel
            {
                Title = "Elanı redaktə et",
                Parents = new Dictionary<string, List<string>>()
                    {
                         { "Ana səhifə", new List<string>() { "home", "index" } },
                         { "Profilim", new List<string>() { "companydashboard", "index" } },
                         { "Elanlarım", new List<string>() { "companyjobs", "index" } },
                    }
            };
            ViewBag.BreadCrumb = breadCrumb;

            return View("~/Views/SubmitJob/Index.cshtml");

        }

        //change status of job
        public IActionResult ChangeStatus(int JobId)
        {
            if (_auth.User == null || _auth.User.UserType == UserType.Employee)
            {
                return View("~/Views/Shared/NotFound.cshtml");
            }

            if (!_context.Jobs.Any(j => j.Id == JobId))
            {
                return View("~/Views/Shared/NotFound.cshtml");
            }

            Job job = _context.Jobs.FirstOrDefault(j => j.Id == JobId);
            if (job.isActive == true)
            {
                job.isActive = false;
            }
            else
            {
                job.isActive = true;
            }
            _context.SaveChanges();
            return RedirectToAction("index", "companyjobs");
        }

    }
}