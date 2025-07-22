using DatabaseBroker.Repositories.Common;
using Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseBroker.Repositories.OurServiceRepository;

public class OurServiceRepository(DataContext dbContext)
    : RepositoryBase<OurService, long>(dbContext), IOurServiceRepository;