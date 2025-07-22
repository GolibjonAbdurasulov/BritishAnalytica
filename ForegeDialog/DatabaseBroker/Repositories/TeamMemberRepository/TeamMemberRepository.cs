using DatabaseBroker.Repositories.Common;
using Entity.Attributes;
using Entity.Models.TeamMember;
using Microsoft.EntityFrameworkCore;

namespace DatabaseBroker.Repositories.TeamMemberRepository;
[Injectable]
public class TeamMemberRepository : RepositoryBase<TeamMember,long>,ITeamMemberRepository
{
    public TeamMemberRepository(DataContext dbContext) : base(dbContext)
    {
    }
}