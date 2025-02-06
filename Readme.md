# Zero To Hero for C# Programmers - OpenAI Library Tutorial

This tutorial provides step-by-step instructions for using the [Azure OpenAI client Library](https://learn.microsoft.com/en-us/dotnet/api/overview/azure/ai.openai-readme?view=azure-dotnet) in a C# application.

## Prerequisites

- Deploy the OpenAI Service on Azure.

## Configuration

1. Copy `appsettings.json.example` to `appsettings.json`.
2. Fill in the required settings in `appsettings.json`.

## Step 1: Simple Conversation

Learn the fundamentals of the [ChatCompletionAPI](https://platform.openai.com/docs/api-reference/chat/create). The LLM is stateless, so you always need to send a request with all contexts.

1. Switch to the [step1](https://github.com/TsuyoshiUshio/OpenAISDKTutorial/tree/step1) branch.
2. Start the project.
3. Interact with the LLM. Your input becomes the [User Prompt](https://blog.promptlayer.com/system-prompt-vs-user-prompt-a-comprehensive-guide-for-ai-prompts/). Modify the [System Prompt](https://learn.microsoft.com/en-us/azure/ai-services/openai/concepts/advanced-prompt-engineering) as needed.
4. Debug the system and inspect the payload of the `Request` and `Response` in the [ConversationExecutor](https://github.com/TsuyoshiUshio/OpenAISDKTutorial/blob/step1/OpenAISDKTutorial/ConversationExecutor.cs).
5. Update the `System Prompt`. For example: `When I ask for help to write something, you will reply with a document that contains at least one joke or playful comment in every paragraph.`

6. Read about [Prompt Engineering](https://platform.openai.com/docs/guides/prompt-engineering) and experiment with different patterns.

## Step 2: History

In Step 1, the history feature was not implemented. The LLM doesn't remember the history, so you need to provide it with the history information.

1. Switch to the [step2](https://github.com/TsuyoshiUshio/OpenAISDKTutorial/tree/step2) branch. Refer to the [commit](https://github.com/TsuyoshiUshio/OpenAISDKTutorial/commit/30405bd994b5e729a375bea84569c0d833eb4cae).
2. Implement the history feature and observe its functionality.
3. Debug the [ConversationExecutor](https://github.com/TsuyoshiUshio/OpenAISDKTutorial/blob/step2/OpenAISDKTutorial/ConversationExecutor.cs) to see how it behaves.
4. Interact with the chat and verify if it retains the history.

## Step 3: Function Calling

Learn how to call external functions from the LLM. This is useful for real-world scenarios where you need to call external systems or logic, such as Azure AI Search, Cosmos DB, or Kusto Cluster. This is known as [Function Calling](https://platform.openai.com/docs/guides/function-calling).

1. Switch to the [step3](https://github.com/TsuyoshiUshio/OpenAISDKTutorial/tree/step3) branch. Refer to the [commit](https://github.com/TsuyoshiUshio/OpenAISDKTutorial/commit/1cdfb160812c4dbb06918d6c24b75732191fccbf).
2. Implement the function calling feature. Modify the definition/implementation as needed.
3. Provide your name to the LLM and ask, "Could you tell me which OpenAI Service should I use?".
4. Modify the `System Prompt` or functionDescription and observe the behavior differences. Stabilizing the system response is key to AI software development.
5. Add new function calls to your bot.

## Step 4: Structured Output

For more deterministic results, consider using [structured output](https://platform.openai.com/docs/guides/structured-outputs). This is useful for obtaining specific types of results.

1. Switch to the [step4](https://github.com/TsuyoshiUshio/OpenAISDKTutorial/tree/step4) branch. Refer to the [commit](https://github.com/TsuyoshiUshio/OpenAISDKTutorial/commit/24098084a1ec672533ff38b73495688f2a497dc9).
2. Implement the structured output feature. Modify the definition/implementation as needed.

**Note:** Check the supported models for [Structured Output](https://platform.openai.com/docs/guides/structured-outputs#supported-models).

## Step 5: Managing Tokens

Learn how to count the number of tokens consumed in advance. Compare the estimated token count with the actual token count, as LLM usage is charged by tokens.

1. Switch to the [step5](https://github.com/TsuyoshiUshio/OpenAISDKTutorial/tree/step5) branch. Refer to the [commit](https://github.com/TsuyoshiUshio/OpenAISDKTutorial/commit/3b0f84f7caf67fb3f96315a2de628d33501fd113).
Read the code and run debug and learn how token management works in [ConversationExecutor](https://github.com/TsuyoshiUshio/OpenAISDKTutorial/blob/fd28d464abc4ced4baea7da5b7de5a5405784638/OpenAISDKTutorial/ConversationExecutor.cs#L56). Understand how token is managed before/after the ChatCompletion API call.

For managing token, we use [Microsoft.DeepDev.TokenizerLib](https://github.com/microsoft/Tokenizer) but should migrate to [Microsoft.ML.Tokenizers](https://learn.microsoft.com/en-us/dotnet/api/microsoft.ml.tokenizers.tokenizer?view=ml-dotnet-preview).

## Conclusion

By completing this tutorial, you will understand 80% of the techniques used in AI coding for developing a C# application. Enjoy your learning journey!

## Reference

* [OpenAI client library for .NET](https://learn.microsoft.com/en-us/dotnet/api/overview/azure/ai.openai-readme?view=azure-dotnet) - Microsoft Azure SDK
* [openai-dotnet](https://github.com/openai/openai-dotnet/tree/main) - OpenAI SDK
* [examples/chat](https://github.com/openai/openai-dotnet/tree/main/examples/Chat) OpenAI SDK samples
