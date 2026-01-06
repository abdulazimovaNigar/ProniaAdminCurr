using Microsoft.AspNetCore.Mvc;
using Pronia.Contexts;
using Pronia.Models;
using System.Diagnostics;

namespace Pronia.Controllers
{
    public class HomeController(AppDbContext _context) : Controller
    {
        public IActionResult Index()
        {
            var shippings = _context.Shippings.ToList();
            return View(shippings);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
