using Microsoft.Extensions.Hosting;

namespace OpenAISDKTutorial
{
    public class ConversationLoopService : BackgroundService
    {
        private readonly ConversationExecutor _conversationExecutor;
        public ConversationLoopService(ConversationExecutor conversationExecutor)
        {
            _conversationExecutor = conversationExecutor;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var currentColor = Console.ForegroundColor;
            Console.ForegroundColor = Constants.UIColor;
            Console.WriteLine("Hello, I'm Azure Functions Bot! How can I help you today?");
            Console.ForegroundColor = currentColor;
            while (!stoppingToken.IsCancellationRequested)
            {
                Console.ForegroundColor = Constants.SystemColor;
                Console.Write($"[User] > ");
                Console.ForegroundColor = Constants.UserColor;
                var input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    continue;
                }

                if (input.ToLower() == "exit")
                {
                    break;
                }

                try
                {
                    var answer = await _conversationExecutor.ExecuteConversationAsync(input);
                    Console.ForegroundColor = Constants.UIColor;
                    Console.WriteLine(answer);
                    Console.ForegroundColor = currentColor;
                }
                catch (Exception ex)
                {
                    currentColor = Console.ForegroundColor;
                    Console.ForegroundColor = Constants.WarningColor;
                    Console.WriteLine("An unexpected error occurred. Please try again.");
                    Console.WriteLine("If the problem persists, please consult the troubleshooting guide or contact support.");
                    Console.WriteLine($"Unexpected error: {ex.Message} {ex.StackTrace}");
                    Console.ForegroundColor = currentColor;
                    continue;
                }
            }
        }

    }
}
