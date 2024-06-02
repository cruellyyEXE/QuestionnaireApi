using Domain.Models;

namespace Business.Question;

public interface IQuestion
{
    Task<GetQuestion> GetQuestion(int? surveyId);

    Task<GetQuestion> GetQuestionById(int? questionId);
}

