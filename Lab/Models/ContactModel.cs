using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Lab.Models;

public class ContactModel
{
    [HiddenInput]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Musisz podać imię")]
    [MaxLength(length: 20, ErrorMessage = "Imię nie może być dluższe niż 20 znaków!")]
    [MinLength(length: 2)]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Musisz podać imię")]
    [MaxLength(length: 50, ErrorMessage = "Imię nie może być dluższe niż 50 znaków!")]
    [MinLength(length: 2)]
    public string LastName { get; set; }
    
    [EmailAddress]
    public string Email { get; set; }
    
    [DataType(DataType.Date)]
    public DateOnly BirthDate { get; set; }
    
    [Phone]
    [RegularExpression(pattern: @"\+\d{2} \d{3} \d{3} \d{3}", ErrorMessage = "Wpisz numer wg wzoru: +xx xxx xxx xxx")]
    public string PhoneNumber { get; set; }

    public Category Category { get; set; }
    
}