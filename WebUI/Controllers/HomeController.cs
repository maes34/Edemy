using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICoreService<Category> _db;

        public HomeController(ICoreService<Category> dbCoreService)
        {
            _db = dbCoreService;
        }
        public IActionResult Index()
        {            
            return View(_db.GetAll());
        }
    }
}
