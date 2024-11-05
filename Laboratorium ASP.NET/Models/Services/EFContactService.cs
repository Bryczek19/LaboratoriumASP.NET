using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Laboratorium_ASP.NET.Models.Services;

public class EFContactService: iContactService
{
    private readonly AppDbContext Context;
    private object _context;

    public EFContactService(AppDbContext context, object context1)
    {
        Context = context;
        _context = context1;
    }

    public void Add(ContactModel contact)
    {
        _context.Contact.Add(ContactModel.ToEntity(Model));
        _context.SaveChanges();
    }

    public void Update(ContactModel contact)
    {
        _context.Contact.Update(ContactMapper.ToEntity(model));
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        _context.Contact.Remove(new ContactEntity() { Id = id });
        _context.SaveChanges();
    }

    public List<ContactModel> GetAll()
    {
        return _context.Contacts
            .Select(e ContactEntity => ContactMapper.FromEntity(e))
            .ToList();
    }

    public ContactModel? GetById(int id)
    {
        var entity = _context.Contact.Find(id);
        return entity != null ? ContactMapper.FromEntity(entity) : null;
    }
}