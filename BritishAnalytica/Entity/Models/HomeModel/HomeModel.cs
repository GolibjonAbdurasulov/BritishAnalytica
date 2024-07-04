using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.HomeModel;

[Table("home_model")]
public class HomeModel : AuditableModelBase<long>
{
    [Column("text", TypeName = "jsonb")]public MultiLanguageField Title { get; set; }
    [Column("body", TypeName = "jsonb")]public MultiLanguageField Body { get; set; }
    [Column("image_id")]public List<Guid> ImageIds { get; set; }
}