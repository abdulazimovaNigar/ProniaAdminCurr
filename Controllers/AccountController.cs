using Microsoft.AspNetCore.Mvc;

namespace ProniaAdmin.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
