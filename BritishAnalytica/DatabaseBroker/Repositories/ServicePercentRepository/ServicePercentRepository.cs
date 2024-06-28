using DatabaseBroker.Repositories.Common;
using Entity.Models.ServicePercent;
using Microsoft.EntityFrameworkCore;

namespace DatabaseBroker.Repositories.ServicePercentRepository;

public class ServicePercentRepository : RepositoryBase<ServicePercent,long>, IServicePercentRepository
{
    protected ServicePercentRepository(DataContext dbContext) : base(dbContext)
    {
    }
}