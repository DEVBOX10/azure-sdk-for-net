// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.MachineLearning.Models
{
    public partial class IdleShutdownSetting : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(IdleTimeBeforeShutdown))
            {
                writer.WritePropertyName("idleTimeBeforeShutdown"u8);
                writer.WriteStringValue(IdleTimeBeforeShutdown);
            }
            writer.WriteEndObject();
        }
    }
}
