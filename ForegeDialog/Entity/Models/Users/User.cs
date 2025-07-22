using System.ComponentModel.DataAnnotations.Schema;
using Entity.Enums;
using Entity.Models.Common;

namespace Entity.Models.Users;
[Table("users")]
public class User : AuditableModelBase<long>
{
    [Column("user_name")] public string UserName { get; set; }
    [Column("email")] public string Email { get; set; }
    [Column("password")] public string Password { get; set; }
    [Column("role")] public Role Role { get; set; }
    [Column("IsSigned")] public bool IsSigned { get; set; }
}