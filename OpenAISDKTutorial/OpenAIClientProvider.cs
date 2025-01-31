using Azure.AI.OpenAI;
using Azure;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenAI.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAISDKTutorial
{
    public class OpenAIClientProvider
    {
        private readonly Settings _settings;
        private readonly ILogger<OpenAIClientProvider> _logger;
        private readonly AzureOpenAIClient _azureClient;
        private readonly ChatClient _chatClient;

        public OpenAIClientProvider(IOptions<Settings> options, ILogger<OpenAIClientProvider> logger)
        {
            _settings = options.Value;
            _logger = logger;
            _azureClient = new AzureOpenAIClient(new Uri(_settings.OpenAIEndpoint), new AzureKeyCredential(_settings.OpenAIKey));
            _chatClient = _azureClient.GetChatClient(_settings.OpenAIDeployment);
        }

        public ChatClient GetChatClient()
        {
            return _chatClient;
        }

        public AzureOpenAIClient GetAzureClient()
        {
            return _azureClient;
        }

        public string GetDeploymentName()
        {
            return _settings.OpenAIDeployment;
        }
    }
}
