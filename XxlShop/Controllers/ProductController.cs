using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using XxlShop.Models;

namespace XxlShop.Controllers
{
    public class ProductController : XxlController
    {
        public IActionResult Index(string id)
        {
            ObjectId Id = default;
            try {
                Id = new ObjectId(id);
            }
            catch {
                return NotFound();
            }

            Product product = Data.MainDomain.ExistingTovars.Find(x => x.Id == Id);

            return View("Product", product);
        }
    }
}
