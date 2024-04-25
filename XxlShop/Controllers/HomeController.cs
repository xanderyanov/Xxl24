using Microsoft.AspNetCore.Mvc;
using XxlShop.Domain;

namespace XxlShop.Controllers
{
    public class HomeController : XxlController
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
