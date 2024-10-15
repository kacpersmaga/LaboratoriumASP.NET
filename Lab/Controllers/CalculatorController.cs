using Lab.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab.Controllers;

public class CalculatorController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Result(Operator? op, double? a, double? b)
    {
        
        // var op = Request.Query["op"];
        // var a = double.Parse(Request.Query["a"]);
        // var b = double.Parse(Request.Query["b"]);
        if (a is null || b is null)
        {
            ViewBag.ErrorMessage = "Niepoprawny format liczby w parametrze a lub b!";
            return View("CustomError");
        }

        if (op is null)
        {
            ViewBag.ErrorMessage = "Nieznany operator!";
            return View("CustomError");
        }
        ViewBag.A = a;
        ViewBag.B = b;
        ViewBag.Operator = op;
        switch (op)
        {
            case Operator.Add:
                ViewBag.Result = a + b;
                ViewBag.Operator = "+";
                break;
            case Operator.Sub :
                ViewBag.Result = a - b;
                ViewBag.Operator = "-";
                break;
            case Operator.Div:
                ViewBag.Result = a / b;
                ViewBag.Operator = ":";
                break;
            case Operator.Mul:
                ViewBag.Result = a * b;
                ViewBag.Operator = "*";
                break;
            default:
                ViewBag.ErrorMessage = "Nieznany operator!";
                return View("CustomError");
        }
        
        
        
        // ViewBag.Result = 1234;
        return View();
    }
    public enum Operator
    {
        Add, Sub, Mul, Div
    }
    
    public IActionResult Form()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Result([FromForm] Calculator model)
    {
        if (!model.IsValid())
        {
            return View("Error");
        }
        return View(model);
    }
}