using DatabaseBroker.Repositories.Common;
using Entity.Models.File;
using Microsoft.EntityFrameworkCore;

namespace DatabaseBroker.Repositories.FileRepository;

public class FileRepository : RepositoryBase<FileModel,Guid>, IFileRepository
{
    protected FileRepository(DataContext dbContext) : base(dbContext)
    {
    }
}