using DatabaseBroker.Repositories.Common;
using Entity.Attributes;
using Entity.Models.PPS.SuccessModel;
using Microsoft.EntityFrameworkCore;

namespace DatabaseBroker.Repositories.PpsRepository.SuccessRepository;
[Injectable]
public class SuccessRepository : RepositoryBase<Success,long>
{
    public SuccessRepository(DataContext dbContext) : base(dbContext)
    {
    }
}