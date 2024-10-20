namespace Lab.Models;

public class Birth
{
    public string FirstName { get; set; }
    public DateTime BirthDate { get; set; }

    public int CalculateAge()
    {
        var age = DateTime.Now.Year - BirthDate.Year;
        if (DateTime.Now.Month < BirthDate.Month || (DateTime.Now.Month == BirthDate.Month && DateTime.Now.Day < BirthDate.Day))
        {
            age--;
        }
        return age;
    }

    public bool IsValid()
    {
        return BirthDate < DateTime.Now && FirstName != null;
    }
    
    public string FormattedBirthDate => BirthDate.ToString("dd.MM.yyyy");
}