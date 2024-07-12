using System;
using System.Linq;
using System.Threading.Tasks;
using DatabaseBroker.Repositories.ServicePercentRepository;
using DatabaseBroker.Repositories.TeamMemberRepository;
using Entity.Models.ServicePercent;
using Entity.Models.TeamMember;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public async Task<ResponseModelBase> CreateAsync(TeamMemberCreationDto dto)
    {
        var entity = new TeamMember
        {
            Id = 0,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            FullName = dto.FullName,
            Role = dto.Role,
            ImageId = dto.ImageId
        };
        var resEntity=await TeamMemberRepository.AddAsync(entity);
        var teamMemberDto = new TeamMemberDto
        {
            Id = resEntity.Id,
            FullName = resEntity.FullName,
            Role = resEntity.Role,
            ImageId = resEntity.ImageId
        };

        return new ResponseModelBase(teamMemberDto);
    }

    [HttpPut]
    [Authorize]
    public async Task<ResponseModelBase> UpdateAsync(TeamMemberDto dto)
    {
        var res = await TeamMemberRepository.GetByIdAsync(dto.Id); 
        res.FullName = dto.FullName;
        res.Role = dto.Role;
        res.ImageId = dto.ImageId;

        res.UpdatedAt=DateTime.Now;
        await TeamMemberRepository.UpdateAsync(res);
        return new ResponseModelBase(dto);
    }
    
    [HttpDelete]
    [Authorize]
    public async Task<ResponseModelBase> DeleteAsync(long id)
    {
        var res =  await TeamMemberRepository.GetByIdAsync(id);
        await TeamMemberRepository.RemoveAsync(res);
        return new ResponseModelBase(res);
    }

    [HttpGet]
    public async Task<ResponseModelBase> GetByIdAsync(long id)
    {
        var res =  await TeamMemberRepository.GetByIdAsync(id);
        var dto = new TeamMemberDto
        {
            Role = res.Role,
            ImageId = res.ImageId,
            FullName = res.FullName,
        };
        
        return new ResponseModelBase(dto);
    }
    
    
    [HttpGet]
    public async Task<ResponseModelBase> GetAllAsync()
    {
        var res = TeamMemberRepository.GetAllAsQueryable().ToList();
        List<TeamMemberDto> members = new List<TeamMemberDto>();
        foreach (var teamMember in res)
        {
            members.Add(new TeamMemberDto
            {
                Id = teamMember.Id,
                FullName = teamMember.FullName,
                Role = teamMember.Role,
                ImageId = teamMember.ImageId
            });
        }
        return new ResponseModelBase(members);
    }

}