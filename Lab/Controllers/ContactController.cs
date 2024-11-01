using System.Collections.Concurrent;
using Lab.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab.Controllers;

public class ContactController : Controller
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }
    
    public IActionResult Index()
    {
        return View(_contactService.FindAll());
    }
    
    // Formularz dodania kontaktu
    public IActionResult Add()
    {
        return View();
    }
    
    // Odebranie i zapisanie nowego kontaktu
    [HttpPost]
    public IActionResult Add(ContactModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        _contactService.Add(model);
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        _contactService.Delete(id);
        return RedirectToAction("Index");
    }
    


    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var contact = _contactService.FindById(id);
        if (contact == null)
        {
            return NotFound();
        }

        return View(contact);
    }
    
    [HttpPost]
    public IActionResult Edit(ContactModel contact)
    {
        if (!ModelState.IsValid)
        {
            return View(contact);
        }

        _contactService.Update(contact);
        return RedirectToAction("Index");
    }
    
    public IActionResult Details(int id)
    {
        var contact = _contactService.FindById(id); 
        if (contact == null)
        {
            return NotFound();
        }

        return View(contact);
    }
}