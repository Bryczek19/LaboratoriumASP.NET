using Laboratorium_ASP.NET.Models;
using Laboratorium_ASP.NET.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_ASP.NET.Controllers;

public class ContactController : Controller
{
    static private Dictionary<int, ContactModel> _contacts= new Dictionary<int, ContactModel>()
    {
        {1, new() {Id = 1, Email = "email@wsei.com",FirstName = "Adam", LastName = "rafał", BirthDate = new DateTime(1930, 1,09), PhoneNumber = "111 111 111"}},
        {2, new() {Id = 2, Email = "email1@wsei.com",FirstName = "Karol", LastName = "Kowal", BirthDate = new DateTime(1990, 03,13), PhoneNumber = "222 222 222"}}
    };

    private static int currentID = 0;
    // Lista kontaktów
    public IActionResult Index()
    {
        return View(_contacts);
    }

    public ActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Add(ContactModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        model.Id = ++currentID;
        _contacts.Add(model.Id, model);
        return View("Index", _contacts);
    }

    public ActionResult Delete(int id)
    {
        _contacts.Remove(id);
        return View("Index", _contacts);
    }

    public ActionResult Details(int id)
    {
        return View(_contacts[id]);
    }
}