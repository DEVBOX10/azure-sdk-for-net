// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.OpenAI
{
    /// <summary>
    /// A specific representation of configurable options for Azure Cognitive Search when using it as an Azure OpenAI chat
    /// extension.
    /// </summary>
    public partial class AzureCognitiveSearchChatExtensionConfiguration : AzureChatExtensionConfiguration
    {
        // CUSTOM CODE NOTE: this override effects the desired "default" behavior in the derived type
        public override AzureChatExtensionType Type
        {
            get => base.Type == default ? AzureChatExtensionType.AzureCognitiveSearch : base.Type;
            set => base.Type = value;
        }

        // CUSTOM CODE NOTE: the following required properties have setters added here to support an init-only
        //                      default constructor pattern and use AzureKeyCredential for key fields

        /// <summary> The absolute endpoint path for the Azure Cognitive Search resource to use. </summary>
        public Uri SearchEndpoint { get; set; }
        /// <summary> The API key to use with the specified Azure Cognitive Search endpoint. </summary>
        public AzureKeyCredential SearchKey { get; set; }
        /// <summary> The name of the index to use as available in the referenced Azure Cognitive Search resource. </summary>
        public string IndexName { get; set; }
        /// <summary> When using embeddings, specifies the API key to use with the provided embeddings endpoint. </summary>
        public AzureKeyCredential EmbeddingKey { get; set; }

        /// <summary>
        /// Initializes a new instance of AzureCognitiveSearchChatExtensionConfiguration.
        /// </summary>
        public AzureCognitiveSearchChatExtensionConfiguration()
        {
        }

        /// <summary> Initializes a new instance of AzureCognitiveSearchChatExtensionConfiguration. </summary>
        /// <param name="type">
        /// The type label to use when configuring Azure OpenAI chat extensions. This should typically not be changed from its
        /// default value for Azure Cognitive Search.
        /// </param>
        /// <param name="searchEndpoint"> The absolute endpoint path for the Azure Cognitive Search resource to use. </param>
        /// <param name="searchKey"> The API key to use with the specified Azure Cognitive Search endpoint. </param>
        /// <param name="indexName"> The name of the index to use as available in the referenced Azure Cognitive Search resource. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="searchEndpoint"/>, <paramref name="searchKey"/> or <paramref name="indexName"/> is null. </exception>
        public AzureCognitiveSearchChatExtensionConfiguration(AzureChatExtensionType type, Uri searchEndpoint, AzureKeyCredential searchKey, string indexName)
        {
            Argument.AssertNotNull(searchEndpoint, nameof(searchEndpoint));
            Argument.AssertNotNull(searchKey, nameof(searchKey));
            Argument.AssertNotNull(indexName, nameof(indexName));

            Type = type;
            SearchEndpoint = searchEndpoint;
            SearchKey = searchKey;
            IndexName = indexName;
        }

        /// <summary> Initializes a new instance of AzureCognitiveSearchChatExtensionConfiguration. </summary>
        /// <param name="type">
        /// The type label to use when configuring Azure OpenAI chat extensions. This should typically not be changed from its
        /// default value for Azure Cognitive Search.
        /// </param>
        /// <param name="searchEndpoint"> The absolute endpoint path for the Azure Cognitive Search resource to use. </param>
        /// <param name="searchKey"> The API key to use with the specified Azure Cognitive Search endpoint. </param>
        /// <param name="indexName"> The name of the index to use as available in the referenced Azure Cognitive Search resource. </param>
        /// <param name="fieldMappingOptions"> Customized field mapping behavior to use when interacting with the search index. </param>
        /// <param name="documentCount"> The configured top number of documents to feature for the configured query. </param>
        /// <param name="queryType"> The query type to use with Azure Cognitive Search. </param>
        /// <param name="shouldRestrictResultScope"> Whether queries should be restricted to use of indexed data. </param>
        /// <param name="semanticConfiguration"> The additional semantic configuration for the query. </param>
        /// <param name="embeddingEndpoint"> When using embeddings for search, specifies the resource URL from which embeddings should be retrieved. </param>
        /// <param name="embeddingKey"> When using embeddings, specifies the API key to use with the provided embeddings endpoint. </param>
        internal AzureCognitiveSearchChatExtensionConfiguration(AzureChatExtensionType type, Uri searchEndpoint, AzureKeyCredential searchKey, string indexName, AzureCognitiveSearchIndexFieldMappingOptions fieldMappingOptions, int? documentCount, AzureCognitiveSearchQueryType? queryType, bool? shouldRestrictResultScope, string semanticConfiguration, Uri embeddingEndpoint, AzureKeyCredential embeddingKey)
        {
            Type = type;
            SearchEndpoint = searchEndpoint;
            SearchKey = searchKey;
            IndexName = indexName;
            FieldMappingOptions = fieldMappingOptions;
            DocumentCount = documentCount;
            QueryType = queryType;
            ShouldRestrictResultScope = shouldRestrictResultScope;
            SemanticConfiguration = semanticConfiguration;
            EmbeddingEndpoint = embeddingEndpoint;
            EmbeddingKey = embeddingKey;
        }
        /// <summary> Customized field mapping behavior to use when interacting with the search index. </summary>
        public AzureCognitiveSearchIndexFieldMappingOptions FieldMappingOptions { get; set; }
        /// <summary> The configured top number of documents to feature for the configured query. </summary>
        public int? DocumentCount { get; set; }
        /// <summary> The query type to use with Azure Cognitive Search. </summary>
        public AzureCognitiveSearchQueryType? QueryType { get; set; }
        /// <summary> Whether queries should be restricted to use of indexed data. </summary>
        public bool? ShouldRestrictResultScope { get; set; }
        /// <summary> The additional semantic configuration for the query. </summary>
        public string SemanticConfiguration { get; set; }
        /// <summary> When using embeddings for search, specifies the resource URL from which embeddings should be retrieved. </summary>
        public Uri EmbeddingEndpoint { get; set; }
    }
}
