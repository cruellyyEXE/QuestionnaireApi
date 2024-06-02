using Domain.Models;
using Domain.Models.Request;

namespace Business.Result;

public interface IResult
{
    Task<BaseModel> SaveResult(SaveResult? request);
}