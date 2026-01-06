using Microsoft.AspNetCore.Mvc;
using Pronia.Contexts;

namespace Pronia.Areas.Admin.Controllers;

[Area("Admin")]
[AutoValidateAntiforgeryToken]
public class CategoryController(AppDbContext _context) : Controller
{
    public IActionResult Index()
    {
        var categorys = _context.Categories.ToList();
        return View(categorys);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    public IActionResult Create(Category category)
    {
        if (!ModelState.IsValid) return View(category);
        category.CreatedDate = DateTime.UtcNow.AddHours(4);
        category.IsDeleted = false;
        _context.Categories.Add(category);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        var category = _context.Categories.FirstOrDefault(s => s.Id == id);
        if (category == null) return NotFound("Product isvnot found!");
        _context.Categories.Remove(category);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        var category = _context.Categories.FirstOrDefault(s => s.Id == id);
        if (category == null) return NotFound();
        return View(category);
    }

    [HttpPost]
    public IActionResult Update(Category category)
    {
        if (!ModelState.IsValid) return View();

        var existCategory = _context.Categories.FirstOrDefault(s => s.Id == category.Id);
        if (existCategory == null) return NotFound();

        existCategory.Name = category.Name;

        _context.Categories.Update(existCategory);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult Toggle(int id)
    {
        var existCategory = _context.Categories.FirstOrDefault(s => s.Id == id);
        if (existCategory == null) return NotFound();

        existCategory.IsDeleted = !existCategory.IsDeleted;

        _context.Categories.Update(existCategory);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}
