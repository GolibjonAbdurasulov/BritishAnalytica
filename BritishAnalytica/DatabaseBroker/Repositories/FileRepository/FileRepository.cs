using System;
using DatabaseBroker.Repositories.Common;
using Entity.Models.File;
namespace DatabaseBroker.Repositories.FileRepository;

public class FileRepository : RepositoryBase<FileModel,Guid>, IFileRepository
{
    protected FileRepository(DataContext dbContext) : base(dbContext)
    {
    }
}