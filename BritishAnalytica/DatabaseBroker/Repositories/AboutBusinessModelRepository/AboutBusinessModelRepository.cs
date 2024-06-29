using DatabaseBroker.Repositories.Common;
using Entity.Models.AboutBusinessModel;
using Microsoft.EntityFrameworkCore;

namespace DatabaseBroker.Repositories.AboutBusinessModelRepository;

public class AboutBusinessModelRepository : RepositoryBase<AboutBusinessModel,long> , IAboutBusinessModelRepository
{
    protected AboutBusinessModelRepository(DataContext dbContext) : base(dbContext)
    {
    }
}