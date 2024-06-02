using Domain.Models;

namespace Business.Survey;

public interface ISurvey
{
    Task<GetSurveys> GetSurveys();
}