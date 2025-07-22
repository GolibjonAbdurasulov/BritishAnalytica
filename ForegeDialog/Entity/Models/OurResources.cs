using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models;
[Table("our_resources")]
public class OurResources : ModelBase<long>
{
    [Column("title", TypeName = "jsonb")] public MultiLanguageField Title { get; set; }
    [Column("description", TypeName = "jsonb")] public MultiLanguageField Description { get; set; }
    [Column("file_path")] public string FilePath { get; set; }
}