// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.CosmosDB.Models
{
    /// <summary> Configuration values for periodic mode backup. </summary>
    internal partial class ContinuousModeProperties
    {
        /// <summary> Initializes a new instance of ContinuousModeProperties. </summary>
        public ContinuousModeProperties()
        {
        }

        /// <summary> Initializes a new instance of ContinuousModeProperties. </summary>
        /// <param name="tier"> Enum to indicate type of Continuos backup mode. </param>
        internal ContinuousModeProperties(ContinuousTier? tier)
        {
            Tier = tier;
        }

        /// <summary> Enum to indicate type of Continuos backup mode. </summary>
        public ContinuousTier? Tier { get; set; }
    }
}
