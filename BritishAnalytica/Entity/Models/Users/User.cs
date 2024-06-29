using System.ComponentModel.DataAnnotations.Schema;
using Entity.Enums;
using Entity.Models.Common;

namespace Entity.Models.Users;
[Table("users",Schema = "british_analytica")]
public class User : AuditableModelBase<long>
{
    [Column("email")] public string Email { get; set; }
    [Column("password")] public string Password { get; set; }
    [Column("role")] public Role Role { get; set; }
}