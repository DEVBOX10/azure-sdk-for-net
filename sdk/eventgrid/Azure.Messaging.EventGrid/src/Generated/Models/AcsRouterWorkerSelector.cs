// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    /// <summary> Router Job Worker Selector. </summary>
    public partial class AcsRouterWorkerSelector
    {
        /// <summary> Initializes a new instance of AcsRouterWorkerSelector. </summary>
        internal AcsRouterWorkerSelector()
        {
        }

        /// <summary> Initializes a new instance of AcsRouterWorkerSelector. </summary>
        /// <param name="key"> Router Job Worker Selector Key. </param>
        /// <param name="operator"> Router Job Worker Selector Label Operator. </param>
        /// <param name="labelValue"> Router Job Worker Selector Value. </param>
        /// <param name="ttlSeconds"> Router Job Worker Selector Time to Live in Seconds. </param>
        /// <param name="selectorState"> Router Job Worker Selector State. </param>
        /// <param name="expirationTime"> Router Job Worker Selector Expiration Time. </param>
        internal AcsRouterWorkerSelector(string key, AcsRouterLabelOperator? @operator, object labelValue, float? ttlSeconds, AcsRouterWorkerSelectorState? selectorState, DateTimeOffset? expirationTime)
        {
            Key = key;
            Operator = @operator;
            LabelValue = labelValue;
            TtlSeconds = ttlSeconds;
            SelectorState = selectorState;
            ExpirationTime = expirationTime;
        }

        /// <summary> Router Job Worker Selector Key. </summary>
        public string Key { get; }
        /// <summary> Router Job Worker Selector Value. </summary>
        public object LabelValue { get; }
        /// <summary> Router Job Worker Selector Expiration Time. </summary>
        public DateTimeOffset? ExpirationTime { get; }
    }
}
