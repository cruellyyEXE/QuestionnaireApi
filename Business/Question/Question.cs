using Data.Context;
using Domain.Models;

namespace Business.Question;

public class Question(QuestionnaireContext db) : IQuestion
{
    public Task<GetQuestion> GetQuestion(int? surveyId)
    {
        var question = db.Questions.OrderBy(x => x.Order).Where(x => x.SurveyId == surveyId)
            .Select(x => new GetQuestion
            {
                Id = x.Id,
                Content = x.Content,
                Answers = db.Answers.OrderBy(z => z.Order).Where(z => x.Id == z.QuestionId)
                    .Select(z => new AnswerModel
                    {
                        Id = z.Id,
                        Content = z.Content
                    }).ToList()
            }).FirstOrDefault() ?? new GetQuestion();

        return Task.FromResult(question);
    }
    
    public Task<GetQuestion> GetQuestionById(int? questionId)
    {
        var question = db.Questions.OrderBy(x => x.Order).Where(x => x.Id == questionId)
            .Select(x => new GetQuestion
            {
                Id = x.Id,
                Content = x.Content,
                Answers = db.Answers.OrderBy(z => z.Order).Where(z => x.Id == z.QuestionId)
                    .Select(z => new AnswerModel
                    {
                        Id = z.Id,
                        Content = z.Content
                    }).ToList()
            }).FirstOrDefault() ?? new GetQuestion();

        return Task.FromResult(question);
    }
}