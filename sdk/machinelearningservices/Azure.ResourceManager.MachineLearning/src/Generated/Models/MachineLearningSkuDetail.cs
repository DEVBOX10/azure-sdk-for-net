// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.MachineLearning.Models
{
    /// <summary> Fulfills ARM Contract requirement to list all available SKUS for a resource. </summary>
    public partial class MachineLearningSkuDetail
    {
        /// <summary> Initializes a new instance of MachineLearningSkuDetail. </summary>
        internal MachineLearningSkuDetail()
        {
        }

        /// <summary> Initializes a new instance of MachineLearningSkuDetail. </summary>
        /// <param name="capacity"> Gets or sets the Sku Capacity. </param>
        /// <param name="resourceType"> The resource type name. </param>
        /// <param name="sku"> Gets or sets the Sku. </param>
        internal MachineLearningSkuDetail(MachineLearningSkuCapacity capacity, string resourceType, MachineLearningSkuSetting sku)
        {
            Capacity = capacity;
            ResourceType = resourceType;
            Sku = sku;
        }

        /// <summary> Gets or sets the Sku Capacity. </summary>
        public MachineLearningSkuCapacity Capacity { get; }
        /// <summary> The resource type name. </summary>
        public string ResourceType { get; }
        /// <summary> Gets or sets the Sku. </summary>
        public MachineLearningSkuSetting Sku { get; }
    }
}
