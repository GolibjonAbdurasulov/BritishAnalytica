using DatabaseBroker.Repositories.Common;
using Entity.Attributes;
using Entity.Models.FutureModel;
using Microsoft.EntityFrameworkCore;

namespace DatabaseBroker.Repositories.FutureRepository;
[Injectable]
public class FutureRepository : RepositoryBase<Future,long>, IFutureRepository
{
    public FutureRepository(DataContext dbContext) : base(dbContext)
    {
    }
}