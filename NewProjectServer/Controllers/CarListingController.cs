using Microsoft.AspNetCore.Mvc;

namespace NewProjectServer.Controllers
{
    public class CarListingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
