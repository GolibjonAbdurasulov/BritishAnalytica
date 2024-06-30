using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.ServicePercent;
[Table("service_percent")]
public class ServicePercent : AuditableModelBase<long>
{
    [Column("name", TypeName = "jsonb")] public MultiLanguageField Name { get; set; } = default!;
    [Column("service_name")]public string ServiceName { get; set; }
    [Column("service_percent_name")]public string ServicePerecnt { get; set; }
}