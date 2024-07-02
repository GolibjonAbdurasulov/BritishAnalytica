using DatabaseBroker.Repositories.Common;
using DatabaseBroker.Repositories.PpsRepository.PlaningRepository;
using Entity.Attributes;
using Entity.Models.PPS.PlaningModel;
using Microsoft.EntityFrameworkCore;

namespace DatabaseBroker.Repositories.PpsRepository.ProjectRepository;
[Injectable]
public class PlaningRepository : RepositoryBase<Planing,long>, IPlaningRepository
{
    public PlaningRepository(DataContext dbContext) : base(dbContext)
    {
    }
}