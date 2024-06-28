using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.PPS.Planing;

[Table("planing")]
public class Planing : ModelBase<long>
{
    [Column("title")]public string Title { get; set; }
    [Column("body")]public string Body { get; set; }
}