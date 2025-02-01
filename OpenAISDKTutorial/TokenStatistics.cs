namespace OpenAISDKTutorial
{
    public class TokenStatistics
    {
        public int ToolToken { get; set; }
        public int SystemToken { get; set; }
        public int UserToken { get; set; }
        public int AssistantToken { get; set; }
        public int TotalToken => ToolToken + SystemToken + UserToken + AssistantToken;

    }
}
