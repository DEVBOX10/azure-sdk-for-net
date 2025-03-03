// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.RecoveryServicesBackup.Models
{
    /// <summary> The BackupResourceEncryptionConfigExtendedCreateOrUpdateContent. </summary>
    public partial class BackupResourceEncryptionConfigExtendedCreateOrUpdateContent : TrackedResourceData
    {
        /// <summary> Initializes a new instance of BackupResourceEncryptionConfigExtendedCreateOrUpdateContent. </summary>
        /// <param name="location"> The location. </param>
        public BackupResourceEncryptionConfigExtendedCreateOrUpdateContent(AzureLocation location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of BackupResourceEncryptionConfigExtendedCreateOrUpdateContent. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="properties"> BackupResourceEncryptionConfigResource properties. </param>
        /// <param name="eTag"> Optional ETag. </param>
        internal BackupResourceEncryptionConfigExtendedCreateOrUpdateContent(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, BackupResourceEncryptionConfig properties, ETag? eTag) : base(id, name, resourceType, systemData, tags, location)
        {
            Properties = properties;
            ETag = eTag;
        }

        /// <summary> BackupResourceEncryptionConfigResource properties. </summary>
        public BackupResourceEncryptionConfig Properties { get; set; }
        /// <summary> Optional ETag. </summary>
        public ETag? ETag { get; set; }
    }
}
