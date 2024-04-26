using Microsoft.AspNetCore.Mvc;
using XxlShop.Models;
using XxlShop.Models.ViewModels;

namespace XxlShop.Controllers
{
    public class HomeController : XxlController
    {
        public int PageSize = 12;
        public IActionResult Index(int productPage = 1)
        {
            IEnumerable<Product> Products = Data.MainDomain.ExistingTovars;

            IEnumerable<Product> filteredProducts = Products.Where(x => x.FlagNew);

            return View(new ProductsListViewModel
            {
                Products = filteredProducts
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = filteredProducts.Count()
                }
            });

        }
    }
}
