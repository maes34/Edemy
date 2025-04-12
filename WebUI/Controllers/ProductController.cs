using Microsoft.AspNetCore.Mvc;
using Core.Service;
using Model.Entities;

namespace WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly ICoreService<Product> _db;

        public ProductController(ICoreService<Product> coreService)
        {
            _db = coreService;
        }

        public IActionResult List(int id)
        {
            return View(_db.GetAll().Where(x => x.CategoryId == id).ToList());
        }

        public IActionResult Details(int id)
        {
            var productData = _db.GetbyId(id);

            if (productData is not null)
            {
                return View(productData);
            }
            ViewBag.ErrorProductDetail = "Böyle bir ürün bulunmuyor.";
            return RedirectToAction("List");
        }
    }
}
