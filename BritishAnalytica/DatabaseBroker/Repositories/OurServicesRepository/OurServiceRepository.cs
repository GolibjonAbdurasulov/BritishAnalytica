using DatabaseBroker.Repositories.Common;
using Entity.Models.OurService;
using Microsoft.EntityFrameworkCore;

namespace DatabaseBroker.Repositories.OurServicesRepository;

public class OurServiceRepository : RepositoryBase<OurService,long>,IOurServicesRepository
{
    public OurServiceRepository(DataContext dbContext) : base(dbContext)
    {
    }
}