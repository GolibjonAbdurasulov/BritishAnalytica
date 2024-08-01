using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;
using Entity.Models.ReasonModel;

namespace Entity.Models.AboutBusinessModel;
[Table("about_business")]
public class AboutBusinessModel : AuditableModelBase<long>
{
   [Column("title", TypeName = "jsonb")] public MultiLanguageField Title { get; set; }

   [Column("about", TypeName = "jsonb")] public MultiLanguageField About { get; set; }

   [Column("mini_title", TypeName = "jsonb")] public MultiLanguageField MiniTitle { get; set; }
   
   [Column("reason")] public virtual List<Reason> Reasons { get; set; } = new List<Reason>();

   [Column("imageId")] public Guid ImageId { get; set; }
}
