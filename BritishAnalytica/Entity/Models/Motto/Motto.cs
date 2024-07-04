using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.Motto;
[Table("motto")]
public class Motto : AuditableModelBase<long>
{
    [Column("author")] public string Author { get; set; }
    [Column("text", TypeName = "jsonb")] public MultiLanguageField Text { get; set; }
}