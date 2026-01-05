using Microsoft.AspNetCore.Mvc;
using ProniaAdmin.Contexts;

namespace ProniaAdmin.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductController(AppDbContext _context) : Controller
{
    public IActionResult Index()
    {
        var products = _context.Products.ToList();
        return View(products);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Product product)
    {
        if (!ModelState.IsValid) return View(product);
        product.CreatedDate = DateTime.UtcNow.AddHours(4);
        product.IsDeleted = false;
        _context.Add(product);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id);
        if (product == null) return NotFound("Product isvnot found!");
        _context.Remove(product);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id);
        if (product == null) return NotFound();
        return View(product);
    }


    [HttpPost]
    public IActionResult Update(Product product)
    {
        if (!ModelState.IsValid) return View(product);

        var existProduct = _context.Products.FirstOrDefault(p => p.Id == product.Id);
        if (existProduct == null) return NotFound();

        existProduct.Name = product.Name;
        existProduct.Description = product.Description;
        existProduct.Price = product.Price;
        existProduct.CategoryId = product.CategoryId;
        existProduct.MainImagePath = product.MainImagePath;
        existProduct.HoverImagePath = product.HoverImagePath;

        _context.Products.Update(existProduct);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult Toggle(int id)
    {

        var existProduct = _context.Products.FirstOrDefault(s => s.Id == id);
        if (existProduct == null) return NotFound();

        existProduct.IsDeleted = !existProduct.IsDeleted;

        _context.Products.Update(existProduct);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}