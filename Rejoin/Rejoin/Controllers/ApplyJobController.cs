using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rejoin.Data;
using Rejoin.Models;
using Rejoin.Injections;

namespace Rejoin.Controllers
{
    public class ApplyJobController : BaseController
    {
        private readonly RejionDBContext _context;
        private readonly IAuth _auth;

        //constructor of applyjobcontroller
        public ApplyJobController(RejionDBContext context, IAuth auth) : base(context)
        {
            _context = context;
            _auth = auth;
        }

        //returns the modal for applying job
        public PartialViewResult Index(int JobId)
        {
            if(_auth.User == null || _auth.User.UserType == UserType.Company)
            {
                return PartialView("~/Views/Shared/NotFound.cshtml");
            }

            Job job = _context.Jobs.Find(JobId);
            return PartialView("~/Views/Shared/_ApplyJob.cshtml", job);
        }


        //applying job with json
        [HttpPost]
        public JsonResult Apply(Apply apply)
        {

            apply.CandidateId = _auth.User.Candidate.Id;

            apply.AppliedAt = DateTime.Now;
            _context.Applies.Add(apply);
            _context.SaveChanges();

            return Json(new
            {
                status = "OK",
                code = 200,
                message = "applying added",
                data = apply
            });
        }
    }
}