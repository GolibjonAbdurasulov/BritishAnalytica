using DatabaseBroker.Repositories.Common;
using Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseBroker.Repositories.OurResourcesRepository;

public class OurResourcesRepository(DataContext dbContext)
    : RepositoryBase<OurResources, long>(dbContext), IOurResourcesRepository;