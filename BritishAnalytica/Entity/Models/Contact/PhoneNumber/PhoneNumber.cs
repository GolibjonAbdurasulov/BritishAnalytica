using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using Entity.Models.Common;

namespace Entity.Models.Contact.PhoneNumber;

[Table("phone_number")]
public class PhoneNumber : AuditableModelBase<long>
{
    [Column("number")]public string Number { get; set; }
    [Column("working_time_start")]public string WorkingTimeStart { get; set; }
    [Column("working_time_stop")]public string WorkingTimeStop { get; set; }
    [Column("working_day_start")]public string WorkingDayStart { get; set; }
    [Column("working_day_stop")]public string WorkingDayStop { get; set; }
}