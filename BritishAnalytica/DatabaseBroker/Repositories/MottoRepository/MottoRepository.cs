using DatabaseBroker.Repositories.Common;
using Entity.Models.Motto;
using Microsoft.EntityFrameworkCore;

namespace DatabaseBroker.Repositories.MottoRepository;

public class MottoRepository : RepositoryBase<Motto,long>, IMottoRepository
{
    protected MottoRepository(DataContext dbContext) : base(dbContext)
    {
    }
}