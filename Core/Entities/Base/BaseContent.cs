using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Base;

public class BaseContent : BaseEntity
{
    [Column("content")]
    public required string Content { get; set; }
}