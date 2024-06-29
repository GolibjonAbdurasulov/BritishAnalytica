using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.Motto;
[Table("motto",Schema = "british_analytica")]
public class Motto : AuditableModelBase<long>
{
    [Column("author")] public string Author { get; set; }
    [Column("text")] public string Text { get; set; }
}