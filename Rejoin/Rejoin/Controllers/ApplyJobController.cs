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
    public class ApplyJobController : Controller
    {
        private readonly RejionDBContext _context;
        private readonly IAuth _auth;

        public ApplyJobController(RejionDBContext context, IAuth auth)
        {
            _context = context;
            _auth = auth;
        }
        public PartialViewResult Index(int JobId)
        {
            Job job = _context.Jobs.Find(JobId);
            return PartialView("~/Views/Shared/_ApplyJob.cshtml", job);
        }

        [HttpPost]
        public JsonResult Apply(Apply apply)
        {

            apply.UserId = _auth.User.Id;
            apply.JobId = 4;
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