using System.Collections.Concurrent;
using Lab.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab.Controllers;

[Authorize(Roles = "admin")]
public class ContactController : Controller
{
    private readonly IContactService _contactService;
    
    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }
    
    [AllowAnonymous]
    public IActionResult Index()
    {
        return View(_contactService.FindAll());
    }
    
    // Formularz dodania kontaktu
    public IActionResult Add()
    {
        ContactModel model = new ContactModel();
        InitializeOrganizations(model);  
        return View(model);
    }
    
    // Odebranie i zapisanie nowego kontaktu
    [HttpPost]
    public IActionResult Add(ContactModel model)
    {
        if (!ModelState.IsValid)
        {
            InitializeOrganizations(model);
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
        
        InitializeOrganizations(contact);
        return View(contact);
    }
    
    [HttpPost]
    public IActionResult Edit(ContactModel contact)
    {
        if (!ModelState.IsValid)
        {
            InitializeOrganizations(contact);
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

        var organization = _contactService.FindOrganizationById(contact.OrganizationId);
        ViewBag.Organization = organization?.Title;

        return View(contact);
    }
    
    private void InitializeOrganizations(ContactModel model)
    {
        model.Organizations = _contactService
            .FindAllOrganizations()
            .Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Title })
            .ToList();
    }
}