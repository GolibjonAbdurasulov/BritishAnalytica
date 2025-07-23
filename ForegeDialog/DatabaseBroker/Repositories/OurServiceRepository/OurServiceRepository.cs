using DatabaseBroker.Repositories.Common;
using Entity.Attributes;
using Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseBroker.Repositories.OurServiceRepository;
[Injectable]
public class OurServiceRepository(DataContext dbContext)
    : RepositoryBase<OurService, long>(dbContext), IOurServiceRepository;