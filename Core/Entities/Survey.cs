using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[Table("re_surveys")]
public class Survey : BaseContent
{
    [Column("name")]
    public required string Name { get; set; }
}