using DatabaseBroker.Repositories.Common;
using Entity.Models.AboutBusinessModel;
using Microsoft.EntityFrameworkCore;

namespace DatabaseBroker.Repositories.AboutBusinessModelRepository;

public class AboutBusinessModelRepository : RepositoryBase<AboutBusinessModel,long>
{
    protected AboutBusinessModelRepository(DbContext dbContext) : base(dbContext)
    {
    }
}