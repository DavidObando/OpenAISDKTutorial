using Microsoft.Extensions.Logging.Console;
using OpenAI.Chat;
using System.Text.Json;

namespace OpenAISDKTutorial
{
    public class ConversationExecutor
    {
        private readonly OpenAIClientProvider _clientProvider;
        private readonly SessionManager _sessionManager;
        private readonly ZeroToHeroTool _zeroToHeroTool;

        public ConversationExecutor(OpenAIClientProvider clientProvider, SessionManager sessionManager, ZeroToHeroTool zeroToHeroTool)
        {
            _clientProvider = clientProvider;
            _sessionManager = sessionManager;
            _zeroToHeroTool = zeroToHeroTool;
        }

        public async Task<ConversationResult> ExecuteConversationAsync(string input)
        {
            var client = _clientProvider.GetChatClient();

            string systemPrompt = ""; // Write your system prompt here
            string userPrompt = input;

            // Configure option in here.
            ChatCompletionOptions options = new ()
            {
                Temperature = 0,
            };

            ChatClient chatClient = _clientProvider.GetChatClient();
            List<ChatMessage> chatMessages = new();

            // Adding history to the chat messages
            chatMessages.AddRange(_sessionManager.GetHistory());

            if (!string.IsNullOrEmpty(systemPrompt))
            {
                chatMessages.Add(new SystemChatMessage(systemPrompt));
            }

            var userChatMessage = new UserChatMessage(userPrompt);
            chatMessages.Add(userChatMessage);
            _sessionManager.AddMessage(userChatMessage);

            options.Tools.Add(_zeroToHeroTool.GetToolDefinition());

            // Structured Output
            options.ResponseFormat = ChatResponseFormat.CreateJsonSchemaFormat(
                jsonSchemaFormatName: nameof(ConversationResult),
                jsonSchema: ConversationResult.GetDefinition()
                );

            var tokenStatistics = await TokenUtils.GetAndValidateChatCompletionTokensStatistics(chatMessages);

            var answer = await chatClient.CompleteChatAsync(chatMessages, options);
            var completion = answer.Value;
            completion.DisplayTokenCount();

            while(completion.FinishReason == ChatFinishReason.ToolCalls)
            {
                chatMessages.Add(new AssistantChatMessage(completion));
                foreach (ChatToolCall toolCall in completion.ToolCalls)
                {
                    string toolAnswer = await _zeroToHeroTool.GetToolCallAsync(toolCall);
                    if (!string.IsNullOrEmpty(toolAnswer))
                    {
                        chatMessages.Add(new ToolChatMessage(toolCall.Id, toolAnswer));
                    }
                }

                tokenStatistics = await TokenUtils.GetAndValidateChatCompletionTokensStatistics(chatMessages);
                answer = await chatClient.CompleteChatAsync(chatMessages, options);
                completion = answer.Value;
                completion.DisplayTokenCount();
            }

            string assistant = "No response from OpenAI";
            ConversationResult result = new ConversationResult();
            if (completion.Content.Count > 0)
            {
                var jsonOptions = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                result = JsonSerializer.Deserialize<ConversationResult>(completion.Content[0].Text, jsonOptions);
                assistant = result.Text;
            }

            _sessionManager.AddMessage(new AssistantChatMessage(assistant));
            return result;
        }
    }
}
