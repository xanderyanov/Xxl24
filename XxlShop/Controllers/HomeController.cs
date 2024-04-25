using Microsoft.AspNetCore.Mvc;
using XxlShop.Domain;
using XxlShop.Models;

namespace XxlShop.Controllers
{
    public class HomeController : XxlController
    {
        public IActionResult Index()
        {
            IEnumerable<Product> Products = Data.MainDomain.ExistingTovars;

            List<Product> filteredProducts = Products.Where(x => x.FlagNew).ToList();

            return View(filteredProducts);
        }
    }
}
