using OpenAI.Chat;
using System.Text.Json;

namespace OpenAISDKTutorial
{
    public class ZeroToHeroTool : IFunctionTool<string>
    {
        private const string FUNCTION_NAME = "ZeroToHeroFunction";
        private const int OPENAI_COUNT = 5;

        public Task<string> GetToolCallAsync(ChatToolCall toolCall)
        {
            string answer = string.Empty;
            if (toolCall?.FunctionName == FUNCTION_NAME)
            {
                using JsonDocument json = JsonDocument.Parse(toolCall.FunctionArguments);
                string name = string.Empty;
                if (json.RootElement.TryGetProperty("name", out JsonElement value))
                {
                    name = value.GetString() ?? string.Empty;
                }

                int openAiServiceId = PositiveHash(name) % OPENAI_COUNT;
                
                answer = ($"{name} should use No.{openAiServiceId} OpenAIService");
            }
            return Task.FromResult<string>(answer);
        }

        public ChatTool GetToolDefinition()
        {
            return ChatTool.CreateFunctionTool(

                functionName: FUNCTION_NAME,
                functionDescription: "For ZeroToHero course participants, answer which OpenAIService to use from the attendee's name. Use this tool only when the user explicitly asks 'which OpenAIService should I use'.",
                functionParameters: BinaryData.FromObjectAsJson(
                new
                {
                    Type = "object",
                    Properties = new
                    {
                        Name = new
                        {
                            Type = "string",
                            Description = "Name"
                        }
                    },
                    Required = new string[] { "Name" }
                }, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase })
            );
        }

        public static int PositiveHash(string input)
        {
            // If desired, you can pick different prime bases and moduli.
            // This is just an example using a fairly common prime base for string hashing.
            const int basePrime = 31;
            const int largePrime = 0x7FFFFFFF; // 2^31 - 1 (the largest 32-bit signed prime)

            if (string.IsNullOrEmpty(input))
            {
                // In case of null or empty string, return something arbitrary but > 0
                return 1;
            }

            long hashValue = 0;
            foreach (char c in input)
            {
                // Incorporate the character's code
                hashValue = (hashValue * basePrime + c) % largePrime;
            }

            // 'hashValue' might be zero or negative after modulo if there was an overflow 
            // before taking modulo (in C#, modulo can yield negative with negative dividend, 
            // but we kept it from going negative by using largePrime in most cases).
            // Still, let's ensure it's strictly positive.
            if (hashValue <= 0)
            {
                hashValue += largePrime;
            }

            return (int)hashValue;
        }

    }
}
