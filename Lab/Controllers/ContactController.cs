using System.Collections.Concurrent;
using Lab.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab.Controllers;

public class ContactController : Controller
{
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
        return View(_contacts.Values.ToList());
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

        model.Id = ++currentId;
        _contacts.Add(model.Id, model);
        return View("Index", _contacts.Values.ToList());
    }

    public IActionResult Delete(int id)
    {
        _contacts.Remove(id);
        return View("Index", _contacts.Values.ToList());
    }
    


    
    [HttpGet]
    public IActionResult Edit(int id)
    {
    
        if (_contacts.Keys.Contains(id))
        {
            return View(_contacts[id]);
        }
        else
        {
            return NotFound();
        };
    }
    
    [HttpPost]
    public IActionResult Edit(ContactModel contact) 
    {
        if (ModelState.IsValid) 
        {
            _contacts[contact.Id] = contact;
            return RedirectToAction("Index");
        }
        else
        {
            return View();
        }
    }
    
    public IActionResult Details(int id)
    {
        if (_contacts.ContainsKey(id))
        {
            return View(_contacts[id]);
        }
        return NotFound();
    }
}