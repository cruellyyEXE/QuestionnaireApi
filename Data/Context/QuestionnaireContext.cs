using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Context;

public sealed class QuestionnaireContext : DbContext
{
    public DbSet<Survey> Surveys { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Interview> Interviews { get; set; }
    public DbSet<Result> Results { get; set; }
    
    public QuestionnaireContext(DbContextOptions<QuestionnaireContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
    
    public void OnModelCreating(EntityTypeBuilder<Answer> builder)
    {
        builder.HasIndex(a => a.QuestionId)
            .HasDatabaseName("IX_re_answers_question_id1")
            .IsUnique(false);
    }

    public QuestionnaireContext() { }
}