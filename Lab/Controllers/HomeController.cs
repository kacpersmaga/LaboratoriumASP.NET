using System.Diagnostics;
using Lab.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    
    /*
     * Zadanie 1
     * Zdefiniuj metodę Age, która na podstawie dwóch data w parametrach: birth, future
     * obliczy wiek osoby w roku future
     * Uwzględnij pełne lata
     */
    
    public IActionResult About()
    {
        return View();
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {

        return View();
    }
    public IActionResult Age(DateTime birth, DateTime future)
    {
        ViewBag.birth = birth.ToString("yyyy-MM-dd");
        ViewBag.future = future.ToString("yyyy-MM-dd");
        
        if (future < birth)
        {
            ViewBag.ErrorMessage = "Niepoprawna data!";
            return View("CustomError");
        }

        int age = future.Year - birth.Year;

        if (future.Month < birth.Month || (future.Month == birth.Month && future.Day < birth.Day))
        {
            age--;
        }


        ViewBag.Result = age;

        return View();
    }
    
    public IActionResult Calculator(Operators? op, double? a, double? b)
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
            case Operators.Add:
                ViewBag.Result = a + b;
                ViewBag.Operator = "+";
                break;
            case Operators.Sub :
                ViewBag.Result = a - b;
                ViewBag.Operator = "-";
                break;
            case Operators.Div:
                ViewBag.Result = a / b;
                ViewBag.Operator = ":";
                break;
            case Operators.Mul:
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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

public enum Operators
{
    Add, Sub, Mul, Div
}