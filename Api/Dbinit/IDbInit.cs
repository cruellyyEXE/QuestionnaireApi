using System.Data.Common;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace QuestionnaireApi;

public interface IDbInit
{
    Task Init(QuestionnaireContext db);
}