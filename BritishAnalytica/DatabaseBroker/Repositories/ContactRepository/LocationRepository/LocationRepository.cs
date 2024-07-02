using DatabaseBroker.Repositories.Common;
using Entity.Attributes;
using Entity.Models.Contact.LocationModel;
using Microsoft.EntityFrameworkCore;

namespace DatabaseBroker.Repositories.ContactRepository.LocationRepository;
[Injectable]
public class LocationRepository : RepositoryBase<Location,long>, ILocationRepository
{
    public LocationRepository(DataContext dbContext) : base(dbContext)
    {
    }
}