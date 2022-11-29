using Microsoft.AspNetCore.Mvc;

namespace KeysShop.Server.Controllers
{
    public class BrandController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
