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
using Azure.Identity;

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
            // Configure credential options to prioritize Windows credentials
            var credentialOptions = new DefaultAzureCredentialOptions
            {
                ExcludeInteractiveBrowserCredential = false,  // Include browser prompts
                ExcludeVisualStudioCredential = true,        // Avoid VS-specific credentials
                ExcludeAzureCliCredential = true,            // Avoid Azure CLI credentials
                ExcludeSharedTokenCacheCredential = false,    // Include shared cache credentials
                ExcludeManagedIdentityCredential = false,    // Include Managed Identity (Windows)
            };
            _azureClient = new(
                new Uri(_settings.OpenAIEndpoint),
                new DefaultAzureCredential(credentialOptions));
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
