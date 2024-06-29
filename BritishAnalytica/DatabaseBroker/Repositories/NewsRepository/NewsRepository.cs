using DatabaseBroker.Repositories.Common;
using Entity.Attributes;
using Entity.Models.News;
using Microsoft.EntityFrameworkCore;

namespace DatabaseBroker.Repositories.NewsRepository;
[Injectable]
public class NewsRepository : RepositoryBase<News,long> ,INewsRepository
{
    public NewsRepository(DataContext dbContext) : base(dbContext)
    {
    }
}