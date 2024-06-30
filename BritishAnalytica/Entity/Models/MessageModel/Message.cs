using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.MessageModel;

[Table("messages")]
public class Message : AuditableModelBase<long>
{
    [Column("sender_name")]public string SenderName { get; set; } 
    [Column("sender_email")]public string SenderEmail { get; set; } 
    [Column("subject")]public string Subject { get; set; } 
    [Column("message_text")]public string MessageText { get; set; } 
    [Column("is_read")]public bool IsRead { get; set; } 
}