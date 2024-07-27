using DatabaseBroker.Repositories.Common;
using Entity.Models.FutureModel;
using Microsoft.EntityFrameworkCore;

namespace DatabaseBroker.Repositories.ReasonRepositories;

public class ReasonRepository : RepositoryBase<Reason,long>,IReasonRepository
{
    public ReasonRepository(DataContext dbContext) : base(dbContext)
    {
    }
}