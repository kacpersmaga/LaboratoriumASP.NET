using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab.Models;

public class ContactModel
{
    [HiddenInput]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Musisz podać imię")]
    [MaxLength(length: 20, ErrorMessage = "Imię nie może być dluższe niż 20 znaków!")]
    [MinLength(length: 2)]
    
    [Display(Name = "Imię")]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Musisz podać nazwisko")]
    [MaxLength(length: 50, ErrorMessage = "Nazwisko nie może być dluższe niż 50 znaków!")]
    [MinLength(length: 2)]
    
    [Display(Name = "Nazwisko")]
    public string LastName { get; set; }
    
    [EmailAddress]
    [Display(Name = "E-mail")]
    public string Email { get; set; }
    
    [DataType(DataType.Date)]
    [Display(Name = "Data urodzin")]
    public DateOnly BirthDate { get; set; } = DateOnly.FromDateTime(DateTime.Today);
    
    [Phone]
    [Display(Name = "Numer telefonu")]
    [RegularExpression(pattern: @"\+\d{2} \d{3} \d{3} \d{3}", ErrorMessage = "Wpisz numer wg wzoru: +xx xxx xxx xxx")]
    public string PhoneNumber { get; set; }
    
    [Display(Name = "Kategoria")]
    public Category Category { get; set; }
    
    [HiddenInput]
    public DateTime Created { get; set; }
    

    [Display(Name = "Organizacja")]
    public int OrganizationId { get; set; }
    

    public OrganizationEntity? Organization { get; set; }

    [ValidateNever]
    public List<SelectListItem> Organizations{ get; set; }
    
}