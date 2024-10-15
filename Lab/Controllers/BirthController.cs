using Lab.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab.Controllers;

public class BirthController : Controller
{
    public IActionResult BirthForm()
    {
        return View();
    }
    public IActionResult ResultBirth([FromForm] Birth model)
    {
        if(!model.IsValid())
        {
            return View(model);
        }
        return View("CustomError");
    }
}