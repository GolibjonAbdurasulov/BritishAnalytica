using DatabaseBroker.Repositories.Common;
using Entity.Attributes;
using Entity.Models.Motto;
using Microsoft.EntityFrameworkCore;

namespace DatabaseBroker.Repositories.MottoRepository;
[Injectable]
public class MottoRepository : RepositoryBase<Motto,long>, IMottoRepository
{
    public MottoRepository(DataContext dbContext) : base(dbContext)
    {
    }
}