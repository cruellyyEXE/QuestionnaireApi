using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[Table("re_questions")]
public class Question : BaseQuestion
{
    [Column("survey_id")]
    [ForeignKey("Survey")]
    public int SurveyId { get; set; }

    public Survey? Survey { get; set; }
    
    public Answer? Answer { get; set; }
}