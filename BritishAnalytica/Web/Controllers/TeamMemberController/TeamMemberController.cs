using System;
using System.Linq;
using System.Threading.Tasks;
using DatabaseBroker.Repositories.ServicePercentRepository;
using DatabaseBroker.Repositories.TeamMemberRepository;
using Entity.Models.ServicePercent;
using Entity.Models.TeamMember;
using Microsoft.AspNetCore.Mvc;
using Web.Common;
using Web.Controllers.ServicePercentController.ServicePercentDtos;
using Web.Controllers.TeamMemberController.TeamMemberDtos;

namespace Web.Controllers.TeamMemberController;

[ApiController]
[Route("[controller]/[action]")]
public class TeamMemberController : ControllerBase
{
    private ITeamMemberRepository TeamMemberRepository { get; set; }

    public TeamMemberController(ITeamMemberRepository teamMemberRepository)
    {
        TeamMemberRepository = teamMemberRepository;
    }

    [HttpPost]
    public async Task<ResponseModelBase> CreateAsync(TeamMemberDto dto)
    {
        var entity = new TeamMember
        {
            Id = 0,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            Name = dto.Name,
            Role = dto.Role,
            ImageId = dto.ImageId
        };
        await TeamMemberRepository.AddAsync(entity);
        return new ResponseModelBase(dto);
    }

    [HttpPut]
    public async Task<ResponseModelBase> UpdateAsync(TeamMemberDto dto, long id)
    {
        var res = await TeamMemberRepository.GetByIdAsync(id);
        res.Name = dto.Name;
        res.Role = dto.Role;
        res.ImageId = dto.ImageId;

        await TeamMemberRepository.UpdateAsync(res);
        return new ResponseModelBase(dto);
    }
    
    [HttpDelete]
    public async Task<ResponseModelBase> DeleteAsync(long id)
    {
        var res = TeamMemberRepository.FirstOrDefault();
        await TeamMemberRepository.RemoveAsync(res);
        return new ResponseModelBase(res);
    }

    [HttpGet]
    public async Task<ResponseModelBase> GetByIdAsync(long id)
    {
        var res = TeamMemberRepository.LastOrDefault();
        var dto = new TeamMemberDto
        {
            Name = res.Name,
            Role = res.Role,
            ImageId = res.ImageId
        };
        
        return new ResponseModelBase(dto);
    }
    
    
    [HttpGet]
    public async Task<ResponseModelBase> GetAllAsync()
    {
        var res = TeamMemberRepository.GetAllAsQueryable().ToList();
        return new ResponseModelBase(res);
    }

}