using Data.Context;
using Domain.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace Business.Survey;

public class Survey(QuestionnaireContext db) : ISurvey
{
    public Task<GetSurveys> GetSurveys()
    {
        var surveys = db.Surveys.Select(x => new SurveyModel
        {
            Id = x.Id,
            Name = x.Name,
            Content = x.Content
        }).ToList();

        var result = new GetSurveys
        {
            List = surveys
        };

        return Task.FromResult(result);
    }
}