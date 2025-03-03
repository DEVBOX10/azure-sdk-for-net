// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.Blueprint
{
    /// <summary> A class to add extension methods to ArmResource. </summary>
    internal partial class ArmResourceExtensionClient : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="ArmResourceExtensionClient"/> class for mocking. </summary>
        protected ArmResourceExtensionClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ArmResourceExtensionClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ArmResourceExtensionClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of BlueprintResources in the ArmResource. </summary>
        /// <returns> An object representing collection of BlueprintResources and their operations over a BlueprintResource. </returns>
        public virtual BlueprintCollection GetBlueprints()
        {
            return GetCachedClient(Client => new BlueprintCollection(Client, Id));
        }

        /// <summary> Gets a collection of AssignmentResources in the ArmResource. </summary>
        /// <returns> An object representing collection of AssignmentResources and their operations over a AssignmentResource. </returns>
        public virtual AssignmentCollection GetAssignments()
        {
            return GetCachedClient(Client => new AssignmentCollection(Client, Id));
        }
    }
}
