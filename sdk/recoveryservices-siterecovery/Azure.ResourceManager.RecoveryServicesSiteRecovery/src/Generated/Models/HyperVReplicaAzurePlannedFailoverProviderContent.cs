// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Models
{
    /// <summary> HyperVReplicaAzure specific planned failover input. </summary>
    public partial class HyperVReplicaAzurePlannedFailoverProviderContent : PlannedFailoverProviderSpecificFailoverContent
    {
        /// <summary> Initializes a new instance of HyperVReplicaAzurePlannedFailoverProviderContent. </summary>
        public HyperVReplicaAzurePlannedFailoverProviderContent()
        {
            InstanceType = "HyperVReplicaAzure";
        }

        /// <summary> Primary kek certificate pfx. </summary>
        public string PrimaryKekCertificatePfx { get; set; }
        /// <summary> Secondary kek certificate pfx. </summary>
        public string SecondaryKekCertificatePfx { get; set; }
        /// <summary> The recovery point id to be passed to failover to a particular recovery point. In case of latest recovery point, null should be passed. </summary>
        public ResourceIdentifier RecoveryPointId { get; set; }
        /// <summary> A value indicating the inplace OS Upgrade version. </summary>
        public string OSUpgradeVersion { get; set; }
    }
}
