﻿using System;
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
    public class AppliedCandidatesController : Controller
    {
        private readonly RejionDBContext _context;
        public AppliedCandidatesController(RejionDBContext context)
        {
            _context = context;
        }
        public IActionResult Index(int JobId)
        {
            List<ApplyViewModel> applies = new List<ApplyViewModel>();

            foreach (Apply item in _context.Applies.Include("Candidate").Include("Job").Where(a=>a.JobId == JobId).ToList())
            {
                ApplyViewModel applyViewModel = new ApplyViewModel
                {
                    WhyYou = item.WhyYou,
                    JobId = item.JobId,
                    CandidateId = item.CandidateId,
                    Candidate = _context.Candidates.Include("Educations").Include("Experiences").FirstOrDefault(c=>c.Id == item.CandidateId),
                    Job = _context.Jobs.FirstOrDefault(j=>j.Id == item.JobId)
                };
                applies.Add(applyViewModel);
            }
            ViewBag.Applies = applies;

            return View();
        }
    }
}