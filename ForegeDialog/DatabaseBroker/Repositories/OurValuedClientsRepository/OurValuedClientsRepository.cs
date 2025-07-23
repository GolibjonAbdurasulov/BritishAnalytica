using DatabaseBroker.Repositories.Common;
using Entity.Attributes;
using Entity.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace DatabaseBroker.Repositories.OurValuedClientsRepository;
[Injectable]
public class OurValuedClientsRepository(DataContext dbContext)
    : RepositoryBase<OurValuedClients, long>(dbContext), IOurValuedClientsRepository;