using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.PPS.PlaningModel;

[Table("planing")]
public class Planing  : ModelBase<long>
{
    [Column("title", TypeName = "jsonb")]public MultiLanguageField Title { get; set; }
    [Column("body", TypeName = "jsonb")]public MultiLanguageField Body { get; set; }
}