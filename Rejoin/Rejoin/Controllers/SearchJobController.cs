using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Rejoin.Data;
using Rejoin.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Rejoin.Controllers
{
    public class SearchJobController : BaseController
    {
        private readonly RejionDBContext _context;

        //constructor of searchjobcontroller
        public SearchJobController(RejionDBContext context) : base(context)
        {
            _context = context;
        }

        //returns the searchinjobpage
        public IActionResult Index()
        {

            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Jobs = _context.Jobs.Include("Company").Where(j => j.isActive == true).ToList();
            ViewBag.All = _context.Jobs.Include("Company").Where(j => j.isActive == true).ToList();
            return View();
        }

        //search job according to keyword location or category
        [HttpGet]
        public IActionResult Index(SearchViewModel model, int? CategoryId)
        {
            if (CategoryId != null)
            {
                if (!_context.Categories.Any(j => j.Id == CategoryId || CategoryId == 0))
                {
                    return View("~/Views/Shared/NotFound.cshtml");
                }
            }


            //searching job conditions
            if (model.CategoryId == 0 && model.KeyWord == null && model.Location == null)
            {
                ViewBag.Jobs = _context.Jobs.Include("Company").Where(j => j.isActive == true).OrderByDescending(j => j.CreatedAt).ToList();
            }
            else if (model.CategoryId == 0 && model.KeyWord == null && model.Location != null)
            {
                ViewBag.Jobs = _context.Jobs.Include("Company").Where(j => j.isActive == true && j.Address.ToLower().Contains(model.Location.ToLower())).OrderByDescending(j => j.CreatedAt).ToList();
            }
            else if (model.CategoryId == 0 && model.KeyWord != null && model.Location == null)
            {
                ViewBag.Jobs = _context.Jobs.Include("Company").Where(j => j.isActive == true && j.Title.ToLower().Contains(model.KeyWord.ToLower())).OrderByDescending(j => j.CreatedAt).ToList();
            }
            else if (model.CategoryId == 0 && model.KeyWord != null && model.Location != null)
            {
                ViewBag.Jobs = _context.Jobs.Include("Company").Where(j => j.isActive == true && j.Title.Contains(model.KeyWord) && j.Address.Contains(model.Location)).OrderByDescending(j => j.CreatedAt).ToList();
            }
            else if (model.CategoryId > 0 && model.KeyWord == null && model.Location == null)
            {
                ViewBag.Jobs = _context.Jobs.Include("Company").Where(j => j.isActive == true && j.CategoryId == model.CategoryId).OrderByDescending(j => j.CreatedAt).ToList();

            }
            else if (model.CategoryId > 0 && model.KeyWord != null && model.Location == null)
            {
                ViewBag.Jobs = _context.Jobs.Include("Company").Where(j => j.isActive == true && j.CategoryId == model.CategoryId && j.Title.Contains(model.KeyWord)).OrderByDescending(j => j.CreatedAt).ToList();
            }
            else if (model.CategoryId > 0 && model.KeyWord == null && model.Location != null)
            {
                ViewBag.Jobs = _context.Jobs.Include("Company").Where(j => j.isActive == true && j.CategoryId == model.CategoryId && j.Address.Contains(model.Location)).OrderByDescending(j => j.CreatedAt).ToList();
            }
            else if (model.CategoryId > 0 && model.KeyWord != null && model.Location != null)
            {
                ViewBag.Jobs = _context.Jobs.Include("Company").Where(j => j.isActive == true && j.CategoryId == model.CategoryId && j.Address.Contains(model.Location) && j.Title.Contains(model.KeyWord)).OrderByDescending(j => j.CreatedAt).ToList();
            }
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.All = _context.Jobs.Include("Company").Where(j => j.isActive == true && j.isActive == true).OrderByDescending(j => j.CreatedAt).ToList();
            return View();
        }

    }
}