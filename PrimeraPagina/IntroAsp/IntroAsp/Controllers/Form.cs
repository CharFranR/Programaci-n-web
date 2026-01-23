using Microsoft.AspNetCore.Mvc;

namespace IntroAsp.Controllers
{
    public class Form : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
