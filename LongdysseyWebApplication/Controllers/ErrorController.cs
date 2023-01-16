using WebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class ErrorController : Controller
    {
        // GET: ErrorController
        public ActionResult Index(string errorMessage)
        {
            ErrorViewModel errorViewModel = new()
            {
                ErrorMessage = errorMessage
            };
            return View(errorViewModel);
        }
    }
}
