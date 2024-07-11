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
    public async Task<ResponseModelBase> CreateAsync(MessageCreationDto dto)
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
        var resEntity=await _messageRepository.AddAsync(entity);
        var messageDto = new MessageDto
        {
            Id = resEntity.Id,
            SenderName = dto.SenderName,
            SenderEmail = dto.SenderEmail,
            Subject = dto.Subject,
            MessageText = dto.MessageText,
            IsRead = false
        };

        await _botService.SendMessageToAdminGroupAsync( messageDto);
        return new ResponseModelBase(messageDto);
    }

    
    
    [HttpPut]
    public async Task<ResponseModelBase> UpdateAsync(MessageDto dto)
    {
        var res = await _messageRepository.GetByIdAsync(dto.Id);
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
        var res =  _messageRepository.GetAllAsQueryable().ToList().FindAll(message=>message.IsRead==false);
      
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
    public async Task<ResponseModelBase> GetByAsync(long id)
    {
        var res =await _messageRepository.GetByIdAsync(id);
        MessageDto resDto = new MessageDto
        {
            Id = res.Id,
            SenderName = res.SenderName,
            SenderEmail = res.SenderEmail,
            Subject = res.Subject,
            MessageText = res.MessageText,
            IsRead = res.IsRead
        };
        return new ResponseModelBase(res);
    }


    [HttpGet]
    public async Task<ResponseModelBase> GetAllAsync()
    {
        var res = _messageRepository.GetAllAsQueryable().ToList();
        List<MessageDto> messageDtos = new List<MessageDto>();
        foreach (Message message in res)
        {
            messageDtos.Add(new MessageDto
            {
                Id = message.Id,
                SenderName = message.SenderName,
                SenderEmail = message.SenderEmail,
                Subject = message.Subject,
                MessageText = message.MessageText,
                IsRead = message.IsRead
            });
        }
        return new ResponseModelBase(messageDtos);
    }
}