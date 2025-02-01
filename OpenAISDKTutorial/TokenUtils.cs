using Microsoft.DeepDev;
using OpenAI.Chat;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAISDKTutorial
{
    public class TokenUtils
    {
        public static async Task<TokenStatistics> GetAndValidateChatCompletionTokensStatistics(IList<ChatMessage> chatMessages)
        {
            StringBuilder toolMessages = new();
            StringBuilder systemMessages = new();
            StringBuilder userMessages = new();
            StringBuilder assistantMessage = new();
            foreach (var message in chatMessages)
            {
                if (message is UserChatMessage)
                {
                    foreach (var contentPart in message.Content)
                    {
                        userMessages.AppendLine(contentPart.Text);
                    }
                    continue;
                }

                if (message is AssistantChatMessage)
                {
                    foreach (var contentPart in message.Content)
                    {
                        assistantMessage.AppendLine(contentPart.Text);
                    }
                    continue;
                }

                if (message is SystemChatMessage)
                {
                    foreach (var contentPart in message.Content)
                    {
                        systemMessages.AppendLine(contentPart.Text);
                    }
                    continue;
                }

                if (message is ToolChatMessage)
                {
                    foreach (var contentPart in message.Content)
                    {
                        toolMessages.AppendLine(contentPart.Text);
                    }
                    continue;

                }
            }
            Task<int> toolToken = CountTokens(toolMessages.ToString());
            Task<int> systemToken = CountTokens(systemMessages.ToString());
            Task<int> userToken = CountTokens(userMessages.ToString());
            Task<int> assistantToken = CountTokens(assistantMessage.ToString());
            Stopwatch stopwatch = new();
            stopwatch.Start();
            await Task.WhenAll(toolToken, systemToken, userToken, assistantToken);
            int totalToken = toolToken.Result + systemToken.Result + userToken.Result + assistantToken.Result;
            stopwatch.Stop();
            var currentColor = Console.ForegroundColor;
            Console.ForegroundColor = Constants.SystemColor;
            Console.WriteLine($"[Estimation] Local token count completed in {stopwatch.ElapsedMilliseconds} ms. Total: {totalToken} token ToolToken: {toolToken.Result}, SystemToken: {systemToken.Result} UserToken: {userToken.Result} AssistantToken: {assistantToken.Result}");
            Console.ForegroundColor = currentColor;
            if (totalToken > Constants.MaximumTokenLength)
            {
                throw new TokenLengthException($"[Estimation] Total token count exceeds the limit of {Constants.MaximumTokenLength} tokens. Add Filters or Reduce the NumberOfRows.");
            }
            return new TokenStatistics
            {
                ToolToken = toolToken.Result,
                SystemToken = systemToken.Result,
                UserToken = userToken.Result,
                AssistantToken = assistantToken.Result
            };
        }

        public static async Task ShowAndValidateChatCompletionTokens(IList<ChatMessage> chatMessages)
        {
            StringBuilder toolMessages = new();
            StringBuilder systemMessages = new();
            StringBuilder userMessages = new();
            StringBuilder assistantMessage = new();
            foreach (var message in chatMessages)
            {
                if (message is UserChatMessage)
                {
                    foreach (var contentPart in message.Content)
                    {
                        userMessages.AppendLine(contentPart.Text);
                    }
                    continue;
                }

                if (message is AssistantChatMessage)
                {
                    foreach (var contentPart in message.Content)
                    {
                        assistantMessage.AppendLine(contentPart.Text);
                    }
                    continue;
                }

                if (message is SystemChatMessage)
                {
                    foreach (var contentPart in message.Content)
                    {
                        systemMessages.AppendLine(contentPart.Text);
                    }
                    continue;
                }

                if (message is ToolChatMessage)
                {
                    foreach (var contentPart in message.Content)
                    {
                        toolMessages.AppendLine(contentPart.Text);
                    }
                    continue;

                }
            }
            Task<int> toolToken = CountTokens(toolMessages.ToString());
            Task<int> systemToken = CountTokens(systemMessages.ToString());
            Task<int> userToken = CountTokens(userMessages.ToString());
            Task<int> assistantToken = CountTokens(assistantMessage.ToString());
            Stopwatch stopwatch = new();
            stopwatch.Start();
            await Task.WhenAll(toolToken, systemToken, userToken, assistantToken);
            int totalToken = toolToken.Result + systemToken.Result + userToken.Result + assistantToken.Result;
            stopwatch.Stop();
            var currentColor = Console.ForegroundColor;
            Console.ForegroundColor = Constants.SystemColor;
            Console.WriteLine($"[Estimation] Local token count completed in {stopwatch.ElapsedMilliseconds} ms. Total: {totalToken} token ToolToken: {toolToken.Result}, SystemToken: {systemToken.Result} UserToken: {userToken.Result} AssistantToken: {assistantToken.Result}");
            Console.ForegroundColor = currentColor;
            if (totalToken > Constants.MaximumTokenLength)
            {
                throw new TokenLengthException($"[Estimation] Total token count exceeds the limit of {Constants.MaximumTokenLength} tokens. Add Filters or Reduce the NumberOfRows.");
            }
        }

        public static async Task<int> CountTokens(string text)
        {
            try
            {
                // TODO currently GPT-4o is not supported for the tokenizer.
                var tokenizer = await TokenizerBuilder.CreateByModelNameAsync("gpt-4");
                var encoded = tokenizer.Encode(text, Array.Empty<string>());
                return encoded.Count;
            }
            catch (TokenLengthException)
            {
                throw;
            }
        }
    }
}
