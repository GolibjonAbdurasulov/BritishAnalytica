using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.FutureModel;
[Table("reasons")]
public class Reason : ModelBase<long>
{
    [Column("text", TypeName = "jsonb")]public MultiLanguageField Text { get; set; }
}