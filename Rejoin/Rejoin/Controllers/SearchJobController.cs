using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rejoin.Models;
using Rejoin.Data;
using Rejoin.Injections;
using Rejoin.ViewModels;


namespace Rejoin.Controllers
{
    public class SearchJobController : Controller
    {
        private readonly RejionDBContext _context;
        public SearchJobController(RejionDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
       
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Jobs = _context.Jobs.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Index(SearchViewModel model)
        {
            if (model.CategoryId == 0 && model.KeyWord == null && model.Location == null)
            {
                ViewBag.Jobs = _context.Jobs.ToList(); ;
            }
            else if (model.CategoryId == 0 && model.KeyWord == null && model.Location != null)
            {
                ViewBag.Jobs = _context.Jobs.Where(j => j.Address.Contains(model.Location)).ToList(); ;
            }
            else if (model.CategoryId == 0 && model.KeyWord != null && model.Location == null)
            {
                ViewBag.Jobs = _context.Jobs.Where(j => j.Title.Contains(model.KeyWord)).ToList(); ;
            }
            else if (model.CategoryId == 0 && model.KeyWord != null && model.Location != null)
            {
                ViewBag.Jobs = _context.Jobs.Where(j => j.Title.Contains(model.KeyWord) && j.Address.Contains(model.Location)).ToList(); ;
            }
            else if (model.CategoryId > 0 && model.KeyWord == null && model.Location == null)
            {
                ViewBag.Jobs = _context.Jobs.Where(j => j.CategoryId == model.CategoryId).ToList();

            }
            else if (model.CategoryId > 0 && model.KeyWord != null && model.Location == null)
            {
                ViewBag.Jobs = _context.Jobs.Where(j => j.CategoryId == model.CategoryId && j.Title.Contains(model.KeyWord)).ToList();
            }
            else if (model.CategoryId > 0 && model.KeyWord == null && model.Location != null)
            {
                ViewBag.Jobs = _context.Jobs.Where(j => j.CategoryId == model.CategoryId && j.Address.Contains(model.Location)).ToList();
            }
            else if (model.CategoryId > 0 && model.KeyWord != null && model.Location != null)
            {
                ViewBag.Jobs = _context.Jobs.Where(j => j.CategoryId == model.CategoryId && j.Address.Contains(model.Location) && j.Title.Contains(model.KeyWord)).ToList();
            }
            ViewBag.Categories = _context.Categories.ToList();

            return View();
        }

    }
}