using DatabaseBroker.Repositories.Common;
using Entity.Models.HomeModel;
using Microsoft.EntityFrameworkCore;

namespace DatabaseBroker.Repositories.HomeModelRepository;

public class HomeModelRepository : RepositoryBase<HomeModel,long>,IHomeModelRepository
{
    protected HomeModelRepository(DataContext dbContext) : base(dbContext)
    {
    }
}