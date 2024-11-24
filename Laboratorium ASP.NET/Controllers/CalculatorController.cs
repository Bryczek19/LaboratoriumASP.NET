using Laboratorium_ASP.NET.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_ASP.NET.Controllers;

public class CalculatorController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Result(Calculator model)
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