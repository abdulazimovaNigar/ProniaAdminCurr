using Microsoft.AspNetCore.Mvc;

namespace Pronia.Abstraction;

public interface IController
{
    IActionResult Index();
    IActionResult Create();
    IActionResult Create(Shipping shipping);
    IActionResult Update(Shipping shipping);
    IActionResult Update(int id);
    IActionResult Delete(int id);
}
