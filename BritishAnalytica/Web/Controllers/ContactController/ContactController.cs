using System;
using System.Linq;
using System.Threading.Tasks;
using DatabaseBroker.Repositories.ContactRepository;
using Entity.Models.Contact;
using Entity.Models.Contact.Email;
using Entity.Models.Contact.Location;
using Entity.Models.Contact.PhoneNumber;
using Microsoft.AspNetCore.Mvc;
using Web.Common;
using Web.Controllers.ContactController.ContactDtos;

namespace Web.Controllers.ContactController;

[ApiController]
[Route("[controller]/[action]")]
public class ContactController : ControllerBase 
{
    private IContactRepository ContactRepository { get; set; }

    public ContactController(IContactRepository contactRepository)
    {
        ContactRepository = contactRepository;
    }

    [HttpPost]
    public async Task<ResponseModelBase> CreateAsync( ContactDto dto)
    {
        var entity = new Contact
        {
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            Name = dto.Name,
            PhoneNumber = new PhoneNumber
            {
                Number = dto.PhoneNumberDto.Number,
                WorkingTimeStart = dto.PhoneNumberDto.WorkingTimeStart,
                WorkingTimeStop = dto.PhoneNumberDto.WorkingTimeStop,
                WorkingDayStart = dto.PhoneNumberDto.WorkingDayStart,
                WorkingDayStop = dto.PhoneNumberDto.WorkingDayStop,
                Name = dto.PhoneNumberDto.Name
            },
            Email = new Email
            {
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                EmailAddress = dto.EmailDto.EmailAddress,
                Web = dto.EmailDto.Web,
                Name = dto.EmailDto.Name
            },
            Location = new Location
            {
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Country = dto.LocationDto.Country,
                Region = dto.LocationDto.Region,
                District = dto.LocationDto.District,
                Street = dto.LocationDto.Street,
                Home = dto.LocationDto.Home,
                Name = dto.LocationDto.Name
            }
        };
        await ContactRepository.AddAsync(entity);
        return new ResponseModelBase(dto);
    }

    [HttpPut]
    public async Task<ResponseModelBase> UpdateEmailAsync(EmailDto dto)
    {
        var res = ContactRepository.LastOrDefault();
        res.Email.EmailAddress = dto.EmailAddress;
        res.Email.Web = dto.Web;
        res.UpdatedAt = DateTime.Now;
        await ContactRepository.UpdateAsync(res);
        return new ResponseModelBase(dto);
    }

    [HttpPut]
    public async Task<ResponseModelBase> UpdatePhoneNumberAsync( PhoneNumberDto dto)
    {
        var res =  ContactRepository.LastOrDefault();
        res.PhoneNumber.Number = dto.Number;
        res.PhoneNumber.WorkingDayStart = dto.WorkingDayStart;
        res.PhoneNumber.WorkingDayStop = dto.WorkingDayStop;
        res.PhoneNumber.WorkingTimeStart = dto.WorkingTimeStart;
        res.PhoneNumber.WorkingTimeStop = dto.WorkingTimeStop;
        res.UpdatedAt=DateTime.Now;
        await ContactRepository.UpdateAsync(res);
        return new ResponseModelBase(dto);
    }
  
    [HttpPut]
    public async Task<ResponseModelBase> UpdateLocationAsync( LocationDto dto)
    {
        var res =  ContactRepository.LastOrDefault();
        res.Location.Country = dto.Country;
        res.Location.District = dto.District;
        res.Location.Street = dto.Street;
        res.Location.Home = dto.Home;
        res.Location.Region = dto.Region;
        res.UpdatedAt=DateTime.Now;
        
        await ContactRepository.UpdateAsync(res);
        return new ResponseModelBase(dto);
    }
    
    
    [HttpDelete]
    public async Task<ResponseModelBase> DeleteAsync()
    {
        var res =  ContactRepository.LastOrDefault();
        await ContactRepository.RemoveAsync(res);
        return new ResponseModelBase(res);
    }
    [HttpGet]
    public async Task<ResponseModelBase> GetAsync()
    {
        var res =  ContactRepository.LastOrDefault();
        var dto = new ContactDto
        {
            EmailDto = new EmailDto
            {
                EmailAddress = res.Email.EmailAddress,
                Web = res.Email.Web
            },
            PhoneNumberDto = new PhoneNumberDto
            {
                Number = res.PhoneNumber.Number,
                WorkingTimeStart = res.PhoneNumber.WorkingTimeStart,
                WorkingTimeStop = res.PhoneNumber.WorkingTimeStop,
                WorkingDayStart = res.PhoneNumber.WorkingDayStart,
                WorkingDayStop = res.PhoneNumber.WorkingDayStop
            },
            LocationDto = new LocationDto
            {
                Country = res.Location.Country,
                Region =  res.Location.Region,
                District =  res.Location.District,
                Street =  res.Location.Street,
                Home =  res.Location.Home
            }
        };
        return new ResponseModelBase(dto);
    }
}