using OpenAI.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAISDKTutorial
{
    public static class ChatCompletionExtensions
    {
        public static void DisplayTokenCount(this ChatCompletion completion)
        {
            var currentColor = Console.ForegroundColor;
            Console.ForegroundColor = Constants.SystemColor;
            Console.WriteLine($"[Usage] Total count: {completion.Usage.TotalTokenCount} Input : {completion.Usage.InputTokenCount} Output: {completion.Usage.OutputTokenCount}");
            Console.ForegroundColor = currentColor;
        }
    }
}
