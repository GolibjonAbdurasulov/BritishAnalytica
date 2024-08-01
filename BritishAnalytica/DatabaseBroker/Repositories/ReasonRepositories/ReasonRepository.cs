using DatabaseBroker.Repositories.Common;
using Entity.Attributes;
using Entity.Models.ReasonModel;
using Microsoft.EntityFrameworkCore;

namespace DatabaseBroker.Repositories.ReasonRepositories;
[Injectable]
public class ReasonRepository : RepositoryBase<Reason,long>,IReasonRepository
{
    public ReasonRepository(DataContext dbContext) : base(dbContext)
    {
    }
}