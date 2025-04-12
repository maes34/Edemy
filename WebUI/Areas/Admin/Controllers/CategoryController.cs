using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class CategoryController : Controller
    {
        private readonly ICoreService<Category> _db;

        public CategoryController(ICoreService<Category> dbCoreService)
        {
            _db = dbCoreService;
        }
        public IActionResult Index(int page = 1, int pageSize = 2)
        {
            ViewBag.TotalPages = (int)Math.Ceiling((double)_db.GetCount() / pageSize);
            ViewBag.CurrentPage = page;

            var data = _db.GetRecords(page, pageSize);

            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category c)
        {
            var result = _db.Create(c);

            if (result)
            {
                return RedirectToAction("Index");
            }
            ViewBag.ErrorMessage = "Bir hata ile karşılaşıldı.";
            return View();
        }
        public IActionResult Update(int id)
        {
            return View(_db.GetbyId(id));
        }
        [HttpPost]
        public IActionResult Update(Category c)
        {
            var result = _db.Update(c);

            if (!result)
            {
                ViewBag.ErrorPanel = "Hata";
            }

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var result = _db.Delete(_db.GetbyId(id));
            return View();
        }
    }
}
