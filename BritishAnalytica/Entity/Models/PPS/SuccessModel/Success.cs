using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.PPS.SuccessModel;

[Table("success")]
public class Success : ModelBase<long>
{
    [Column("name", TypeName = "jsonb")] public MultiLanguageField Name { get; set; } = default!;
    [Column("title")]public string Title { get; set; }
    [Column("body")]public string Body { get; set; }
}