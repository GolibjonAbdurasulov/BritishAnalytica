namespace Web.Controllers.MessageController.MessageDtos;

public class MessageCreationDto
{
    public string FirstName { get; set; } 
    public string LastName { get; set; } 
    public string SenderEmail { get; set; } 
    public string Subject { get; set; } 
    public string MessageText { get; set; } 
    public bool IsRead { get; set; }
}