using DatabaseBroker.Repositories.Common;
using Entity.Models.TeamMember;

namespace DatabaseBroker.Repositories.TeamMemberRepository;

public interface ITeamMemberRepository : IRepositoryBase<TeamMember,long>
{
    
}