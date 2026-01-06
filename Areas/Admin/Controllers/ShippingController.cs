using Microsoft.AspNetCore.Mvc;
using Pronia.Abstraction;
using Pronia.Contexts;

namespace Pronia.Areas.Admin.Controllers;

[Area("Admin")]
[AutoValidateAntiforgeryToken]
public class ShippingController(AppDbContext _context) : Controller, IController
{
    public IActionResult Index()
    {
        var shippings = _context.Shippings.ToList();
        return View(shippings);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    public IActionResult Create(Shipping shipping)
    {
        if (!ModelState.IsValid) return View(shipping);
        shipping.CreatedDate = DateTime.UtcNow.AddHours(4);
        shipping.IsDeleted = false;
        _context.Shippings.Add(shipping);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        var shipping = _context.Shippings.FirstOrDefault(s => s.Id == id);
        if (shipping == null) return NotFound();
        return View(shipping);
    }

    [HttpPost]
    public IActionResult Update(Shipping shipping)
    {
        if (!ModelState.IsValid) return View();

        var existShipping = _context.Shippings.FirstOrDefault(s => s.Id == shipping.Id);
        if (existShipping == null) return NotFound();

        existShipping.Name = shipping.Name;
        existShipping.Description = shipping.Description;
        existShipping.ImageUrl = shipping.ImageUrl;

        _context.Shippings.Update(existShipping);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
    public IActionResult Delete(int id)
    {
        var shipping = _context.Shippings.FirstOrDefault(s => s.Id == id);
        if (shipping == null) return NotFound("Product isvnot found!");
        _context.Shippings.Remove(shipping);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult Toggle(int id)
    {
        var existShipping = _context.Shippings.FirstOrDefault(s => s.Id == id);
        if (existShipping == null) return NotFound();

        existShipping.IsDeleted = !existShipping.IsDeleted;

        _context.Shippings.Update(existShipping);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
}
