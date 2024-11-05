namespace Lab.Models;

public class ContactMapper
{
    public static ContactEntity ToEntity(ContactModel model)
    {
        return new()
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            BirthDate = model.BirthDate,
            PhoneNumber = model.PhoneNumber,
            Email = model.Email,
            Category = model.Category,
        };
    }

    public static ContactModel FromEntity(ContactEntity entity)
    {
        return new()
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            BirthDate = entity.BirthDate,
            PhoneNumber = entity.PhoneNumber,
            Email = entity.Email,
            Category = entity.Category,
        };
    }
}