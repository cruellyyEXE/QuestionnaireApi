using Data.Context;

namespace QuestionnaireApi;

public class StartupTask(IServiceProvider serviceProvider) : IHostedService
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<IDbInit>();
            var context = scope.ServiceProvider.GetRequiredService<QuestionnaireContext>();
            await db.Init(context);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}