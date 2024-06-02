using Domain.Models;
using Domain.Models.Request;
using Microsoft.AspNetCore.Mvc;
using IResult = Business.Result.IResult;

namespace QuestionnaireApi.Controllers;

[Route("result")]
public class ResultController
{
    private IResult _result;

    public ResultController(IResult result)
    {
        _result = result;
    }

    [HttpPut]
    public Task<BaseModel> SaveResult([FromBody] SaveResult? request)
    {
        return _result.SaveResult(request);
    }
}