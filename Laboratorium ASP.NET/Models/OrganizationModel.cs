using Laboratorium_ASP.NET.Models.Services;

namespace Laboratorium_ASP.NET.Models;

public class OrganizationModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string NIP { get; set; }
    public string REGON { get; set; }
    
    public Address Address { get; set; }
}
public class Address
{
    public string City { get; set; }
    public string Street { get; set; }
}
