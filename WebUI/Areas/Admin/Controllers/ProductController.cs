using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ICoreService<Product> _db;
        private readonly ICoreService<Category> _cdb;

        public ProductController(ICoreService<Product> db, ICoreService<Category> cdb)
        {
            _db = db;
            _cdb = cdb;
        }

        public IActionResult Index()
        {
            ViewBag.CategoryList = _cdb.GetAll();
            return View(_db.GetAll());
        }

        public IActionResult Create()
        {
            ViewBag.CategoryList = _cdb.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product p, IFormFile picture)
        {

            if (picture is not null) 
            {
                string fileName = picture.FileName;
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    picture.CopyTo(stream);
                }

                p.Picture = fileName;
            }



            var result = _db.Create(p);
            
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
        public IActionResult Update(int id)
        {
            return View(_db.GetbyId(id));
        }
        [HttpPost]
        public IActionResult Update(Product p)
        {
            var result = _db.Update(p);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var result = _db.Delete(_db.GetbyId(id));
            return RedirectToAction("Index");
        }
    }
}
