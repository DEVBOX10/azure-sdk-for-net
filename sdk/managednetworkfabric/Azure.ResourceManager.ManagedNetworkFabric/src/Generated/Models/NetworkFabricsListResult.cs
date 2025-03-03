// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.ManagedNetworkFabric;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    /// <summary> List of Network Fabrics. </summary>
    internal partial class NetworkFabricsListResult
    {
        /// <summary> Initializes a new instance of NetworkFabricsListResult. </summary>
        internal NetworkFabricsListResult()
        {
            Value = new ChangeTrackingList<NetworkFabricData>();
        }

        /// <summary> Initializes a new instance of NetworkFabricsListResult. </summary>
        /// <param name="value"> List of Network Fabric resources. </param>
        /// <param name="nextLink"> Url to follow for getting next page of resources. </param>
        internal NetworkFabricsListResult(IReadOnlyList<NetworkFabricData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> List of Network Fabric resources. </summary>
        public IReadOnlyList<NetworkFabricData> Value { get; }
        /// <summary> Url to follow for getting next page of resources. </summary>
        public string NextLink { get; }
    }
}
