using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.ServicePercent;
[Table("service_percent")]
public class ServicePercent : AuditableModelBase<long>
{
    [Column("service_name")]public string ServiceName { get; set; }
    [Column("service_percent")]public string ServicePerecnt { get; set; }
}