using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.HomeModel;

[Table("home_model")]
public class HomeModel : AuditableModelBase<long>
{
    [Column("name", TypeName = "jsonb")] public MultiLanguageField Name { get; set; } = default!;
    [Column("text")]public string Title { get; set; }
    [Column("body")]public string Body { get; set; }
    [Column("image_id")]public ICollection<Guid> ImageIds { get; set; }
}