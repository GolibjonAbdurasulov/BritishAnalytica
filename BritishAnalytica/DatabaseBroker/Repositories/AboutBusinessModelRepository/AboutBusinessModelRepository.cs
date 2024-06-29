using DatabaseBroker.Repositories.Common;
using Entity.Attributes;
using Entity.Models.AboutBusinessModel;
using Microsoft.EntityFrameworkCore;

namespace DatabaseBroker.Repositories.AboutBusinessModelRepository;
[Injectable]
public class AboutBusinessModelRepository : RepositoryBase<AboutBusinessModel,long> , IAboutBusinessModelRepository
{
    public AboutBusinessModelRepository(DataContext dbContext) : base(dbContext)
    {
    }
}