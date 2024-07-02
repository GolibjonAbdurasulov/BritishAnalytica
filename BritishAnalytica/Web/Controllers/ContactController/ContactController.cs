using System;
using System.Linq;
using System.Threading.Tasks;
using DatabaseBroker.Repositories.ContactRepository;
using DatabaseBroker.Repositories.ContactRepository.EmailRepository;
using DatabaseBroker.Repositories.ContactRepository.LocationRepository;
using DatabaseBroker.Repositories.ContactRepository.PhoneNumberRepository;
using Entity.Models.Contact;
using Entity.Models.Contact.EmailModel;
using Entity.Models.Contact.LocationModel;
using Entity.Models.Contact.PhoneNumberModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Common;
using Web.Controllers.ContactController.ContactDtos;

namespace Web.Controllers.ContactController;

[ApiController]
[Route("[controller]/[action]")]
public class ContactController : ControllerBase 
{
    private IContactRepository ContactRepository { get; set; }
    private IEmailRepository EmailRepository { get; set; }
    private IPhoneNumberRepository PhoneNumberRepository { get; set; }
    private ILocationRepository LocationRepository { get; set; }

    public ContactController(IContactRepository contactRepository, IEmailRepository emailRepository, IPhoneNumberRepository phoneNumberRepository, ILocationRepository locationRepository)
    {
        ContactRepository = contactRepository;
        EmailRepository = emailRepository;
        PhoneNumberRepository = phoneNumberRepository;
        LocationRepository = locationRepository;
    }

    [HttpPost]
    [Authorize]
    public async Task<ResponseModelBase> CreateAsync( ContactDto dto)
    {
        var email = new Email
        {
            Name = dto.EmailDto.Name,
            EmailAddress = dto.EmailDto.EmailAddress,
            Web = dto.EmailDto.Web
        };
        var resEmail =await EmailRepository.AddAsync(email);

        var phoneNumber = new PhoneNumber
        {
            Number = dto.PhoneNumberDto.Number,
            WorkingTimeStart = dto.PhoneNumberDto.WorkingTimeStart,
            WorkingTimeStop = dto.PhoneNumberDto.WorkingTimeStop,
            WorkingDayStart = dto.PhoneNumberDto.WorkingDayStart,
            WorkingDayStop = dto.PhoneNumberDto.WorkingDayStop,
            Name = dto.PhoneNumberDto.Name
        };
        var resPhoneNumber = await PhoneNumberRepository.AddAsync(phoneNumber);


        var location = new Location
        {
            Country = dto.LocationDto.Country,
            Region = dto.LocationDto.Region,
            District = dto.LocationDto.District,
            Street = dto.LocationDto.Street,
            Home = dto.LocationDto.Home,
            Name = dto.LocationDto.Name
        };
        var resLocation = await LocationRepository.AddAsync(location);
        
        var entity = new Contact
        {
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            Name = dto.Name,
            PhoneNumberId = resPhoneNumber.Id,
            PhoneNumber =resPhoneNumber ,
            EmailId = resEmail.Id,
            Email =resEmail,
            LocationId = resLocation.Id,
            Location = resLocation
        };
        await ContactRepository.AddAsync(entity);
        return new ResponseModelBase(dto);
    }

    [HttpPut]
    [Authorize]
    public async Task<ResponseModelBase> UpdateEmailAsync(EmailDto dto)
    {
        var res =  await ContactRepository.FirstOrDefaultAsync();
        res.Email.EmailAddress = dto.EmailAddress;
        res.Email.Web = dto.Web;
        res.UpdatedAt = DateTime.Now;
        res.Email.Name = dto.Name;
        await ContactRepository.UpdateAsync(res);
        return new ResponseModelBase(dto);
    }

    [HttpPut]
    [Authorize]
    public async Task<ResponseModelBase> UpdatePhoneNumberAsync( PhoneNumberDto dto)
    {
        var res =   await ContactRepository.FirstOrDefaultAsync();
        res.PhoneNumber.Number = dto.Number;
        res.PhoneNumber.WorkingDayStart = dto.WorkingDayStart;
        res.PhoneNumber.WorkingDayStop = dto.WorkingDayStop;
        res.PhoneNumber.WorkingTimeStart = dto.WorkingTimeStart;
        res.PhoneNumber.WorkingTimeStop = dto.WorkingTimeStop;
        res.UpdatedAt=DateTime.Now;
        res.PhoneNumber.Name = dto.Name;
        await ContactRepository.UpdateAsync(res);
        return new ResponseModelBase(dto);
    }
  
    [HttpPut]
    [Authorize]
    public async Task<ResponseModelBase> UpdateLocationAsync( LocationDto dto)
    {
        var res =  await ContactRepository.FirstOrDefaultAsync();
        res.Location.Country = dto.Country;
        res.Location.District = dto.District;
        res.Location.Street = dto.Street;
        res.Location.Home = dto.Home;
        res.Location.Region = dto.Region;
        res.UpdatedAt=DateTime.Now;
        res.Location.Name = dto.Name;
        await ContactRepository.UpdateAsync(res);
        return new ResponseModelBase(dto);
    }
    
    
    [HttpDelete]
    [Authorize]
    public async Task<ResponseModelBase> DeleteAsync()
    {
        var contact =  await ContactRepository.FirstOrDefaultAsync();
        await ContactRepository.RemoveAsync(contact);

        var email = await EmailRepository.GetByIdAsync(contact.EmailId);
        await EmailRepository.RemoveAsync(email);

        var location = await LocationRepository.GetByIdAsync(contact.LocationId);
        await LocationRepository.RemoveAsync(location);

        var phoneNumber = await PhoneNumberRepository.GetByIdAsync(contact.PhoneNumberId);
        await PhoneNumberRepository.RemoveAsync(phoneNumber);
        
        return new ResponseModelBase(contact);
    }
    
    
    [HttpGet]
    public async Task<ResponseModelBase> GetAsync()
    {
        var res =   await ContactRepository.FirstOrDefaultAsync();
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