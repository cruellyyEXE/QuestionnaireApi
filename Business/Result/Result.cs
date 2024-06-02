using Data.Context;
using Domain.Entities;
using Domain.Models;
using Domain.Models.Request;

namespace Business.Result;

public class Result(QuestionnaireContext db) : IResult
{
    public async Task<BaseModel> SaveResult(SaveResult? request)
    {
        if (request == null)
            return new BaseModel { Result = "Пустой запрос." };
        
        if (string.IsNullOrEmpty(request.Username))
            return new BaseModel { Result = "Не заполнено имя пользователя." };
        
        if (request.AnswerId is null or 0)
            return new BaseModel { Result = "Не указан идентификатор ответа." };
        
        if (request.QuestionId is null or 0)
            return new BaseModel { Result = "Не указан идентификатор вопроса." };

        var entity = new Interview
        {
            Username = request.Username,
            QuestionId = (int)request.QuestionId,
            AnswerId = (int)request.AnswerId
        };
        db.Interviews.Add(entity);

        var results = db.Results.FirstOrDefault(x => x.AnswerId == request.AnswerId)!;
        results.TimesSelected++;
        db.Results.Update(results);
        
        await db.SaveChangesAsync();

        var surveyQuestions = db.Questions.Where(x => x.SurveyId ==
                                                      db.Questions.FirstOrDefault(c => c.Id == request.QuestionId)!
                                                          .SurveyId);

        var nextQuestion = surveyQuestions.FirstOrDefault(x =>
            x.Order > db.Questions.FirstOrDefault(c => c.Id == request.QuestionId)!.Order);

        return nextQuestion == null
            ? new BaseModel { Result = "Вопросов больше нет." }
            : new BaseModel { Result = "Операция прошла успешно.", Value = nextQuestion.Id };
    }
}