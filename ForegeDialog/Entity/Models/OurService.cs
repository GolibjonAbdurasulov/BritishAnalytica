using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models;
[Table("OurServices")]
public class OurService : ModelBase<long>
{
    [Column("title", TypeName = "jsonb")]public MultiLanguageField Title { get; set; }
    [Column("description", TypeName = "jsonb")]public MultiLanguageField Description { get; set; }
}