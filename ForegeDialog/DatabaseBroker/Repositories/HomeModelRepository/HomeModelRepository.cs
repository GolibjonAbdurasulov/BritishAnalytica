using DatabaseBroker.Repositories.Common;
using Entity.Attributes;
using Entity.Models.HomeModel;
using Microsoft.EntityFrameworkCore;

namespace DatabaseBroker.Repositories.HomeModelRepository;
[Injectable]
public class HomeModelRepository : RepositoryBase<HomeModel,long>,IHomeModelRepository
{
    public HomeModelRepository(DataContext dbContext) : base(dbContext)
    {
    }
}