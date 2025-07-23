using DatabaseBroker.Repositories.Common;
using Entity.Attributes;
using Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseBroker.Repositories.OurResourcesRepository;
[Injectable]
public class OurResourcesRepository(DataContext dbContext)
    : RepositoryBase<OurResources, long>(dbContext), IOurResourcesRepository;