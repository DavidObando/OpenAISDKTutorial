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
3. Interact with the LLM. Your input becomes the `User Prompt`. Modify the `System Prompt` as needed.
4. Debug the system and inspect the payload of the `Request` and `Response` in the [ConversationExecutor](https://github.com/TsuyoshiUshio/OpenAISDKTutorial/blob/step1/OpenAISDKTutorial/ConversationExecutor.cs).

5. Read about [Prompt Engineering](https://platform.openai.com/docs/guides/prompt-engineering) and experiment with different patterns.

## Step 2: History

In Step 1, the history feature was not implemented. The LLM doesn't remember the history, so you need to provide it with the history information.

1. Switch to the [step2](https://github.com/TsuyoshiUshio/OpenAISDKTutorial/tree/step2) branch. Refer to the [commit](https://github.com/TsuyoshiUshio/OpenAISDKTutorial/commit/be2b7e70a85278a6ddea783966377f3c24a314ea) and [commit](https://github.com/TsuyoshiUshio/OpenAISDKTutorial/commit/b7b81e749a6eb6ba0bb49780e4746351dad4ee71).
2. Implement the history feature and observe its functionality.
3. Debug the [ConversationExecutor](https://github.com/TsuyoshiUshio/OpenAISDKTutorial/blob/step2/OpenAISDKTutorial/ConversationExecutor.cs) to see how it behaves.
4. Interact with the chat and verify if it retains the history.

## Step 3: Function Calling

Learn how to call external functions from the LLM. This is useful for real-world scenarios where you need to call external systems or logic, such as Azure AI Search, Cosmos DB, or Kusto Cluster. This is known as [Function Calling](https://platform.openai.com/docs/guides/function-calling).

1. Switch to the [step3](https://github.com/TsuyoshiUshio/OpenAISDKTutorial/tree/step3) branch. Refer to the [commit](https://github.com/TsuyoshiUshio/OpenAISDKTutorial/commit/0d92f475ea0975077335fe02497c078c3b9f4f52).
2. Implement the function calling feature. Modify the definition/implementation as needed.
3. Provide your name to the LLM and ask, "Could you tell me which OpenAI Service should I use?".
4. Modify the `System Prompt` or functionDescription and observe the behavior differences. Stabilizing the system response is key to AI software development.
5. Add new function calls to your bot.

## Step 4: Structured Output

For more deterministic results, consider using [structured output](https://platform.openai.com/docs/guides/structured-outputs). This is useful for obtaining specific types of results.

1. Switch to the [step4](https://github.com/TsuyoshiUshio/OpenAISDKTutorial/tree/step4) branch. Refer to the [commit](https://github.com/TsuyoshiUshio/OpenAISDKTutorial/commit/fa119304a3b1c34bb6d3375c25b1a0e8132334c3).
2. Implement the structured output feature. Modify the definition/implementation as needed.

**Note:** Check the supported models for [Structured Output](https://platform.openai.com/docs/guides/structured-outputs#supported-models).

## Step 5: Managing Tokens

Learn how to count the number of tokens consumed in advance. Compare the estimated token count with the actual token count, as LLM usage is charged by tokens.

1. Switch to the [step5](https://github.com/TsuyoshiUshio/OpenAISDKTutorial/tree/step5) branch. Refer to the [commit](https://github.com/TsuyoshiUshio/OpenAISDKTutorial/commit/29d12a88e1357436172147f32626daa40e967199).

## Conclusion

By completing this tutorial, you will understand 80% of the techniques used in AI coding for developing a C# application. Enjoy your learning journey!

## Reference

* [OpenAI client library for .NET](https://learn.microsoft.com/en-us/dotnet/api/overview/azure/ai.openai-readme?view=azure-dotnet)
* [openai-dotnet](https://github.com/openai/openai-dotnet/tree/main)
* [examples/chat](https://github.com/openai/openai-dotnet/tree/main/examples/Chat)
