using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models.Common;

public abstract class ModelBase<TId> where TId: struct
{
    [Column("id")]
    public  TId Id { get; set; }
}