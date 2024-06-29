using DatabaseBroker.Repositories.Common;
using Entity.Attributes;
using Entity.Models.OurServices;

namespace DatabaseBroker.Repositories.OurServicesRepository;
[Injectable]
public class OurServicesRepository : RepositoryBase<OurService,long> ,IOurServicesRepository
{
    public OurServicesRepository(DataContext dbContext) : base(dbContext)
    {
    }
}