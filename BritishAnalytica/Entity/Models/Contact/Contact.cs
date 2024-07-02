using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;
using Entity.Models.Contact.EmailModel;
using Entity.Models.Contact.LocationModel;
using Entity.Models.Contact.PhoneNumberModel;

namespace Entity.Models.Contact;
[Table("contact")]
public class Contact : AuditableModelBase<long>
{
    [Column("name", TypeName = "jsonb")] public MultiLanguageField Name { get; set; } = default!;
    [Column("phone_number_id"),ForeignKey(nameof(PhoneNumber))] public long PhoneNumberId { get; set; }
    public virtual PhoneNumber PhoneNumber { get; set; }
    [Column("email_id"),ForeignKey(nameof(Email))] public long EmailId { get; set; }
    public virtual Email Email { get; set; }

    [Column("location_id"),ForeignKey(nameof(Location))] public long LocationId { get; set; }
    public virtual Location Location { get; set; }
}