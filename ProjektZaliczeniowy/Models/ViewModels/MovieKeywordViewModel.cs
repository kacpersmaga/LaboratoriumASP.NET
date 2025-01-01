using System.ComponentModel.DataAnnotations;

namespace ProjektZaliczeniowy.Models.ViewModels;

public class MovieKeywordViewModel
{
    [Required]
    public int MovieId { get; set; }
    public string Title { get; set; }
        
    [Required(ErrorMessage = "Please enter a keyword")]
    [StringLength(50, ErrorMessage = "Keyword must be less than 50 characters.")]
    [Display(Name = "New Keyword")]
    public string NewKeyword { get; set; }
        
    public int CompanyId { get; set; }
        
    public List<string> Keywords { get; set; } = new List<string>();
}