using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.ServicePercent;
[Table("service_percent",Schema = "british_analytica")]
public class ServicePercent : AuditableModelBase<long>
{
    [Column("service_name")]public string ServiceName { get; set; }
    [Column("service_percent_name")]public string ServicePerecnt { get; set; }
}