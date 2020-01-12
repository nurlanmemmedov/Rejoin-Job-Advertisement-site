using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rejoin.Data;
using Rejoin.Injections;
using Rejoin.Models;
using Rejoin.ViewModels;


namespace Rejoin.Controllers
{
    public class AppliedCandidatesController : BaseController
    {
        private readonly RejionDBContext _context;
        private readonly IAuth _auth;
        public AppliedCandidatesController(RejionDBContext context, IAuth auth) : base(context)
        {
            _context = context;
            _auth = auth;
        }

        //to show the applies of job for companies
        public IActionResult Index(int JobId)
        {
            if(_auth.User == null || _auth.User.UserType == UserType.Employee)
            {
                return View("~/Views/Shared/NotFound.cshtml");
            }

            if (!_context.Jobs.Any(j => j.Id == JobId))
            {
                return View("~/Views/Shared/NotFound.cshtml");
            }

            List<ApplyViewModel> applies = new List<ApplyViewModel>();

            foreach (Apply item in _context.Applies.Include("Candidate").Include("Job").Where(a => a.JobId == JobId).ToList())
            {
                ApplyViewModel applyViewModel = new ApplyViewModel
                {
                    WhyYou = item.WhyYou,
                    JobId = item.JobId,
                    CandidateId = item.CandidateId,
                    Candidate = _context.Candidates.Include("Educations").Include("Experiences").FirstOrDefault(c => c.Id == item.CandidateId),
                    Job = _context.Jobs.FirstOrDefault(j => j.Id == item.JobId)
                };
                applies.Add(applyViewModel);
            }
            ViewBag.Applies = applies;


            //to show the breadcrumb of apply page
            BreadCrumbViewModel breadCrumb = new BreadCrumbViewModel
            {
                Title = "Müraciətlər",
                Parents = new Dictionary<string, List<string>>()
                {
                    { "Ana səhifə", new List<string>() { "home", "index" } },
                    { "Profilim", new List<string>() { "companydashboard", "index" } },
                    { "Elanlarım", new List<string>() { "companyjobs", "index" } },
                }
            };
            ViewBag.BreadCrumb = breadCrumb;

            return View();
        }
    }
}