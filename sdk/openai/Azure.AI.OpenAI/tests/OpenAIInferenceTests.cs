﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Tests
{
    public class OpenAIInferenceTests : OpenAITestBase
    {
        public OpenAIInferenceTests(bool isAsync)
            : base(isAsync) // , RecordedTestMode.Live)
        {
        }

        [RecordedTest]
        [TestCase(OpenAIClientServiceTarget.Azure)]
        [TestCase(OpenAIClientServiceTarget.NonAzure)]
        public async Task Completions(OpenAIClientServiceTarget serviceTarget)
        {
            OpenAIClient client = GetTestClient(serviceTarget);
            string deploymentOrModelName = OpenAITestBase.GetDeploymentOrModelName(serviceTarget, OpenAIClientScenario.LegacyCompletions);
            Assert.That(client, Is.InstanceOf<OpenAIClient>());
            CompletionsOptions requestOptions = new()
            {
                DeploymentName = deploymentOrModelName,
                Prompts =
                {
                    "Hello world",
                    "running over the same old ground",
                },
            };
            Assert.That(requestOptions, Is.InstanceOf<CompletionsOptions>());
            Response<Completions> response = await client.GetCompletionsAsync(requestOptions);
            Assert.That(response, Is.Not.Null);
            Assert.That(response, Is.InstanceOf<Response<Completions>>());
            Assert.That(response.Value, Is.Not.Null);
            Assert.That(response.Value.Choices, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Choices.Count, Is.EqualTo(requestOptions.Prompts.Count));
            Assert.That(response.Value.Choices[0].FinishReason, Is.Not.Null.Or.Empty);
        }

        [RecordedTest]
        [TestCase(OpenAIClientServiceTarget.Azure)]
        [TestCase(OpenAIClientServiceTarget.NonAzure, Ignore = "Tokens not supported for non-Azure")]
        public async Task CompletionsWithTokenCredential(OpenAIClientServiceTarget serviceTarget)
        {
            OpenAIClient client = GetTestClient(serviceTarget, OpenAIClientAuthenticationType.Token);
            string deploymentName = OpenAITestBase.GetDeploymentOrModelName(serviceTarget, OpenAIClientScenario.LegacyCompletions);
            var requestOptions = new CompletionsOptions()
            {
                DeploymentName = deploymentName,
                Prompts = { "Hello, world!", "I can have multiple prompts" },
            };
            Assert.That(requestOptions, Is.InstanceOf<CompletionsOptions>());
            Response<Completions> response = await client.GetCompletionsAsync(requestOptions);
            Assert.That(response, Is.InstanceOf<Response<Completions>>());
            Assert.That(response.Value.Choices, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Choices.Count, Is.EqualTo(2));
        }

        [RecordedTest]
        [TestCase(OpenAIClientServiceTarget.Azure)]
        [TestCase(OpenAIClientServiceTarget.NonAzure)]
        public async Task Embeddings(OpenAIClientServiceTarget serviceTarget)
        {
            OpenAIClient client = GetTestClient(serviceTarget);
            string deploymentOrModelName = OpenAITestBase.GetDeploymentOrModelName(serviceTarget, OpenAIClientScenario.Embeddings);
            var embeddingsOptions = new EmbeddingsOptions()
            {
                DeploymentName = deploymentOrModelName,
                Input = { "Your text string goes here" },
            };
            Assert.That(embeddingsOptions, Is.InstanceOf<EmbeddingsOptions>());
            Response<Embeddings> response = await client.GetEmbeddingsAsync(embeddingsOptions);
            Assert.That(response, Is.InstanceOf<Response<Embeddings>>());
            Assert.That(response.Value, Is.Not.Null);
            Assert.That(response.Value.Data, Is.Not.Null.Or.Empty);

            EmbeddingItem firstItem = response.Value.Data[0];
            Assert.That(firstItem, Is.Not.Null);
            Assert.That(firstItem.Index, Is.EqualTo(0));
            Assert.That(firstItem.Embedding, Is.Not.Null.Or.Empty);
        }

        [RecordedTest]
        [TestCase(OpenAIClientServiceTarget.Azure)]
        [TestCase(OpenAIClientServiceTarget.NonAzure)]
        public async Task CompletionsUsageField(OpenAIClientServiceTarget serviceTarget)
        {
            OpenAIClient client = GetTestClient(serviceTarget);
            string deploymentOrModelName = OpenAITestBase.GetDeploymentOrModelName(serviceTarget, OpenAIClientScenario.LegacyCompletions);
            var requestOptions = new CompletionsOptions()
            {
                DeploymentName = deploymentOrModelName,
                Prompts =
                {
                    "Hello world",
                    "This is a test",
                },
                MaxTokens = 1024,
                ChoicesPerPrompt = 3,
                LogProbabilityCount = 1,
            };
            int expectedChoiceCount = (requestOptions.ChoicesPerPrompt ?? 1) * requestOptions.Prompts.Count;
            Response<Completions> response = await client.GetCompletionsAsync(requestOptions);
            Assert.That(response.GetRawResponse(), Is.Not.Null.Or.Empty);
            Assert.That(response.Value, Is.Not.Null);
            Assert.That(response.Value.Id, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Created, Is.GreaterThan(new DateTimeOffset(new DateTime(2023, 1, 1))));
            Assert.That(response.Value.Created, Is.LessThan(DateTimeOffset.UtcNow.AddDays(7)));
            Assert.That(response.Value.Choices, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Choices.Count, Is.EqualTo(expectedChoiceCount), "Each prompt should produce `SnippetCount` choices");
            Assert.That(response.Value.Usage, Is.Not.Null);
            Assert.That(response.Value.Usage.TotalTokens, Is.GreaterThan(0));
            Assert.That(response.Value.Usage.TotalTokens, Is.EqualTo(response.Value.Usage.CompletionTokens + response.Value.Usage.PromptTokens));

            Choice firstChoice = response.Value.Choices[0];
            Assert.That(firstChoice, Is.Not.Null);
            Assert.That(firstChoice.FinishReason, Is.Not.Null.Or.Empty);
            Assert.That(firstChoice.Text, Is.Not.Null.Or.Empty);
            Assert.That(firstChoice.LogProbabilityModel, Is.Not.Null);
            Assert.That(firstChoice.LogProbabilityModel.Tokens, Is.Not.Null.Or.Empty);
            Assert.That(firstChoice.LogProbabilityModel.Tokens.Count, Is.LessThan(response.Value.Usage.TotalTokens));
            Assert.That(firstChoice.LogProbabilityModel.Tokens[0], Is.Not.Null.Or.Empty);

            Assert.That(response.Value.Choices[2].Index, Is.EqualTo(2));
        }

        [RecordedTest]
        [TestCase(OpenAIClientServiceTarget.Azure)]
        [TestCase(OpenAIClientServiceTarget.NonAzure)]
        public async Task ChatCompletions(OpenAIClientServiceTarget serviceTarget)
        {
            OpenAIClient client = GetTestClient(serviceTarget);
            string deploymentOrModelName = OpenAITestBase.GetDeploymentOrModelName(
                serviceTarget,
                OpenAIClientScenario.ChatCompletions);
            var requestOptions = new ChatCompletionsOptions()
            {
                DeploymentName = deploymentOrModelName,
                Messages =
                {
                    new ChatMessage(ChatRole.System, "You are a helpful assistant."),
                    new ChatMessage(ChatRole.User, "Can you help me?"),
                    new ChatMessage(ChatRole.Assistant, "Of course! What do you need help with?"),
                    new ChatMessage(ChatRole.User, "What temperature should I bake pizza at?"),
                },
            };
            Response<ChatCompletions> response = await client.GetChatCompletionsAsync(requestOptions);
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.InstanceOf<ChatCompletions>());
            Assert.That(response.Value.Id, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Created, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Choices, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Choices.Count, Is.EqualTo(1));
            ChatChoice choice = response.Value.Choices[0];
            Assert.That(choice.Index, Is.EqualTo(0));
            Assert.That(choice.FinishReason, Is.EqualTo(CompletionsFinishReason.Stopped));
            Assert.That(choice.Message.Role, Is.EqualTo(ChatRole.Assistant));
            Assert.That(choice.Message.Content, Is.Not.Null.Or.Empty);
        }

        [RecordedTest]
        [TestCase(OpenAIClientServiceTarget.Azure)]
        [TestCase(OpenAIClientServiceTarget.NonAzure)]
        public async Task ChatCompletionsContentFilterCategories(OpenAIClientServiceTarget serviceTarget)
        {
            OpenAIClient client = GetTestClient(serviceTarget);
            string deploymentOrModelName = OpenAITestBase.GetDeploymentOrModelName(serviceTarget, OpenAIClientScenario.ChatCompletions);
            var requestOptions = new ChatCompletionsOptions()
            {
                DeploymentName = deploymentOrModelName,
                Messages =
                {
                    new ChatMessage(ChatRole.User, "How do I cook a bell pepper?"),
                },
            };
            Response<ChatCompletions> response = await client.GetChatCompletionsAsync(requestOptions);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.Not.Null);
            Assert.That(response.Value.Choices, Is.Not.Null.Or.Empty);

            ChatChoice firstChoice = response.Value.Choices[0];
            Assert.That(firstChoice, Is.Not.Null);

            AssertExpectedPromptFilterResults(
                response.Value.PromptFilterResults,
                serviceTarget,
                expectedCount: (requestOptions.ChoiceCount ?? 1));
            AssertExpectedContentFilterResults(firstChoice.ContentFilterResults, serviceTarget);
        }

        [RecordedTest]
        [TestCase(OpenAIClientServiceTarget.Azure)]
        [TestCase(OpenAIClientServiceTarget.NonAzure)]
        public async Task CompletionsContentFilterCategories(OpenAIClientServiceTarget serviceTarget)
        {
            OpenAIClient client = GetTestClient(serviceTarget);
            string deploymentOrModelName
                = OpenAITestBase.GetDeploymentOrModelName(serviceTarget, OpenAIClientScenario.LegacyCompletions);
            var requestOptions = new CompletionsOptions()
            {
                DeploymentName = deploymentOrModelName,
                Prompts = { "How do I cook a bell pepper?" },
                Temperature = 0
            };
            Response<Completions> response = await client.GetCompletionsAsync(requestOptions);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.Not.Null);
            Assert.That(response.Value.Choices, Is.Not.Null.Or.Empty);

            Choice firstChoice = response.Value.Choices[0];
            Assert.That(firstChoice, Is.Not.Null);

            AssertExpectedPromptFilterResults(
                response.Value.PromptFilterResults,
                serviceTarget,
                expectedCount: requestOptions.Prompts.Count * (requestOptions.ChoicesPerPrompt ?? 1));
            AssertExpectedContentFilterResults(firstChoice.ContentFilterResults, serviceTarget);
        }

        [RecordedTest]
        [TestCase(OpenAIClientServiceTarget.Azure)]
        [TestCase(OpenAIClientServiceTarget.NonAzure)]
        public async Task StreamingChatCompletions(OpenAIClientServiceTarget serviceTarget)
        {
            OpenAIClient client = GetTestClient(serviceTarget);
            string deploymentOrModelName = OpenAITestBase.GetDeploymentOrModelName(
                serviceTarget,
                OpenAIClientScenario.ChatCompletions);
            var requestOptions = new ChatCompletionsOptions()
            {
                DeploymentName = deploymentOrModelName,
                Messages =
                {
                    new ChatMessage(ChatRole.System, "You are a helpful assistant."),
                    new ChatMessage(ChatRole.User, "Can you help me?"),
                    new ChatMessage(ChatRole.Assistant, "Of course! What do you need help with?"),
                    new ChatMessage(ChatRole.User, "What temperature should I bake pizza at?"),
                },
                MaxTokens = 512,
            };
            Response<StreamingChatCompletions> streamingResponse
                = await client.GetChatCompletionsStreamingAsync(requestOptions);
            Assert.That(streamingResponse, Is.Not.Null);
            using StreamingChatCompletions streamingChatCompletions = streamingResponse.Value;
            Assert.That(streamingChatCompletions, Is.InstanceOf<StreamingChatCompletions>());

            int totalMessages = 0;

            await foreach (StreamingChatChoice streamingChoice in streamingChatCompletions.GetChoicesStreaming())
            {
                Assert.That(streamingChoice, Is.Not.Null);
                await foreach (ChatMessage streamingMessage in streamingChoice.GetMessageStreaming())
                {
                    Assert.That(streamingMessage.Role, Is.EqualTo(ChatRole.Assistant));
                    totalMessages++;
                }
                AssertExpectedContentFilterResults(streamingChoice.ContentFilterResults, serviceTarget);
            }

            Assert.That(totalMessages, Is.GreaterThan(1));

            // Note: these top-level values *are likely not yet populated* until *after* at least one streaming
            // choice has arrived.
            Assert.That(streamingResponse.GetRawResponse(), Is.Not.Null.Or.Empty);
            Assert.That(streamingChatCompletions.Id, Is.Not.Null.Or.Empty);
            Assert.That(streamingChatCompletions.Created, Is.GreaterThan(new DateTimeOffset(new DateTime(2023, 1, 1))));
            Assert.That(streamingChatCompletions.Created, Is.LessThan(DateTimeOffset.UtcNow.AddDays(7)));
            AssertExpectedPromptFilterResults(streamingChatCompletions.PromptFilterResults, serviceTarget, (requestOptions.ChoiceCount ?? 1));
        }

        [RecordedTest]
        [TestCase(OpenAIClientServiceTarget.Azure)]
        [TestCase(OpenAIClientServiceTarget.NonAzure)]
        public async Task AdvancedCompletionsOptions(OpenAIClientServiceTarget serviceTarget)
        {
            OpenAIClient client = GetTestClient(serviceTarget);
            string deploymentOrModelName = OpenAITestBase.GetDeploymentOrModelName(serviceTarget, OpenAIClientScenario.LegacyCompletions);
            string promptText = "Are bananas especially radioactive?";
            var requestOptions = new CompletionsOptions()
            {
                DeploymentName = deploymentOrModelName,
                Prompts = { promptText },
                GenerationSampleCount = 3,
                Temperature = 0.75f,
                User = "AzureSDKOpenAITests",
                Echo = true,
                LogProbabilityCount = 1,
                MaxTokens = 512,
                TokenSelectionBiases =
                {
                    [25996] = -100, // ' banana', with the leading space
                    [35484] = -100, // ' bananas', with the leading space
                    [40058] = -100, // ' Banana'
                    [15991] = -100, // 'anas'
                },
            };
            Response<Completions> response = await client.GetCompletionsAsync(requestOptions);

            Assert.That(response, Is.Not.Null);
            string rawResponse = response.GetRawResponse().Content.ToString();
            Assert.That(rawResponse, Is.Not.Null.Or.Empty);

            Assert.That(response.Value, Is.Not.Null);
            Assert.That(response.Value.Choices, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Choices.Count, Is.EqualTo(1));

            Choice choice = response.Value.Choices[0];

            string choiceText = choice.Text;
            Assert.That(choiceText, Is.Not.Null.Or.Empty);
            Assert.That(choiceText.Length, Is.GreaterThan(promptText.Length));
            Assert.That(choiceText.ToLower().StartsWith(promptText.ToLower()));
            Assert.That(choiceText.Substring(promptText.Length).Contains(" banana"), Is.False);

            Assert.That(choice.LogProbabilityModel, Is.Not.Null.Or.Empty);
            Assert.That(choice.LogProbabilityModel.Tokens, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Usage.TotalTokens, Is.GreaterThan(response.Value.Choices[0].LogProbabilityModel.Tokens.Count));
        }

        [RecordedTest]
        [TestCase(OpenAIClientServiceTarget.Azure)]
        [TestCase(OpenAIClientServiceTarget.NonAzure, Ignore = "Not applicable to non-Azure OpenAI")]
        public void BadDeploymentFails(OpenAIClientServiceTarget serviceTarget)
        {
            OpenAIClient client = GetTestClient(serviceTarget);
            var completionsRequest = new CompletionsOptions()
            {
                DeploymentName = "BAD_DEPLOYMENT_ID",
                Prompts = { "Hello world" },
            };
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await client.GetCompletionsAsync(completionsRequest);
            });
            Assert.AreEqual(404, exception.Status);
            Assert.That(exception.ErrorCode, Is.EqualTo("DeploymentNotFound"));
        }

        [RecordedTest]
        [TestCase(OpenAIClientServiceTarget.Azure)]
        [TestCase(OpenAIClientServiceTarget.NonAzure)]
        public async Task TokenCutoff(OpenAIClientServiceTarget serviceTarget)
        {
            OpenAIClient client = GetTestClient(serviceTarget);
            string deploymentOrModelName = OpenAITestBase.GetDeploymentOrModelName(serviceTarget, OpenAIClientScenario.LegacyCompletions);
            var requestOptions = new CompletionsOptions()
            {
                DeploymentName = deploymentOrModelName,
                Prompts =
                {
                    "How long would it take an unladen swallow to travel between Seattle, WA"
                        + " and New York, NY?"
                },
                MaxTokens = 3,
            };
            Response<Completions> response = await client.GetCompletionsAsync(requestOptions);
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.Not.Null);
            Assert.That(response.Value.Choices, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Choices[0].FinishReason, Is.EqualTo(CompletionsFinishReason.TokenLimitReached));
            Assert.IsTrue(response.Value.Choices[0].FinishReason == CompletionsFinishReason.TokenLimitReached);
            Assert.IsTrue(response.Value.Choices[0].FinishReason == "length");
        }

        [RecordedTest]
        [TestCase(OpenAIClientServiceTarget.Azure)]
        [TestCase(OpenAIClientServiceTarget.NonAzure)]
        public async Task StreamingCompletions(OpenAIClientServiceTarget serviceTarget)
        {
            // Temporary test note: at the time of authoring, content filter results aren't included for completions
            // with the latest 2023-07-01-preview service API version. We'll manually configure one version behind
            // pending the latest version having these results enabled.
            OpenAIClient client = GetTestClient(serviceTarget);

            string deploymentOrModelName = OpenAITestBase.GetDeploymentOrModelName(serviceTarget, OpenAIClientScenario.LegacyCompletions);
            var requestOptions = new CompletionsOptions()
            {
                DeploymentName = deploymentOrModelName,
                Prompts =
                {
                    "Tell me some jokes about mangos",
                    "What are some disturbing facts about papayas?"
                },
                MaxTokens = 512,
                LogProbabilityCount = 1,
            };

            Response<StreamingCompletions> response = await client.GetCompletionsStreamingAsync(requestOptions);
            Assert.That(response, Is.Not.Null);

            // StreamingCompletions implements IDisposable; capturing the .Value field of `response` with a `using`
            // statement is unusual but properly ensures that `.Dispose()` will be called, as `Response<T>` does *not*
            // implement IDisposable or otherwise ensure that an `IDisposable` underlying `.Value` is disposed.
            using StreamingCompletions responseValue = response.Value;

            int originallyEnumeratedChoices = 0;
            var originallyEnumeratedTextParts = new List<List<string>>();

            await foreach (StreamingChoice choice in responseValue.GetChoicesStreaming())
            {
                List<string> textPartsForChoice = new();
                StringBuilder choiceTextBuilder = new();
                await foreach (string choiceTextPart in choice.GetTextStreaming())
                {
                    choiceTextBuilder.Append(choiceTextPart);
                    textPartsForChoice.Add(choiceTextPart);
                }
                Assert.That(choiceTextBuilder.ToString(), Is.Not.Null.Or.Empty);
                Assert.That(choice.LogProbabilityModel, Is.Not.Null);
                AssertExpectedContentFilterResults(choice.ContentFilterResults, serviceTarget);
                originallyEnumeratedChoices++;
                originallyEnumeratedTextParts.Add(textPartsForChoice);
            }

            // Note: these top-level values *are likely not yet populated* until *after* at least one streaming
            // choice has arrived.
            Assert.That(response.GetRawResponse(), Is.Not.Null.Or.Empty);
            Assert.That(responseValue.Id, Is.Not.Null.Or.Empty);
            Assert.That(responseValue.Created, Is.GreaterThan(new DateTimeOffset(new DateTime(2023, 1, 1))));
            Assert.That(responseValue.Created, Is.LessThan(DateTimeOffset.UtcNow.AddDays(7)));

            AssertExpectedPromptFilterResults(
                responseValue.PromptFilterResults,
                serviceTarget,
                expectedCount: requestOptions.Prompts.Count * (requestOptions.ChoicesPerPrompt ?? 1));

            // Validate stability of enumeration (non-cancelled case)
            IReadOnlyList<StreamingChoice> secondPassChoices = await GetBlockingListFromIAsyncEnumerable(
                responseValue.GetChoicesStreaming());
            Assert.AreEqual(originallyEnumeratedChoices, secondPassChoices.Count);
            for (int i = 0; i < secondPassChoices.Count; i++)
            {
                IReadOnlyList<string> secondPassTextParts = await GetBlockingListFromIAsyncEnumerable(
                    secondPassChoices[i].GetTextStreaming());
                Assert.AreEqual(originallyEnumeratedTextParts[i].Count, secondPassTextParts.Count);
                for (int j = 0; j < originallyEnumeratedTextParts[i].Count; j++)
                {
                    Assert.AreEqual(originallyEnumeratedTextParts[i][j], secondPassTextParts[j]);
                }
            }
        }

        [RecordedTest]
        [Ignore("Built-in serialization/deserialization not yet supported, but can be achieved with a custom converter")]
        public void JsonTypeSerialization()
        {
            var originalMessage = new ChatMessage(ChatRole.User, "How do I make a great taco?");

            string clearTextSerializedMessage = System.Text.Json.JsonSerializer.Serialize(originalMessage);
            ChatMessage messageFromClearText = System.Text.Json.JsonSerializer.Deserialize<ChatMessage>(clearTextSerializedMessage);
            Assert.That(messageFromClearText.Role, Is.EqualTo(originalMessage.Role));
            Assert.That(messageFromClearText.Content, Is.EqualTo(originalMessage.Content));

            byte[] utf8SerializedMessage = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(originalMessage);
            ChatMessage messageFromUtf8Bytes = System.Text.Json.JsonSerializer.Deserialize<ChatMessage>(utf8SerializedMessage);
            Assert.That(messageFromUtf8Bytes.Role, Is.EqualTo(originalMessage.Role));
            Assert.That(messageFromUtf8Bytes.Content, Is.EqualTo(originalMessage.Content));
        }

        // Lightweight reimplementation of .NET 7 .ToBlockingEnumerable().ToList()
        private static async Task<IReadOnlyList<T>> GetBlockingListFromIAsyncEnumerable<T>(
            IAsyncEnumerable<T> asyncValues)
        {
            List<T> result = new();
            await foreach (T asyncValue in asyncValues)
            {
                result.Add(asyncValue);
            }
            return result;
        }

        private void AssertExpectedPromptFilterResults(
            IReadOnlyList<PromptFilterResult> promptFilterResults,
            OpenAIClientServiceTarget serviceTarget,
            int expectedCount)
        {
            if (serviceTarget == OpenAIClientServiceTarget.NonAzure)
            {
                Assert.That(promptFilterResults, Is.Null.Or.Empty);
            }
            else
            {
                Assert.That(promptFilterResults, Is.Not.Null.Or.Empty);
                Assert.That(promptFilterResults.Count, Is.EqualTo(expectedCount));
                for (int i = 0; i < promptFilterResults.Count; i++)
                {
                    Assert.That(promptFilterResults[i].PromptIndex, Is.EqualTo(i));
                    Assert.That(promptFilterResults[i].ContentFilterResults, Is.Not.Null);
                    Assert.That(promptFilterResults[i].ContentFilterResults.Hate, Is.Not.Null);
                    Assert.That(promptFilterResults[i].ContentFilterResults.Hate.Filtered, Is.False);
                    Assert.That(
                        promptFilterResults[0].ContentFilterResults.Hate.Severity,
                        Is.EqualTo(ContentFilterSeverity.Safe));
                }
            }
        }

        private void AssertExpectedContentFilterResults(
            ContentFilterResults contentFilterResults,
            OpenAIClientServiceTarget serviceTarget)
        {
            if (serviceTarget == OpenAIClientServiceTarget.NonAzure)
            {
                Assert.That(contentFilterResults, Is.Null);
            }
            else
            {
                Assert.That(contentFilterResults, Is.Not.Null.Or.Empty);
                Assert.That(contentFilterResults.Hate, Is.Not.Null);
                Assert.That(contentFilterResults.Hate.Filtered, Is.False);
                Assert.That(contentFilterResults.Hate.Severity, Is.EqualTo(ContentFilterSeverity.Safe));
            }
        }
    }
}
