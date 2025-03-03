// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.ApiManagement.Models
{
    /// <summary> Paged Tag list representation. </summary>
    internal partial class TagResourceListResult
    {
        /// <summary> Initializes a new instance of TagResourceListResult. </summary>
        internal TagResourceListResult()
        {
            Value = new ChangeTrackingList<TagResourceContractDetails>();
        }

        /// <summary> Initializes a new instance of TagResourceListResult. </summary>
        /// <param name="value"> Page values. </param>
        /// <param name="count"> Total record count number across all pages. </param>
        /// <param name="nextLink"> Next page link if any. </param>
        internal TagResourceListResult(IReadOnlyList<TagResourceContractDetails> value, long? count, string nextLink)
        {
            Value = value;
            Count = count;
            NextLink = nextLink;
        }

        /// <summary> Page values. </summary>
        public IReadOnlyList<TagResourceContractDetails> Value { get; }
        /// <summary> Total record count number across all pages. </summary>
        public long? Count { get; }
        /// <summary> Next page link if any. </summary>
        public string NextLink { get; }
    }
}
