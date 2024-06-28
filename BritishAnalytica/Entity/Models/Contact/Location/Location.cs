using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.Contact.Location;

[Table("location")]
public class Location : AuditableModelBase<long>
{
    [Column("country")]public string Country { get; set; }
    [Column("region")]public string Region { get; set; }
    [Column("district")]public string District { get; set; }
    [Column("street")]public string Street { get; set; }
    [Column("home")]public string Home { get; set; }
}