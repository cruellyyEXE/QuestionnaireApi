using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Base;

namespace Domain.Entities;

[Table("re_interviews")]
public class Interview : BaseEntity
{
    [Column("username")]
    public required string Username { get; set; }
    
    [Column("question_id")]
    [ForeignKey("Question")]
    public int QuestionId { get; set; }
    public Question? Question { get; set; }
    
    [Column("answer_id")]
    [ForeignKey("Answer")]
    public int AnswerId { get; set; }
    public Answer? Answer { get; set; }
}