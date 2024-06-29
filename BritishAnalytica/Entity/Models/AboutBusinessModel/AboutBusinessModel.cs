using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.AboutBusinessModel;

[Table("about_business")]
public class AboutBusinessModel : AuditableModelBase<long>
{
   [Column("title")] public string Title { get; set; }
   [Column("body")] public string Body { get; set; }
   [Column("futures")] public List<string> Futures { get; set; }
   [Column("imageId")] public Guid ImageId { get; set; }
}