using Microsoft.AspNetCore.Mvc;

namespace TemplateCleanArch.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
