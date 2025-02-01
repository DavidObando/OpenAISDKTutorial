
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpenAISDKTutorial
{
    public class ConversationResult
    {
        public string Text { get; set; }
        public int OpenAIServiceId { get; set; } = -1;
        public string Sentiment { get; set; }

        public static BinaryData GetDefinition()
        {
            return BinaryData.FromObjectAsJson(
                new
                {
                    Type = "object",
                    Properties = new
                    {
                        Text = new
                        {
                            Type = "string",
                            Description = "The answer from LLM"
                        },
                        Sentiment = new
                        {
                            Type = "string",
                            Enum = new string[] { "Positive", "Negative", "Neutral" },
                            Description = "Sentiment of the LLM answer."
                        },
                        OpenAIServiceId = new
                        {
                            Type = "integer",
                            Description = "OpenAIServiceId. Only when we answered it. Return -1 if you don't know it."
                        }
                    },
                    Required = new string[] { "Text", "Sentiment" },
                    AdditionalProperties = false
                }, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }
            );
        }
    }
}
