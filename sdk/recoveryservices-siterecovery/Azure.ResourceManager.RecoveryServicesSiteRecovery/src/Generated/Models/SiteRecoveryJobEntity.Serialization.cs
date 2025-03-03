// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Models
{
    public partial class SiteRecoveryJobEntity
    {
        internal static SiteRecoveryJobEntity DeserializeSiteRecoveryJobEntity(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<ResourceIdentifier> jobId = default;
            Optional<string> jobFriendlyName = default;
            Optional<string> targetObjectId = default;
            Optional<string> targetObjectName = default;
            Optional<string> targetInstanceType = default;
            Optional<string> jobScenarioName = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("jobId"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    jobId = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("jobFriendlyName"u8))
                {
                    jobFriendlyName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("targetObjectId"u8))
                {
                    targetObjectId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("targetObjectName"u8))
                {
                    targetObjectName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("targetInstanceType"u8))
                {
                    targetInstanceType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("jobScenarioName"u8))
                {
                    jobScenarioName = property.Value.GetString();
                    continue;
                }
            }
            return new SiteRecoveryJobEntity(jobId.Value, jobFriendlyName.Value, targetObjectId.Value, targetObjectName.Value, targetInstanceType.Value, jobScenarioName.Value);
        }
    }
}
