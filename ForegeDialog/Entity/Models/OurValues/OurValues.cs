using System;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.OurServices;
[Table("our_values")]
public class OurValues : AuditableModelBase<long>
{
    [Column("value_name", TypeName = "jsonb")]public MultiLanguageField ValueName { get; set; }
    [Column("about_value", TypeName = "jsonb")]public MultiLanguageField AboutValue { get; set; }
}