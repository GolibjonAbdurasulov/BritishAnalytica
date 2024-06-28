using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;
using Entity.Models.PPS.Project;

namespace Entity.Models.Contact;
[Table(("contact"))]
public class Contact : AuditableModelBase<long>
{
    [Column("phone_number")] public PhoneNumber.PhoneNumber PhoneNumber { get; set; }
    [Column("email")] public Email.Email Email { get; set; }
    [Column("location")] public Location.Location Location { get; set; }
}