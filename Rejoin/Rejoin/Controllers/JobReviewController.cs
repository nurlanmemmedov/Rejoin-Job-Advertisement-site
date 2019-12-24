using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rejoin.Models;
using Rejoin.Data;
using Rejoin.Injections;



namespace Rejoin.Controllers
{
    public class JobReviewController : Controller
    {
        private readonly IAuth _auth;
        private readonly RejionDBContext _context;

        public JobReviewController(IAuth auth, RejionDBContext context)
        {
            _auth = auth;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult WriteComment(JobReview jobReview)
        {
            jobReview.CreatedAt = DateTime.Now;
            jobReview.JobId = 4;
            jobReview.UserId = _auth.User.Id;
            jobReview.Status = true;
            jobReview.Ranking = 4;
            _context.JobReviews.Add(jobReview);
            _context.SaveChanges();
            return Json(new
            {
                data = jobReview.Comment
            }) ;

        }
    }
}