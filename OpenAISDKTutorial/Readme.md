# OpenAI Library Tutorial

Step-by-step instructions for using the OpenAI Library.

## Prerequisite

Deploy the OpenAI Service on Azure.

## Configuration

Copy `appsettings.json.example` to `appsettings.json` and fill in the required settings.

## Step 1. Simple Conversation

Understand the fundamentals of the `ChatCompletionAPI`. The LLM is stateless, so you always need to send a request with all contexts.

1. Switch to the [step1](https://github.com/TsuyoshiUshio/OpenAISDKTutorial/tree/step1) branch.
2. Start the project.
3. Enjoy the conversation with the LLM. Your input becomes the `User Prompt`. Modify the `System Prompt` as needed.
4. Debug the system and see the payload of the `Request` and `Response` in the [`ConversationExecutor`](OpenAISDKTutorial/ConversationExecutor.cs).

## Step 2. History

In Step 1, we missed the history feature. The LLM doesn't remember the history, so we need to provide it with the history information.

1. Switch to the [step2](https://github.com/TsuyoshiUshio/OpenAISDKTutorial/tree/step2) branch. See the [commit](https://github.com/your-repo/OpenAISDKTutorial/commit/step2).
2. Implement the history feature and see how it works.
3. Debug the [`ConversationExecutor`](OpenAISDKTutorial/ConversationExecutor.cs) to observe the behavior.
4. Interact with the chat and verify if it retains the history.

## Step 3. Function Calling

We might want to call external functions from the LLM. For real-world scenarios, we can call Azure AI Search, Cosmos DB, Kusto Cluster, or anything else. It is also a good idea to delegate calculations outside of the LLM. Add one more function call with your idea.

1. Switch to the [step3](https://github.com/TsuyoshiUshio/OpenAISDKTutorial/tree/step3) branch. See the [commit](https://github.com/your-repo/OpenAISDKTutorial/commit/step3).
2. Implement the function calling. Modify the definition/implementation as you wish.

## Step 4. Structured Output

If you want more deterministic results, consider using structured output. This is useful for obtaining specific types of results.

1. Switch to the [step4](https://github.com/TsuyoshiUshio/OpenAISDKTutorial/tree/step4) branch. See the [commit](https://github.com/your-repo/OpenAISDKTutorial/commit/step4).

## Step 5. Managing Tokens

You might want to count how many tokens are consumed. Let's try it.

1. Switch to the [step5](https://github.com/your-repo/OpenAISDKTutorial/tree/step5) branch. See the [commit](https://github.com/your-repo/OpenAISDKTutorial/commit/step5).
