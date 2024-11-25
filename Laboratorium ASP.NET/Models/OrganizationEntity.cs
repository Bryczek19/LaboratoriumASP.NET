using System.ComponentModel.DataAnnotations.Schema;

namespace Laboratorium_ASP.NET.Models.Services;

public class OrganizationEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Nip { get; set; }
    public string Regon { get; set; }
    public Address Address { get; set; } // Owned type
    public IEnumerable<ContactEntity>? Contacts { get; set; }
    public string NIP { get; set; }
    public string REGON { get; set; }
}
public class Address
{
    public string City { get; set; }
    public string Street { get; set; }
}
