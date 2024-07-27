using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.MessageModel;

[Table("messages")]
public class Message : AuditableModelBase<long>
{
    [Column("sender_first_name")]public string SenderFirstName { get; set; } 
    [Column("sender_last_name")]public string SenderLastName { get; set; } 
    [Column("sender_email")]public string SenderEmail { get; set; } 
    [Column("phone_number")]public string PhoneNumber { get; set; } 
    [Column("message_text")]public string MessageText { get; set; } 
    [Column("is_read")]public bool IsRead { get; set; } 
}