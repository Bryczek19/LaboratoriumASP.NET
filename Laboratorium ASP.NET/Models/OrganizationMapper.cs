using Laboratorium_ASP.NET.Models.Services;

namespace Laboratorium_ASP.NET.Models;

public class OrganizationMapper
{
    public static OrganizationEntity ToEntity(OrganizationModel model)
    {
        return new OrganizationEntity
        {
            Id = model.Id,
            Name = model.Name,
            NIP = model.NIP,
            REGON = model.REGON,
            Address = new Services.Address
            {
                City = model.Address?.City,
                Street = model.Address?.Street
            }
        };
    }

    public static OrganizationModel FromEntity(OrganizationEntity entity)
    {
        return new OrganizationModel
        {
            Id = entity.Id,
            Name = entity.Name,
            NIP = entity.NIP,
            REGON = entity.REGON,
            Address = new Address
            {
                
            }
        };
    }
}