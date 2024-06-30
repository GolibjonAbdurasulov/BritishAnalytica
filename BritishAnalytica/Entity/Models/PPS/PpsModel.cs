using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.PPS;

[Table("pps_model")]
public class PpsModel : AuditableModelBase<long>
{
    [Column("name", TypeName = "jsonb")] public MultiLanguageField Name { get; set; } = default!;
    [Column("project")] public Project.Project Project { get; set; }
    [Column("planing")] public Planing.Planing Planing { get; set; }
    [Column("success")] public Success.Success Success { get; set; }
}