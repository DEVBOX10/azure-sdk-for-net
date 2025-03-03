// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.MachineLearning.Models
{
    /// <summary> The MachineLearningWorkspaceGetKeysResult. </summary>
    public partial class MachineLearningWorkspaceGetKeysResult
    {
        /// <summary> Initializes a new instance of MachineLearningWorkspaceGetKeysResult. </summary>
        internal MachineLearningWorkspaceGetKeysResult()
        {
        }

        /// <summary> Initializes a new instance of MachineLearningWorkspaceGetKeysResult. </summary>
        /// <param name="appInsightsInstrumentationKey"> The access key of the workspace app insights. </param>
        /// <param name="containerRegistryCredentials"></param>
        /// <param name="notebookAccessKeys"></param>
        /// <param name="userStorageResourceId"> The arm Id key of the workspace storage. </param>
        /// <param name="userStorageKey"> The access key of the workspace storage. </param>
        internal MachineLearningWorkspaceGetKeysResult(string appInsightsInstrumentationKey, MachineLearningContainerRegistryCredentials containerRegistryCredentials, MachineLearningWorkspaceGetNotebookKeysResult notebookAccessKeys, string userStorageResourceId, string userStorageKey)
        {
            AppInsightsInstrumentationKey = appInsightsInstrumentationKey;
            ContainerRegistryCredentials = containerRegistryCredentials;
            NotebookAccessKeys = notebookAccessKeys;
            UserStorageResourceId = userStorageResourceId;
            UserStorageKey = userStorageKey;
        }

        /// <summary> The access key of the workspace app insights. </summary>
        public string AppInsightsInstrumentationKey { get; }
        /// <summary> Gets the container registry credentials. </summary>
        public MachineLearningContainerRegistryCredentials ContainerRegistryCredentials { get; }
        /// <summary> Gets the notebook access keys. </summary>
        public MachineLearningWorkspaceGetNotebookKeysResult NotebookAccessKeys { get; }
        /// <summary> The arm Id key of the workspace storage. </summary>
        public string UserStorageResourceId { get; }
        /// <summary> The access key of the workspace storage. </summary>
        public string UserStorageKey { get; }
    }
}
