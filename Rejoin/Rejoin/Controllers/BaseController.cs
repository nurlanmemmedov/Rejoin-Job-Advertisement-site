using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Rejoin.Data;

namespace Rejoin.Controllers
{
    public class BaseController : Controller
    {
        private readonly RejionDBContext _context;
        public BaseController(RejionDBContext context)
        {
            _context = context;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.FooterCategories = _context.Categories.ToList();

            base.OnActionExecuting(context);
        }
    }
}