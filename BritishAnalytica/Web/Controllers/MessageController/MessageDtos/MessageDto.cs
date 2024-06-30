namespace Web.Controllers.MessageController.MessageDtos;

public class MessageDto
{
   public string SenderName { get; set; } 
   public string SenderEmail { get; set; } 
   public string Subject { get; set; } 
   public string MessageText { get; set; } 
   public bool IsRead { get; set; } 
}