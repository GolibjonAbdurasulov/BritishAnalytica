using System;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.OurServices;
[Table("our_services",Schema = "british_analytica")]
public class OurService : AuditableModelBase<long>
{
    [Column("service_name")]public string ServiceName { get; set; }
    [Column("about_service")]public string AboutService { get; set; }
    [Column("service_icon_id")]public Guid ServiceIconId { get; set; }
}