using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rejoin.Injections;
using Rejoin.Models;
using Rejoin.Data;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Rejoin.ViewModels;

namespace Rejoin.Controllers
{
    public class SubmitJobController : Controller
    {
        private readonly RejionDBContext _context;
        private readonly IAuth _auth;
        private readonly IWebHostEnvironment _env;
        public SubmitJobController(IAuth auth, RejionDBContext context, IWebHostEnvironment env)
        {
            _auth = auth;
            _env = env;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Categories = _context.Categories.ToList();
            if (_auth.User == null)
            {
                return RedirectToAction("index", "register");
            }
            if (_context.Companies.FirstOrDefault(c => c.UserId == _auth.User.Id) == null)
            {
                return PartialView("~/Views/Shared/_CreateCompany.cshtml");
            }
         
            return View();
        }


     

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
                    LikeCount = 0,
                    Address = jobViewModel.Address,
                    Description = jobViewModel.Description,
                    JobType = jobViewModel.JobType,
                    MinSalary = jobViewModel.MinSalary,
                    MaxSalary = jobViewModel.MaxSalary,
                    MaxExperience = jobViewModel.MaxExperience,
                    MinExperience = jobViewModel.MinExperience,
                    CategoryId = 1,
                    CompanyId = _auth.User.Company.Id
                };
                _context.Jobs.Add(job);
                _context.SaveChanges();
                return RedirectToAction("index", "home");
            }
            return Ok("sehvsen qaqa");
        }

    }
}