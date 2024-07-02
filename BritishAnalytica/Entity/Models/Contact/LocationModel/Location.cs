using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.Contact.LocationModel;

[Table("location")]
public class Location : ModelBase<long>
{
    [Column("name", TypeName = "jsonb")] public  MultiLanguageField Name { get; set; } = default!;
    [Column("country")]public  string Country { get; set; }
    [Column("region")]public  string Region { get; set; }
    [Column("district")]public  string District { get; set; }
    [Column("street")]public  string Street { get; set; }
    [Column("home")]public  string Home { get; set; }
}