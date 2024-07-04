using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.PPS.SuccessModel;

[Table("success")]
public class Success : ModelBase<long>
{
    [Column("title", TypeName = "jsonb")]public MultiLanguageField Title { get; set; }
    [Column("body", TypeName = "jsonb")]public MultiLanguageField Body { get; set; }
}