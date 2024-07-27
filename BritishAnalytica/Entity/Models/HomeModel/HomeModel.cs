using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.HomeModel;

[Table("home_model")]
public class HomeModel : AuditableModelBase<long>
{
    [Column("body", TypeName = "jsonb")]public MultiLanguageField Text { get; set; }
    [Column("image_id")]public Guid ImageId { get; set; }
}