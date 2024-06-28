using DatabaseBroker.Repositories.Common;
using Entity.Models.PPS;
using Microsoft.EntityFrameworkCore;

namespace DatabaseBroker.Repositories.PpsRepository;

public class PpsRepository : RepositoryBase<PpsModel,long>,IPpsRepository
{
    protected PpsRepository(DataContext dbContext) : base(dbContext)
    {
    }
}