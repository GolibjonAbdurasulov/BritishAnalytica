using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models;
[Table("OurServices")]
public class OurService : ModelBase<long>
{
    [Column("title", TypeName = "jsonb")]public virtual MultiLanguageField Title { get; set; }
    [Column("description", TypeName = "jsonb")]public virtual MultiLanguageField Description { get; set; }
}