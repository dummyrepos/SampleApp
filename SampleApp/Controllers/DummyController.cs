using Microsoft.AspNetCore.Mvc;

namespace SampleApp.Controllers
{
    public class DummyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
