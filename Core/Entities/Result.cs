using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Base;

namespace Domain.Entities;

[Table("re_result")]
public class Result : BaseEntity
{
    [Column("answer_id")]
    [ForeignKey("Answer")]
    public int AnswerId { get; set; }
    public Answer? Answer { get; set; }
    
    [Column("times_selected")]
    public long TimesSelected { get; set; }
}