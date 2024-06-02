using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Base;

public class BaseQuestion : BaseContent
{
    [Column("order")]
    public int? Order { get; set; }
}