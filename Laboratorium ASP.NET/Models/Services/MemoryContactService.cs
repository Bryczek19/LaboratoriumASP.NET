namespace Laboratorium_ASP.NET.Models.Services;

public class MemoryContactService: iContactService
{
    private Dictionary<int, ContactModel> _contacts= new Dictionary<int, ContactModel>()
    {
        {1, new() {Id = 1, Email = "email@interia.pl",FirstName = "Krzysztof", LastName = "Zapałka", Category = Category.Family, BirthDate = new (1970, 1,16), PhoneNumber = "121 131 181"}},
        {2, new() {Id = 2, Email = "email1@interia.p",FirstName = "Rafał", LastName = "Ogórek", Category  = Category.Business, BirthDate = new DateTime(1959, 09,29), PhoneNumber = "232 242 272"}}
    };

    private int _currentId = 3;
    
    
    public void Add(ContactModel model)
    {
        model.Id = ++_currentId;
        _contacts.Add(model.Id, model);
    }

    public void Update(ContactModel contact)
    {
        if (_contacts.ContainsKey(contact.Id))
        {
            _contacts[contact.Id] = contact;
        }
    }

    public void Delete(int id)
    {
        _contacts.Remove(id);
    }

    public List<ContactModel> GetAll()
    {
        return _contacts.Values.ToList(); 
    }

    public ContactModel? GetById(int id)
    {
        // return _contacts.TryGetValue(id, out var contact) ? contact : null;
        return _contacts[id];
    }
}