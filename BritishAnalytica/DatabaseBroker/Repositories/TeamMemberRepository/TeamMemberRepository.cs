using DatabaseBroker.Repositories.Common;
using Entity.Models.TeamMember;
using Microsoft.EntityFrameworkCore;

namespace DatabaseBroker.Repositories.TeamMemberRepository;

public class TeamMemberRepository : RepositoryBase<TeamMember,long>,ITeamMemberRepository
{
    protected TeamMemberRepository(DataContext dbContext) : base(dbContext)
    {
    }
}