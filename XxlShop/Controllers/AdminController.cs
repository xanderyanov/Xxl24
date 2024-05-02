using Microsoft.AspNetCore.Mvc;

namespace XxlShop.Controllers
{
    public class AdminController : XxlController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
