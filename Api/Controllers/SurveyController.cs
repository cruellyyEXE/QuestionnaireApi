using Business.Survey;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace QuestionnaireApi.Controllers;

[Route("survey")]
public class SurveyController
{
    private ISurvey _survey;

    public SurveyController(ISurvey survey)
    {
        _survey = survey;
    }

    [HttpGet]
    public Task<GetSurveys> GetSurveys()
    {
        return _survey.GetSurveys();
    }
}