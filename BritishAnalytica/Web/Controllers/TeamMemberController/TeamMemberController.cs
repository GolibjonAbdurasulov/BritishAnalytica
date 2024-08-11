using DatabaseBroker.Repositories.SkillsRepository;
using DatabaseBroker.Repositories.TeamMemberRepository;
using Entity.Models.Skills;
using Entity.Models.TeamMember;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Common;
using Web.Controllers.TeamMemberController.TeamMemberDtos;

namespace Web.Controllers.TeamMemberController;

[ApiController]
[Route("[controller]/[action]")]
public class TeamMemberController : ControllerBase
{
    private ITeamMemberRepository TeamMemberRepository { get; set; }
    private ISkillRepository SkillRepository { get; set; }

    public TeamMemberController(ITeamMemberRepository teamMemberRepository, ISkillRepository skillRepository)
    {
        TeamMemberRepository = teamMemberRepository;
        SkillRepository = skillRepository;
    }

    [HttpPost]
    [Authorize]
    public async Task<ResponseModelBase> CreateAsync(TeamMemberCreationDto dto)
    {
        // Create Skills
        List<Skill> skills = new List<Skill>();
        foreach (SkillDto skillDto in dto.Skills)
        {
            skills.Add(new Skill
            {
                Text = skillDto.Text
            });
        }

        // Create TeamMember with Skills
        var entity = new TeamMember
        {
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            FullName = dto.FullName,
            Role = dto.Role,
            Skills = skills, // Skills are attached to the TeamMember
            ImageId = dto.ImageId
        };
    
        var resEntity = await TeamMemberRepository.AddAsync(entity);
    
        // Prepare the response DTO
        List<SkillDto> dtos = new List<SkillDto>();
        foreach (Skill skill in resEntity.Skills)
        {
            dtos.Add(new SkillDto
            {
                Text = skill.Text
            });
        }
    
        var teamMemberDto = new TeamMemberDto
        {
            Id = resEntity.Id,
            FullName = resEntity.FullName,
            Role = resEntity.Role,
            Skills = dtos,
            ImageId = resEntity.ImageId
        };

        return new ResponseModelBase(teamMemberDto);
    }

    // [HttpPost]
    // [Authorize]
    // public async Task<ResponseModelBase> CreateAsync(TeamMemberCreationDto dto)
    // {
    //
    //     List<Skill> skills = new List<Skill>();
    //     foreach (SkillDto skillDto in dto.Skills)
    //     {
    //         skills.Add(new Skill
    //         {
    //             Text = skillDto.Text
    //         });
    //     }
    //     var entity = new TeamMember
    //     {
    //         CreatedAt = DateTime.Now,
    //         UpdatedAt = DateTime.Now,
    //         FullName = dto.FullName,
    //         Role = dto.Role,
    //         Skills = skills,
    //         ImageId = dto.ImageId
    //     };
    //     var resEntity=await TeamMemberRepository.AddAsync(entity);
    //  
    //     
    //     List<SkillDto> dtos = new List<SkillDto>();
    //     foreach (Skill skill in entity.Skills)
    //     {
    //         await SkillRepository.AddAsync(new Skill
    //         {
    //             Text = skill.Text
    //         });
    //     }
    //     
    //    
    //     var teamMemberDto = new TeamMemberDto
    //     {
    //         Id = resEntity.Id,
    //         FullName = resEntity.FullName,
    //         Role = resEntity.Role,
    //         Skills = dtos,
    //         ImageId = resEntity.ImageId
    //     };
    //
    //     return new ResponseModelBase(teamMemberDto);
    // }

    [HttpPut]
    [Authorize]
    public async Task<ResponseModelBase> UpdateAsync(TeamMemberDto dto)
    {
        var res = await TeamMemberRepository.GetByIdAsync(dto.Id); 
        res.FullName = dto.FullName;
        res.Role = dto.Role;
        res.ImageId = dto.ImageId;
        List<Skill> skills = new List<Skill>();
        foreach (SkillDto skillDto in dto.Skills)
        {
            skills.Add(new Skill
            {
                Text = skillDto.Text,
            });
        }
        res.Skills = skills;

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
        List<SkillDto> dtos = new List<SkillDto>();
        foreach (Skill skill in res.Skills)
        {
            dtos.Add(new SkillDto
            {
                Text = skill.Text
            });
        }
        var dto = new TeamMemberDto
        {
            Role = res.Role,
            ImageId = res.ImageId,
            FullName = res.FullName,
            Skills = dtos
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
            List<SkillDto> dtos = new List<SkillDto>();
        
            foreach (Skill skill in teamMember.Skills)
            {
                dtos.Add(new SkillDto
                {
                    Text = skill.Text
                });
           
            }
            members.Add(new TeamMemberDto
            {
                Id = teamMember.Id,
                FullName = teamMember.FullName,
                Role = teamMember.Role,
                Skills = dtos,
                ImageId = teamMember.ImageId
            });
        }
        return new ResponseModelBase(members);
    }
}