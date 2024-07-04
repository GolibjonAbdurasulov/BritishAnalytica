using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.ServicePercent;
[Table("service_percent")]
public class ServicePercent : AuditableModelBase<long>
{
    [Column("service_name", TypeName = "jsonb")]public MultiLanguageField ServiceName { get; set; }
    [Column("service_percent_name")]public float ServicePerecnt { get; set; }
}