using Core.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using System.Security.Claims;
using WebUI.Helpers;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {

        private readonly ICoreService<User> _db;

        public AccountController(ICoreService<User> core)
        {
            _db = core;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password)
        {
            password = PasswordHelper.Sha256Hash(password);
            var data = _db.GetAll().Where(x => x.UserName == userName && x.Password == password && x.UserType == 1).FirstOrDefault();

            if (data is not null)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, userName)
                };

                var identity = new ClaimsIdentity(claims, "Login");
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.LoginError = "Kullanıcı Adı veya Şifre veya Kullanıcı Türü Hatalı!";
                return View();
            }

            
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PasswordReset(string userName)
        {
            var data = _db.GetAll()
                          .Where(x => x.UserName == userName)
                          .FirstOrDefault();

            if (data is not null)
            {
                data.Password = PasswordHelper.Sha256Hash("123");
                data.TempPassword = 1;

                return _db.Save() ? RedirectToAction("Login") : View();
            }
            else
            {
                ViewBag.TempPasswordError = "Böyle bir kullanıcı bulunmuyor.";
                return RedirectToAction("Login");
            }

           
        }
        public async Task<IActionResult> ReNewPass(string password)
        {
            return View();

        }
    }
}
