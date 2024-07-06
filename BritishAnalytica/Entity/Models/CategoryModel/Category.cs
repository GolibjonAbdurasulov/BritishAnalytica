using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.CategoryModel;

[Table("categories")]
public class Category : ModelBase<long>
{
    [Column("category", TypeName = "jsonb")] public MultiLanguageField CategoryName { get; set; }
}