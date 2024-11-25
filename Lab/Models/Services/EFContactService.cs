namespace Lab.Models;

public class EFContactService: IContactService
{
    private readonly AppDbContext _context;

    public EFContactService(AppDbContext context)
    {
        _context = context;
    }

    public int Add(ContactModel model)
    {
        var entity = _context.Contacts.Add(ContactMapper.ToEntity(model));
        _context.SaveChanges();
        return entity.Entity.Id;
    }

    public void Delete(int id)
    {
        _context.Remove(new ContactEntity() { Id = id });
        _context.SaveChanges();
    }

    public void Update(ContactModel model)
    {
        _context.Contacts.Update(ContactMapper.ToEntity(model));
        _context.SaveChanges();
    }

    public List<ContactModel> FindAll()
    {
        return _context.Contacts
            .Select(e => ContactMapper.FromEntity(e))
            .ToList();
    }

    public ContactModel? FindById(int id)
    {
        var entity = _context.Contacts.Find(id);
        return entity != null ? ContactMapper.FromEntity(entity) : null;
    }
    
    public List<OrganizationEntity> FindAllOrganizations()
    {
        return _context.Organizations.ToList();
    }
    
    public OrganizationEntity? FindOrganizationById(int id)
    {
        return _context.Organizations.Find(id);
    }
}