using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models;
[Table("our_valued_clients")]
public class OurValuedClients : ModelBase<long>
{
    [Column("company_name", TypeName = "jsonb")] public MultiLanguageField CompanyName { get; set; }
    [Column("image_path")]public string  ImagePath { get; set; }
    [Column("link")]public string  link { get; set; }
}