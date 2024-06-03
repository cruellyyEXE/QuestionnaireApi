using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace QuestionnaireApi.Dbinit;

public class DbInit() : IDbInit
{
    /*public DbInit(QuestionnaireContext db)
    {
        Task.Run(async () => await Init(db));
    }*/

    // ReSharper disable once CognitiveComplexity
    public async Task Init(QuestionnaireContext db)
    {
        try
        {
            if (!(await db.Surveys.AnyAsync(x => x.Id == 1)))
            {
                await db.Surveys.AddAsync(new Survey()
                {
                    Name = "Опрос жителей",
                    Content = "Наша команда решила провести опрос жителей " +
                              "для получения статистики удовлетворенности жизни в тех или иных регионах"
                });

                await db.SaveChangesAsync();
            }
        
            if (!(await db.Questions.AnyAsync(x => x.Id == 1)))
            {
                await db.Questions.AddAsync(new Question()
                {
                    SurveyId = 1,
                    Content = "В каком регоине Вы проживаете?",
                    Order = 1
                });

                await db.SaveChangesAsync();
            }
        
            if (!(await db.Questions.AnyAsync(x => x.Id == 2)))
            {
                await db.Questions.AddAsync(new Question()
                {
                    SurveyId = 1,
                    Content = "Насколько вы удовлетворены жизнью в Вашем регионе?",
                    Order = 2
                });

                await db.SaveChangesAsync();
            }
        
            if (!(await db.Answers.AnyAsync(x => x.Id == 1)))
            {
                await db.Answers.AddAsync(new Answer()
                {
                    QuestionId = 1,
                    Content = "Краснодарский край",
                    Order = 2
                });

                await db.SaveChangesAsync();
            }
        
            if (!(await db.Answers.AnyAsync(x => x.Id == 2)))
            {
                await db.Answers.AddAsync(new Answer()
                {
                    QuestionId = 1,
                    Content = "Ростовская область",
                    Order = 1
                });

                await db.SaveChangesAsync();
            }
        
            if (!(await db.Answers.AnyAsync(x => x.Id == 3)))
            {
                await db.Answers.AddAsync(new Answer()
                {
                    QuestionId = 1,
                    Content = "Красноярский край",
                    Order = 3
                });

                await db.SaveChangesAsync();
            }
        
            if (!(await db.Answers.AnyAsync(x => x.Id == 4)))
            {
                await db.Answers.AddAsync(new Answer()
                {
                    QuestionId = 1,
                    Content = "Московская область",
                    Order = 4
                });

                await db.SaveChangesAsync();
            }
        
            if (!(await db.Answers.AnyAsync(x => x.Id == 5)))
            {
                await db.Answers.AddAsync(new Answer()
                {
                    QuestionId = 2,
                    Content = "Удовлетворен",
                    Order = 1
                });

                await db.SaveChangesAsync();
            }
        
            if (!(await db.Answers.AnyAsync(x => x.Id == 6)))
            {
                await db.Answers.AddAsync(new Answer()
                {
                    QuestionId = 2,
                    Content = "Вполне",
                    Order = 2
                });

                await db.SaveChangesAsync();
            }
        
            if (!(await db.Answers.AnyAsync(x => x.Id == 7)))
            {
                await db.Answers.AddAsync(new Answer()
                {
                    QuestionId = 2,
                    Content = "Не очень",
                    Order = 3
                });

                await db.SaveChangesAsync();
            }
        
            if (!(await db.Results.AnyAsync(x => x.Id == 1)))
            {
                await db.Results.AddAsync(new Result()
                {
                    AnswerId = 1,
                    TimesSelected = 0
                });

                await db.SaveChangesAsync();
            }
        
            if (!(await db.Results.AnyAsync(x => x.Id == 2)))
            {
                await db.Results.AddAsync(new Result()
                {
                    AnswerId = 2,
                    TimesSelected = 0
                });

                await db.SaveChangesAsync();
            }
        
            if (!(await db.Results.AnyAsync(x => x.Id == 3)))
            {
                await db.Results.AddAsync(new Result()
                {
                    AnswerId = 3,
                    TimesSelected = 0
                });

                await db.SaveChangesAsync();
            }
        
            if (!(await db.Results.AnyAsync(x => x.Id == 4)))
            {
                await db.Results.AddAsync(new Result()
                {
                    AnswerId = 4,
                    TimesSelected = 0
                });

                await db.SaveChangesAsync();
            }
        
            if (!(await db.Results.AnyAsync(x => x.Id == 5)))
            {
                await db.Results.AddAsync(new Result()
                {
                    AnswerId = 5,
                    TimesSelected = 0
                });

                await db.SaveChangesAsync();
            }
        
            if (!(await db.Results.AnyAsync(x => x.Id == 6)))
            {
                await db.Results.AddAsync(new Result()
                {
                    AnswerId = 6,
                    TimesSelected = 0
                });

                await db.SaveChangesAsync();
            }
        
            if (!(await db.Results.AnyAsync(x => x.Id == 7)))
            {
                await db.Results.AddAsync(new Result()
                {
                    AnswerId = 7,
                    TimesSelected = 0
                });

                await db.SaveChangesAsync();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}