using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia.Contexts;

namespace ProniaAdmin.Areas.Admin.Controllers;

[Area("Admin")]
[AutoValidateAntiforgeryToken]
public class ProductController(AppDbContext _context) : Controller
{
    public IActionResult Index()
    {
        var products = _context.Products.Include(c => c.Category).ToList();
        return View(products);
    }

    [HttpGet]
    public IActionResult Create()
    {
        var categories = _context.Categories.ToList();

        ViewBag.Categories = categories;

        return View();
    }

    [HttpPost]
    public IActionResult Create(Product product)
    {
        if (!ModelState.IsValid) return View(product);
        product.CreatedDate = DateTime.UtcNow.AddHours(4);
        product.IsDeleted = false;

        var isExistCategory = _context.Products.Any(x => x.Id == product.CategoryId);

        if (!isExistCategory) 
        {
            ModelState.AddModelError("", "No such Category");
            return View(product);
        }

        _context.Products.Add(product);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id);
        if (product == null) return NotFound("Product is not found!");
        _context.Products.Remove(product);
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
        existProduct.Rating = product.Rating;
        existProduct.SKU = product.SKU;


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