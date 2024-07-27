using DatabaseBroker.Repositories.Common;
using Entity.Attributes;
using Entity.Models.OurServices;
using Microsoft.EntityFrameworkCore;

namespace DatabaseBroker.Repositories.OurValuesRepository;
[Injectable]
public class OurValuesRepository : RepositoryBase<OurValues,long>,IOurValuesRepository
{
    public OurValuesRepository(DataContext dbContext) : base(dbContext)
    {
    }
}