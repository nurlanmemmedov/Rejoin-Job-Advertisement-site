using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rejoin.Data;
using Rejoin.Models;
using Rejoin.ViewModels;


namespace Rejoin.Controllers
{
    public class JobDetailsController : Controller
    {
        private readonly RejionDBContext _context;
        public JobDetailsController(RejionDBContext context)
        {
            _context = context;
        }
        public IActionResult Index(int JobId)
        {
            Job job = _context.Jobs.Include("JobReviews").Include("Company").Include("Category").FirstOrDefault(j => j.Id == JobId);
            job.ViewCount++;
            _context.SaveChanges();
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.All = _context.Jobs.ToList();
            ViewBag.Job = job;
            ViewBag.RelatedJobs = _context.Jobs.Include("Company").Where(j => j.CategoryId == job.CategoryId && j.Id != job.Id).ToList();
            return View();
        }
    }
}