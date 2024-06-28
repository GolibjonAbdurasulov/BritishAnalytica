using DatabaseBroker.Repositories.Common;
using DatabaseBroker.Repositories.OurServices;
using Entity.Models.OurServices;

namespace DatabaseBroker.Repositories.OurServicesRepository;

public class OurServicesRepository : RepositoryBase<OurService,long> ,IOurServicesRepository
{
    protected OurServicesRepository(DataContext dbContext) : base(dbContext)
    {
    }
}