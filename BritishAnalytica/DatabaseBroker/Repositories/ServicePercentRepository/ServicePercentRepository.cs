using DatabaseBroker.Repositories.Common;
using Entity.Attributes;
using Entity.Models.ServicePercent;
using Microsoft.EntityFrameworkCore;

namespace DatabaseBroker.Repositories.ServicePercentRepository;
[Injectable]
public class ServicePercentRepository : RepositoryBase<ServicePercent,long>, IServicePercentRepository
{
    public ServicePercentRepository(DataContext dbContext) : base(dbContext)
    {
    }
}