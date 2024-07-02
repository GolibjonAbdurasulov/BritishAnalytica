using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.Contact.EmailModel;
[Table("email")]
public class Email : ModelBase<long>
{
    [Column("name", TypeName = "jsonb")] public virtual MultiLanguageField Name { get; set; } = default!;
    [Column("email_address")]public virtual string EmailAddress { get; set; }
    [Column("web")]public virtual string Web { get; set; }
}