using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Base;

public class BaseEntity
{
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
}