using Business.Question;
using Business.Result;
using Business.Survey;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using IResult = Business.Result.IResult;

namespace QuestionnaireApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<ISurvey, Survey>();
        builder.Services.AddScoped<IQuestion, Question>();
        builder.Services.AddScoped<IResult, Result>();
        
        var connection = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<QuestionnaireContext>(options =>
            options.UseNpgsql(connection));

        var app = builder.Build();
        
        app.UseStaticFiles();

        app.UseRouting();
        
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}