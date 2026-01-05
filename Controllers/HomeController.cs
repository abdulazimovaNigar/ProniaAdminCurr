using Microsoft.AspNetCore.Mvc;
using ProniaAdmin.Contexts;
using System.Diagnostics;

namespace ProniaAdmin.Controllers;

public class HomeController : Controller
{
    private AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }

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

    public IActionResult LoginRegister() 
    {
        return View();
    }
}