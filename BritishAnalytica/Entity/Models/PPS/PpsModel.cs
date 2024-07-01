using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;
using Entity.Models.PPS.PlaningModel;
using Entity.Models.PPS.ProjectModel;
using Entity.Models.PPS.SuccessModel;

namespace Entity.Models.PPS;

[Table("pps_model")]
public class PpsModel : AuditableModelBase<long>
{
    [Column("name", TypeName = "jsonb")] public MultiLanguageField Name { get; set; } = default!;
    [Column("project_id"),ForeignKey(nameof(Project))] public long ProjectId { get; set; }
    public virtual Project Project { get; set; }

    [Column("planing_id"), ForeignKey(nameof(Planing)) ]
    public long PlaningId { get; set; }
    public virtual Planing Planing { get; set; }
    
    [Column("success_id"),ForeignKey(nameof(Success))] public long SuccessId { get; set; }
    public virtual Success Success { get; set; }
}