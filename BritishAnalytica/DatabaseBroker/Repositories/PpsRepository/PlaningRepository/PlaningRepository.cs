using DatabaseBroker.Repositories.Common;
using Entity.Attributes;
using Entity.Models.PPS.PlaningModel;
using Microsoft.EntityFrameworkCore;

namespace DatabaseBroker.Repositories.PpsRepository.PlaningRepository;
[Injectable]
public class PlaningRepository : RepositoryBase<Planing,long>
{
    public PlaningRepository(DataContext dbContext) : base(dbContext)
    {
    }
}