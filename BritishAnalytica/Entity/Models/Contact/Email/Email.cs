using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.Contact.Email;
[Table("email")]
public class Email : AuditableModelBase<long>
{
    [Column("email_address")]public string EmailAddress { get; set; }
    [Column("web")]public string Web { get; set; }
}