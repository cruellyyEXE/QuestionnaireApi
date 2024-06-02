using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[Table("re_answers")]
public class Answer : BaseQuestion
{
    [Column("question_id")]
    [ForeignKey("Question")]
    public int QuestionId { get; set; }
    public Question? Question { get; set; }
}