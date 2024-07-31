using DatabaseBroker.Repositories.Common;
using Entity.Attributes;
using Entity.Models.OurService;
using Microsoft.EntityFrameworkCore;

namespace DatabaseBroker.Repositories.OurServicesRepository;
[Injectable]
public class OurServiceRepository : RepositoryBase<OurService,long>,IOurServicesRepository
{
    public OurServiceRepository(DataContext dbContext) : base(dbContext)
    {
    }
}