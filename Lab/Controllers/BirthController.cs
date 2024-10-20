using Lab.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab.Controllers;

public class BirthController : Controller
{
    [HttpPost]
    public IActionResult Result([FromForm] Birth model)
    {
        if (!model.IsValid())
        {
            return View("Error");
        }
        return View(model);
    }
    
    public IActionResult Form()
    {
        return View();
    }
}