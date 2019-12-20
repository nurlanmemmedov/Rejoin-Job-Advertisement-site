﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rejoin.ViewModels;
using Rejoin.Models;
using Rejoin.Injections;


using Rejoin.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Rejoin.Controllers
{
    public class ResumeController : Controller
    {
        private readonly RejionDBContext _context;
        private readonly IAuth _auth;
        private readonly IWebHostEnvironment _env;

        public ResumeController(RejionDBContext context, IAuth auth, IWebHostEnvironment env)
        {
            _context = context;
            _auth = auth;
            _env = env;
        }

        public IActionResult Index()
        {
            if(_auth.User == null)
            {
                return RedirectToAction("index", "register");
            }
            return View();
        }

        [HttpPost]
        public IActionResult CreateResume(CreateResumeViewModel createResume)
        {
            if (ModelState.IsValid)
            {
                
                string uniqueFileName = string.Empty;
                if (createResume.Resume.Upload != null)
                {
                    string uploadsFolder = Path.Combine(_env.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + createResume.Resume.Upload.FileName;
                    string FilePath = Path.Combine(uploadsFolder, uniqueFileName);
                    createResume.Resume.Upload.CopyTo(new FileStream(FilePath, FileMode.Create));
                }
                Candidate candidate = new Candidate
                {
                    Name = createResume.Resume.Name,
                    Lastname = createResume.Resume.Lastname,
                    Profession = createResume.Resume.Profession,
                    ExperienceTime = createResume.Resume.ExperienceTime,
                    Email = createResume.Resume.Email,
                    Phone = createResume.Resume.Phone,
                    PersonalSkill = createResume.Resume.PersonalSkill,
                    UserId = _auth.User.Id,
                    Photo = uniqueFileName
                };
                //if (_context.Candidates.FirstOrDefault(c => c.UserId == candidate.UserId) == null)
                //{
                    _context.Candidates.Add(candidate);
                    _context.SaveChanges();
                    Education education = new Education
                    {
                        SchoolName = createResume.Education.SchoolName,
                        Qualification = createResume.Education.Qualification,
                        StartedAt = createResume.Education.StartedAt,
                        FinishedAt = createResume.Education.FinishedAt,
                        University = createResume.Education.University,
                        CandidateId = candidate.Id
                    };
                    Experience experience = new Experience
                    {
                        CompanyName = createResume.Experience.CompanyName,
                        Position = createResume.Experience.Position,
                        StartedAt = createResume.Experience.StartedAt,
                        FinishedAt = createResume.Experience.FinishedAt,
                        CandidateId = candidate.Id
                    };
                    _context.Experiences.Add(experience);
                    _context.Educations.Add(education);
                    _context.SaveChanges();
                    return RedirectToAction("index", "home");
          
            }
            return RedirectToAction("~Views/Resume/index.cshtml");
        }
    }
}