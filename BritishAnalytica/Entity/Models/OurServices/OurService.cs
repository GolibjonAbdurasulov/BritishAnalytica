using System;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.OurServices;
[Table("our_services")]
public class OurService : AuditableModelBase<long>
{
    [Column("name", TypeName = "jsonb")] public MultiLanguageField Name { get; set; } = default!;
    [Column("service_name")]public string ServiceName { get; set; }
    [Column("about_service")]public string AboutService { get; set; }
    [Column("service_icon_id")]public Guid ServiceIconId { get; set; }
}