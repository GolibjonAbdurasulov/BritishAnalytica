namespace Web.Controllers.MessageController.MessageDtos;

public class MessageCreationDto
{
    public string SenderFirstName { get; set; } 
    public string SenderLastName { get; set; }
    public string SenderEmail { get; set; } 
    public string PhoneNumber { get; set; } 
    public string MessageText { get; set; } 
    public bool IsRead { get; set; }
}