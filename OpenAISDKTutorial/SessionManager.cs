using OpenAI.Chat;

namespace OpenAISDKTutorial
{
    public class SessionManager
    {
        private IList<ChatMessage> history = new List<ChatMessage>();

        public void AddMessage(ChatMessage message)
        {
            history.Add(message);
        }

        public IEnumerable<ChatMessage> GetHistory()
        {
            return history;
        }

        public void ClearHistory()
        {
            history.Clear();
        }
    }
}
