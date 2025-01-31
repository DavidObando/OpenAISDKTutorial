using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace OpenAISDKTutorial
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
            builder.Logging.ClearProviders();
            builder.Services.AddSingleton<OpenAIClientProvider>();
            builder.Services.AddHostedService<ConversationLoopService>();
            builder.Services.AddSingleton<ConversationExecutor>();
            builder.Services.AddSingleton<SessionManager>();
            builder.Configuration.AddJsonFile("appsettings.json");
            builder.Services.AddOptions<Settings>()
                .Configure<IConfiguration>((settings, configuration) =>
                {
                    configuration.GetSection(nameof(Settings))
                        .Bind(settings);
                });

            IHost host = builder.Build();
            await host.RunAsync();
        }
    }
}
