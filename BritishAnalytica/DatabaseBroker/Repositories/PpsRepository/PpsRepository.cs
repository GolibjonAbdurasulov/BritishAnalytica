using DatabaseBroker.Repositories.Common;
using Entity.Attributes;
using Entity.Models.PPS;
using Microsoft.EntityFrameworkCore;

namespace DatabaseBroker.Repositories.PpsRepository;
[Injectable]
public class PpsRepository : RepositoryBase<PpsModel,long>,IPpsRepository
{
    public PpsRepository(DataContext dbContext) : base(dbContext)
    {
    }
}