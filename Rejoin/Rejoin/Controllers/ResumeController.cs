using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Rejoin.ViewModels;
using Rejoin.Models;
using Rejoin.Injections;
using Rejoin.Data;
using Microsoft.AspNetCore.Hosting;

namespace Rejoin.Controllers
{
    public class ResumeController : BaseController
    {
        private readonly RejionDBContext _context;
        private readonly IAuth _auth;
        private readonly IWebHostEnvironment _env;
        private readonly IFileManager _fileManager;

        //constructor of resumecontroller
        public ResumeController(RejionDBContext context, IAuth auth, IWebHostEnvironment env, IFileManager fileManager) : base(context)
        {
            _context = context;
            _auth = auth;
            _env = env;
            _fileManager = fileManager;
        }

        //returns cv page
        public IActionResult Index()
        {
            if (_auth.User == null)
            {
                return RedirectToAction("register", "account");
            }

            if (_auth.User.UserType == UserType.Company)
            {
                return View("~/Views/Shared/NotFound.cshtml");
            }

            //to show the breadcrumb of CV page
            BreadCrumbViewModel breadCrumb = new BreadCrumbViewModel
            {
                Title = "CV",
                Parents = new Dictionary<string, List<string>>()
                {
                    { "Ana səhifə", new List<string>() { "home", "index" } },
                }
            };
            ViewBag.BreadCrumb = breadCrumb;
            return View();
        }

        //create resume for employees
        [HttpPost]
        public JsonResult CreateResume(ResumeViewModel model)
        {
            Candidate candidate = new Candidate();

            //to upload the browsing image 
            if (model.Upload != null)
            {
                try
                {
                    candidate.Photo = _fileManager.Upload(model.Upload);

                }
                catch (Exception e)
                {
                    return Json(new
                    {
                        status = "OK",
                        StatusCode = 500,
                        message = "melumatlar yanlisdir",
                        data = candidate.Photo
                    });
                }
            }

            //information of resume
            candidate.Name = model.Name;
            candidate.Lastname = model.Lastname;
            candidate.Email = model.Email;
            candidate.Phone = model.Phone;
            candidate.Profession = model.Profession;
            candidate.ExperienceTime = model.ExperienceTime;
            candidate.UserId = _auth.User.Id;
            candidate.PersonalSkill = model.PersonalSkill;

            _context.Candidates.Add(candidate);
            _context.SaveChanges();

            //if experiences of resume not null create the experience model 
            if (model.Experiences != null)
            {
                for (var i = 0; i < model.Experiences.Count; i++)
                {

                    Experience experience = new Experience
                    {
                        CompanyName = model.Experiences[i].CompanyName,
                        StartedAt = model.Experiences[i].StartedAt,
                        FinishedAt = model.Experiences[i].FinishedAt,
                        CandidateId = candidate.Id,
                        Position = model.Experiences[i].Position,
                    };
                    _context.Experiences.Add(experience);
                }
            }

            //if educations of resume not null create the education model 
            if (model.Educations != null)
            {
                for (var i = 0; i < model.Educations.Count; i++)
                {
                    Education education = new Education
                    {
                        SchoolName = model.Educations[i].SchoolName,
                        StartedAt = model.Educations[i].StartedAt,
                        FinishedAt = model.Educations[i].FinishedAt,
                        CandidateId = candidate.Id,
                        University = model.Educations[i].University,
                        Qualification = model.Educations[i].Qualification
                    };
                    _context.Educations.Add(education);
                }
            }

            _context.SaveChanges();

            return Json(new
            {
                status = "OK",
                code = 200,
                message = "added Cv",
                data = model,
                redirectUrl = Url.Action("Index", "Home"),
                isRedirect = true
            });

        }

        [HttpPost]
        public JsonResult EditResume(ResumeViewModel model)
        {


            Candidate candidate = _context.Candidates.Find(_auth.User.Candidate.Id);

            if (model.Upload != null)
            {
                try
                {
                    candidate.Photo = _fileManager.Upload(model.Upload);

                }
                catch (Exception e)
                {
                    return Json(new
                    {
                        status = "OK",
                        StatusCode = 500,
                        message = "melumatlar yanlisdir",
                        data = candidate.Photo
                    });
                }
            }

            candidate.Name = model.Name;
            candidate.Lastname = model.Lastname;
            candidate.Email = model.Email;
            candidate.Phone = model.Phone;
            candidate.Profession = model.Profession;
            candidate.ExperienceTime = model.ExperienceTime;
            candidate.UserId = _auth.User.Id;
            candidate.PersonalSkill = model.PersonalSkill;
            _context.SaveChanges();

            
            var experiences = _context.Experiences.Where(e => e.CandidateId == _auth.User.Candidate.Id).ToList();
            //if experiences of resume not null create the experience model 
            if (model.Experiences != null)
            {
                if (model.Experiences.Count == experiences.Count)
                {
                    for (var j = 0; j < experiences.Count; j++)
                    {
                        experiences[j].CompanyName = model.Experiences[j].CompanyName;
                        experiences[j].StartedAt = model.Experiences[j].StartedAt;
                        experiences[j].FinishedAt = model.Experiences[j].FinishedAt;
                        experiences[j].CandidateId = candidate.Id;
                        experiences[j].Position = model.Experiences[j].Position;
                    }
                }
                else if (model.Experiences.Count > experiences.Count)
                {
                    for (var j = 0; j < experiences.Count; j++)
                    {
                        experiences[j].CompanyName = model.Experiences[j].CompanyName;
                        experiences[j].StartedAt = model.Experiences[j].StartedAt;
                        experiences[j].FinishedAt = model.Experiences[j].FinishedAt;
                        experiences[j].Position = model.Experiences[j].Position;
                    }
                    for (var k = experiences.Count; k < model.Experiences.Count; k++)
                    {
                        Experience experience = new Experience
                        {
                            CompanyName = model.Experiences[k].CompanyName,
                            StartedAt = model.Experiences[k].StartedAt,
                            FinishedAt = model.Experiences[k].FinishedAt,
                            CandidateId = candidate.Id,
                            Position = model.Experiences[k].Position
                        };
                        _context.Experiences.Add(experience);
                    }

                }
                else if (experiences.Count > model.Experiences.Count)
                {

                    for (var j = 0; j < model.Experiences.Count; j++)
                    {
                        experiences[j].CompanyName = model.Experiences[j].CompanyName;
                        experiences[j].StartedAt = model.Experiences[j].StartedAt;
                        experiences[j].FinishedAt = model.Experiences[j].FinishedAt;
                        experiences[j].CandidateId = candidate.Id;
                        experiences[j].Position = model.Experiences[j].Position;
                    }
                    for (var t = model.Experiences.Count; t < experiences.Count; t++)
                    {
                        _context.Experiences.Remove(experiences[t]);
                    }

                }

            }
            else if (model.Experiences == null)
            {
                for (var t = 0; t < experiences.Count; t++)
                {
                    _context.Experiences.Remove(experiences[t]);
                }
            }
            
            var educations = _context.Educations.Where(e => e.CandidateId == _auth.User.Candidate.Id).ToList();
            //if educations of resume not null create the education model 
            if (model.Educations != null)
            {
                if (model.Educations.Count == educations.Count)
                {
                    for (var j = 0; j < educations.Count; j++)
                    {
                        educations[j].SchoolName = model.Educations[j].SchoolName;
                        educations[j].StartedAt = model.Educations[j].StartedAt;
                        educations[j].FinishedAt = model.Educations[j].FinishedAt;
                        educations[j].CandidateId = candidate.Id;
                        educations[j].Qualification = model.Educations[j].Qualification;
                        educations[j].University = model.Educations[j].University;
                    }
                }
                else if (model.Educations.Count > educations.Count)
                {
                    for (var j = 0; j < educations.Count; j++)
                    {
                        educations[j].SchoolName = model.Educations[j].SchoolName;
                        educations[j].StartedAt = model.Educations[j].StartedAt;
                        educations[j].FinishedAt = model.Educations[j].FinishedAt;
                        educations[j].Qualification = model.Educations[j].Qualification;
                        educations[j].University = model.Educations[j].University;
                    }
                    for (var k = educations.Count; k < model.Educations.Count; k++)
                    {
                        Education education = new Education
                        {
                            SchoolName = model.Educations[k].SchoolName,
                            StartedAt = model.Educations[k].StartedAt,
                            FinishedAt = model.Educations[k].FinishedAt,
                            CandidateId = candidate.Id,
                            Qualification = model.Educations[k].Qualification,
                            University = model.Educations[k].University,
                        };
                        _context.Add(education);
                    }

                }
                else if (educations.Count > model.Educations.Count)
                {
                    for (var j = 0; j < model.Educations.Count; j++)
                    {
                        educations[j].SchoolName = model.Educations[j].SchoolName;
                        educations[j].StartedAt = model.Educations[j].StartedAt;
                        educations[j].FinishedAt = model.Educations[j].FinishedAt;
                        educations[j].CandidateId = candidate.Id;
                        educations[j].Qualification = model.Educations[j].Qualification;
                        educations[j].University = model.Educations[j].University;
                    }
                    for (var t = model.Educations.Count; t < educations.Count; t++)
                    {
                        _context.Educations.Remove(educations[t]);
                    }

                }
            }
            else if (model.Educations == null)
            {
                for (var t = 0; t < educations.Count; t++)
                {
                    _context.Educations.Remove(educations[t]);
                }
            }

            _context.SaveChanges();

            return Json(new
            {
                status = "OK",
                code = 200,
                message = "added product",
                data = model,
                redirectUrl = Url.Action("Index", "Home"),
                isRedirect = true
            });

        }


    }
}