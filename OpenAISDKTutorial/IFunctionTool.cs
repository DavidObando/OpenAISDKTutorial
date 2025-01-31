using OpenAI.Chat;

namespace OpenAISDKTutorial
{
    public interface IFunctionTool<T>
    {
        ChatTool GetToolDefinition();
        Task<T> GetToolCallAsync(ChatToolCall toolCall);
    }
}
