﻿using System;
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

        public IActionResult Index(int? JobId)
        {
            if(JobId != null)
            {
                Job job = _context.Jobs.Find(JobId);
                ViewBag.Job = job;
            }
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
                    CompanyId = _auth.User.Company.Id,
                    isActive = true
                };
                _context.Jobs.Add(job);
                _context.SaveChanges();
                return RedirectToAction("index", "home");
            }
            return RedirectToAction("~Views/SubmitJob/Index.cshtml");

        }



        [HttpPost]
        public IActionResult EditJob(JobViewModel jobViewModel, int? JobId)
        {

            if (ModelState.IsValid)
            {
                Job job = _context.Jobs.FirstOrDefault(j => j.Id == JobId);

                job.Title = jobViewModel.Title;
                job.City = jobViewModel.City;
                job.CreatedAt = DateTime.Now;
                job.ViewCount = 0;
                job.LikeCount = 0;
                job.Address = jobViewModel.Address;
                job.Description = jobViewModel.Description;
                job.JobType = jobViewModel.JobType;
                job.MinSalary = jobViewModel.MinSalary;
                job.MaxSalary = jobViewModel.MaxSalary;
                job.MaxExperience = jobViewModel.MaxExperience;
                job.MinExperience = jobViewModel.MinExperience;
                job.CategoryId = 1;
                job.CompanyId = _auth.User.Company.Id;
                job.isActive = true;
                _context.SaveChanges();
                return RedirectToAction("index", "CompanyJobs");
            }
            return RedirectToAction("~Views/SubmitJob/index.cshtml");

        }

        public IActionResult ChangeStatus(int JobId)
        {
            Job job = _context.Jobs.FirstOrDefault(j => j.Id == JobId);
            if(job.isActive == true)
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