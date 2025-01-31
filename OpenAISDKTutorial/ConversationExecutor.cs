using OpenAI.Chat;

namespace OpenAISDKTutorial
{
    public class ConversationExecutor
    {
        private OpenAIClientProvider _clientProvider;

        public ConversationExecutor(OpenAIClientProvider clientProvider)
        {
            _clientProvider = clientProvider;
        }

        public async Task<string> ExecuteConversationAsync(string input)
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

            if (string.IsNullOrEmpty(systemPrompt))
            {
                chatMessages.Add(new SystemChatMessage(systemPrompt));
            }

            chatMessages.Add(new UserChatMessage(userPrompt));

            var answer = await chatClient.CompleteChatAsync(chatMessages, options);
            var completion = answer.Value;

            if (completion.Content.Count > 0)
            {
                return completion.Content[0].Text;
            }
            else
            {
                return "No response from OpenAI";
            }
        }
    }
}
