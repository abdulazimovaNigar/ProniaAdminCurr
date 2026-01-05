using Microsoft.AspNetCore.Mvc;
using ProniaAdmin.Contexts;

namespace ProniaAdmin.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoryController(AppDbContext _context) : Controller
{
    public IActionResult Index()
    {
        var categories = _context.Categorys.ToList();
        return View(categories);
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
        _context.Categorys.Add(category);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        var category = _context.Categorys.FirstOrDefault(s => s.Id == id);
        if (category == null) return NotFound("Product isvnot found!");
        _context.Categorys.Remove(category);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        var category = _context.Categorys.FirstOrDefault(s => s.Id == id);
        if (category == null) return NotFound();
        return View(category);
    }

    [HttpPost]
    public IActionResult Update(Category category)
    {
        if (!ModelState.IsValid) return View();

        var existCategory = _context.Categorys.FirstOrDefault(s => s.Id == category.Id);
        if (existCategory == null) return NotFound();

        existCategory.Name = category.Name;

        _context.Categorys.Update(existCategory);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult Toggle(int id)
    {
        var existCategory = _context.Categorys.FirstOrDefault(s => s.Id == id);
        if (existCategory == null) return NotFound();

        existCategory.IsDeleted = !existCategory.IsDeleted;

        _context.Categorys.Update(existCategory);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}
