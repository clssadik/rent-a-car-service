using Microsoft.AspNetCore.Mvc;
using RentACarService.ViewModels;

namespace RentACarService.Controllers;

public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        if (model.Email == "admin@meurent.com" && model.Password == "123456")
        {
            HttpContext.Session.SetString("UserEmail", model.Email);
            TempData["SuccessMessage"] = "Giriş başarılı.";
            return RedirectToAction("Index", "Admin");
        }

        ModelState.AddModelError(string.Empty, "E-posta veya şifre hatalı.");

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        TempData["SuccessMessage"] = "Çıkış yapıldı.";
        return RedirectToAction("Index", "Home");
    }
}
