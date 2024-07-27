using DatabaseBroker.Repositories.Common;
using Entity.Attributes;
using Entity.Models.Skill;
using Microsoft.EntityFrameworkCore;

namespace DatabaseBroker.Repositories.SkillsRepository;
[Injectable]
public class SkillRepository: RepositoryBase<Skill,long> , ISkillRepository
{
    public SkillRepository(DataContext dbContext) : base(dbContext)
    {
    }
}