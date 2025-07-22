using DatabaseBroker.Repositories.Common;
using Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseBroker.Repositories.OurValuedClientsRepository;

public class OurValuedClientsRepository(DataContext dbContext)
    : RepositoryBase<OurValuedClients, long>(dbContext), IOurValuedClientsRepository;