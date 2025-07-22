using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Entity.Models.Common;
using Microsoft.EntityFrameworkCore;

namespace Entity.Models.Translation;

[Table("translations")]
[Index(nameof(Code), IsUnique = true)]
public class Translation : ModelBase<long>
{
    [Column("code")] public string Code { get; set; }
    [Column("uz"), JsonPropertyName("uz")] public string Uz { get; set; }
    [Column("en"), JsonPropertyName("en")] public string En { get; set; }
    [Column("ru"), JsonPropertyName("ru")] public string Ru { get; set; }
}