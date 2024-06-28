using DatabaseBroker.Repositories.Common;
using Entity.Models.News;
using Microsoft.EntityFrameworkCore;

namespace DatabaseBroker.Repositories.NewsRepository;

public class NewsRepository : RepositoryBase<News,long> ,INewsRepository
{
    protected NewsRepository(DataContext dbContext) : base(dbContext)
    {
    }
}