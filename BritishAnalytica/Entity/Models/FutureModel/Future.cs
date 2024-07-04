using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.FutureModel;
[Table("futures")]
public class Future : ModelBase<long>
{
    [Column("title", TypeName = "jsonb")]public MultiLanguageField Text { get; set; }
}