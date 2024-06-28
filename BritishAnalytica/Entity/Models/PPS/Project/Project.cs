using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.PPS.Project;

[Table("project")]
public class Project : ModelBase<long>
{
    [Column("title")]public string Title { get; set; }
    [Column("body")]public string Body { get; set; }
}