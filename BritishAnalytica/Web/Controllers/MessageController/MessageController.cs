using DatabaseBroker.Repositories.MessageRepository;
using Entity.Models.MessageModel;
using Microsoft.AspNetCore.Mvc;
using Web.BackgroundServices;
using Web.Common;
using Web.Controllers.MessageController.MessageDtos;

namespace Web.Controllers.MessageController;

[ApiController]
[Route("[controller]/[action]")]
public class MessageController : ControllerBase
{
   
    private readonly TelegramBotService _botService;
    private readonly IMessageRepository _messageRepository;

    public MessageController(IMessageRepository messageRepository, TelegramBotService botService)
    {
        _messageRepository = messageRepository;
        _botService = botService;
    }

    [HttpPost]
    public async Task<ResponseModelBase> CreateAsync(MessageDto dto)
    {
        var entity = new Message
        {
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            SenderName = dto.SenderName,
            SenderEmail = dto.SenderEmail,
            Subject = dto.Subject,
            MessageText = dto.MessageText,
            IsRead = dto.IsRead
        };
        await _botService.SendMessageToAdminGroupAsync( "yangi user bor");
        await _messageRepository.AddAsync(entity);
        return new ResponseModelBase(dto);
    }

    
    
    [HttpPut]
    public async Task<ResponseModelBase> UpdateAsync(MessageDto dto, long id)
    {
        var res = await _messageRepository.GetByIdAsync(id);
        res.SenderEmail = dto.SenderEmail;
        res.SenderName = dto.SenderEmail;
        res.Subject = dto.Subject;
        res.IsRead = dto.IsRead;
        res.MessageText = dto.MessageText;

        await _messageRepository.UpdateAsync(res);
        return new ResponseModelBase(dto);
    }
    
    
    [HttpPut]
    public async Task<ResponseModelBase> ReadMessageAsync(long id)
    {
        var res = await _messageRepository.GetByIdAsync(id);
        
        res.IsRead =true;

        await _messageRepository.UpdateAsync(res);
        return new ResponseModelBase(id);
    }

    [HttpGet]
    public async Task<ResponseModelBase> GetAllNotReadMessagesAsync()
    {
        var res =  _messageRepository.GetAllAsQueryable().ToList().FindAll(message=>!message.IsRead);
      
        return new ResponseModelBase(res);
    }


    [HttpDelete]
    public async Task<ResponseModelBase> DeleteAsync(long id)
    {
        var res =await _messageRepository.GetByIdAsync(id);
        await _messageRepository.RemoveAsync(res);
        return new ResponseModelBase(res);
    }


    [HttpGet]
    public async Task<ResponseModelBase> GetAllAsync()
    {
        var res = _messageRepository.GetAllAsQueryable();

        return new ResponseModelBase(res);
    }
}