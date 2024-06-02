using Business.Question;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace QuestionnaireApi.Controllers;

[Route("question")]
public class QuestionController
{
    private IQuestion _question;

    public QuestionController(IQuestion question)
    {
        _question = question;
    }

    [HttpGet("{surveyId:int}")]
    public Task<GetQuestion> GetQuestion(int surveyId)
    {
        return _question.GetQuestion(surveyId);
    }
    
    [HttpGet]
    public Task<GetQuestion> GetQuestionById([FromQuery] int questionId)
    {
        return _question.GetQuestionById(questionId);
    }
}