using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.Contact.PhoneNumberModel;

[Table("phone_number")]
public class PhoneNumber : ModelBase<long>
{
    [Column("name", TypeName = "jsonb")] public virtual MultiLanguageField Name { get; set; } = default!;
    [Column("number")]public virtual string Number { get; set; }
    [Column("working_time_start")]public virtual string WorkingTimeStart { get; set; }
    [Column("working_time_stop")]public virtual string WorkingTimeStop { get; set; }
    [Column("working_day_start")]public virtual string WorkingDayStart { get; set; }
    [Column("working_day_stop")]public virtual string WorkingDayStop { get; set; }
}