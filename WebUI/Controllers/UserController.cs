using Core.Service;
using Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using WebUI.Helpers;


namespace WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly ICoreService<User> _db;

        public UserController(ICoreService<User> dbCoreService)
        {
            _db = dbCoreService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User u)
        {
            u.Password = PasswordHelper.Sha256Hash(u.Password);
            return _db.Create(u) ? RedirectToAction("Index", "Home") : View();
        }
    }
}
