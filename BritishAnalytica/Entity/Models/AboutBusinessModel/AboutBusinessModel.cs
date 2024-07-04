using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;
using Entity.Models.FutureModel;

namespace Entity.Models.AboutBusinessModel;
[Table("about_business")]
public class AboutBusinessModel : AuditableModelBase<long>
{

   [Column("title", TypeName = "jsonb")]
   public MultiLanguageField Title { get; set; }

   [Column("body", TypeName = "jsonb")]
   public MultiLanguageField Body { get; set; }

   [Column("futures")]
   public virtual List<Future> Futures { get; set; } = new List<Future>();

   [Column("imageId")]
   public Guid ImageId { get; set; }
}
