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
    
    private static Dictionary<int, ContactModel> _contacts = new()
    {
        {
            1, new ContactModel() 
            {
                Id = 1, 
                FirstName = "Adam", 
                LastName = "Abecki", 
                Email = "adam@wsei.edu.pl", 
                BirthDate = new DateOnly(2000, 10, 10), 
                PhoneNumber = "+48 222 222 333",
                Category = Category.Family
            }
            
        },
        {
            2, new ContactModel()
            {
                Id = 1, 
                FirstName = "Ewa", 
                LastName = "Bębecka", 
                Email = "ewa@wsei.edu.pl", 
                BirthDate = new DateOnly(2001, 11, 12), 
                PhoneNumber = "+48 321 123 333",
                Category = Category.Friend
            }
            
        },
        {
            3, new ContactModel()
            {
                Id = 1, 
                FirstName = "Jakub", 
                LastName = "Abecki", 
                Email = "jakub@wsei.edu.pl", 
                BirthDate = new DateOnly(2005, 2, 15), 
                PhoneNumber = "+48 421 112 555",
                Category = Category.Business
            }
            
        }

    };
    
    private static int currentId = 3;
    // Lista kontaktów
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