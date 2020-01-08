using System;
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
        private readonly IFileManager _fileManager;
        public ResumeController(RejionDBContext context, IAuth auth, IWebHostEnvironment env, IFileManager fileManager)
        {
            _context = context;
            _auth = auth;
            _env = env;
            _fileManager = fileManager;
        }

        public IActionResult Index()
        {
            BreadCrumbViewModel breadCrumb = new BreadCrumbViewModel
            {
                Title = "CV-im",
                Parents = new Dictionary<string, List<string>>()
                {
                    { "Ana səhifə", new List<string>() { "home", "index" } },
                }
            };
            ViewBag.BreadCrumb = breadCrumb;
            if (_auth.User == null)
            {
                return RedirectToAction("register", "account");
            }
            return View();
        }

        [HttpPost]
        public JsonResult CreateResume(ResumeViewModel model)
        {
            Candidate candidate = new Candidate();
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

            _context.Candidates.Add(candidate);
            _context.SaveChanges();

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
                _context.SaveChanges();
            }

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
                _context.SaveChanges();
            }

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

            var educations = _context.Educations.Where(e => e.CandidateId == _auth.User.Candidate.Id).ToList();

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
            else if(educations.Count > model.Educations.Count)
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
                for (var t = model.Educations.Count; t<educations.Count; t++)
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