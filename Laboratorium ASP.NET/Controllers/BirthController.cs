using Laboratorium_ASP.NET.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_ASP.NET.Controllers;

public class BirthController : Controller
{
    // GET
    public IActionResult Form()
    {
        return View(new Birth());
    }
    
    [HttpPost]
    public IActionResult Result(Birth model)
    {
      
        if (!model.IsValid())
        {
            return View("Error");
        }
        var age = model.CalculateAge();
        model.Message = $"Cześć {model.Name}, masz {age} lat(a)."; 
        return View(model);
    }
}