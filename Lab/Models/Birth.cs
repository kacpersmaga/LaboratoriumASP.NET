namespace Lab.Models;

public class Birth
{
    public DateTime dateOfBirth { get; set; }
    public DateTime dateFuture { get; set; }
    private int _age;
    public string? name { get; set; }
    public int age
    {
        get
        {
            _age = Age();
            return _age;
        }
        set
        {
            _age = value;
        }
    }
    public bool IsValid()
    {
        if(name != null && dateOfBirth < DateTime.Now && dateFuture > DateTime.Now)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public int Age() 
    {
        int a = Convert.ToInt32(dateFuture.Year - dateOfBirth.Year);
        if (dateOfBirth.Month > dateFuture.Month) 
        {
            a--;
            return a;
        }
        else
        {
            return a;
        }
    }
}