using System;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.OurServices;
[Table("our_services")]
public class OurService : AuditableModelBase<long>
{
    [Column("service_name", TypeName = "jsonb")]public MultiLanguageField ServiceName { get; set; }
    [Column("about_service", TypeName = "jsonb")]public MultiLanguageField AboutService { get; set; }
    [Column("service_icon_id")]public Guid ServiceIconId { get; set; }
}