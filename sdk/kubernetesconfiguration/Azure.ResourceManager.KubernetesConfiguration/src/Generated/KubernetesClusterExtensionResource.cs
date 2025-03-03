// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.KubernetesConfiguration.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.KubernetesConfiguration
{
    /// <summary>
    /// A Class representing a KubernetesClusterExtension along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="KubernetesClusterExtensionResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetKubernetesClusterExtensionResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetKubernetesClusterExtension method.
    /// </summary>
    public partial class KubernetesClusterExtensionResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="KubernetesClusterExtensionResource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="clusterRp"> The clusterRp. </param>
        /// <param name="clusterResourceName"> The clusterResourceName. </param>
        /// <param name="clusterName"> The clusterName. </param>
        /// <param name="extensionName"> The extensionName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterRp, string clusterResourceName, string clusterName, string extensionName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{clusterRp}/{clusterResourceName}/{clusterName}/providers/Microsoft.KubernetesConfiguration/extensions/{extensionName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _kubernetesClusterExtensionExtensionsClientDiagnostics;
        private readonly ExtensionsRestOperations _kubernetesClusterExtensionExtensionsRestClient;
        private readonly KubernetesClusterExtensionData _data;

        /// <summary> Initializes a new instance of the <see cref="KubernetesClusterExtensionResource"/> class for mocking. </summary>
        protected KubernetesClusterExtensionResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "KubernetesClusterExtensionResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal KubernetesClusterExtensionResource(ArmClient client, KubernetesClusterExtensionData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="KubernetesClusterExtensionResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal KubernetesClusterExtensionResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _kubernetesClusterExtensionExtensionsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.KubernetesConfiguration", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string kubernetesClusterExtensionExtensionsApiVersion);
            _kubernetesClusterExtensionExtensionsRestClient = new ExtensionsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, kubernetesClusterExtensionExtensionsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.KubernetesConfiguration/extensions";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual KubernetesClusterExtensionData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary>
        /// Gets Kubernetes Cluster Extension.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{clusterRp}/{clusterResourceName}/{clusterName}/providers/Microsoft.KubernetesConfiguration/extensions/{extensionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Extensions_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<KubernetesClusterExtensionResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _kubernetesClusterExtensionExtensionsClientDiagnostics.CreateScope("KubernetesClusterExtensionResource.Get");
            scope.Start();
            try
            {
                var response = await _kubernetesClusterExtensionExtensionsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.ResourceType.Namespace, Id.Parent.ResourceType.GetLastType(), Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new KubernetesClusterExtensionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets Kubernetes Cluster Extension.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{clusterRp}/{clusterResourceName}/{clusterName}/providers/Microsoft.KubernetesConfiguration/extensions/{extensionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Extensions_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<KubernetesClusterExtensionResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _kubernetesClusterExtensionExtensionsClientDiagnostics.CreateScope("KubernetesClusterExtensionResource.Get");
            scope.Start();
            try
            {
                var response = _kubernetesClusterExtensionExtensionsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.ResourceType.Namespace, Id.Parent.ResourceType.GetLastType(), Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new KubernetesClusterExtensionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Delete a Kubernetes Cluster Extension. This will cause the Agent to Uninstall the extension from the cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{clusterRp}/{clusterResourceName}/{clusterName}/providers/Microsoft.KubernetesConfiguration/extensions/{extensionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Extensions_Delete</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="forceDelete"> Delete the extension resource in Azure - not the normal asynchronous delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, bool? forceDelete = null, CancellationToken cancellationToken = default)
        {
            using var scope = _kubernetesClusterExtensionExtensionsClientDiagnostics.CreateScope("KubernetesClusterExtensionResource.Delete");
            scope.Start();
            try
            {
                var response = await _kubernetesClusterExtensionExtensionsRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.ResourceType.Namespace, Id.Parent.ResourceType.GetLastType(), Id.Parent.Name, Id.Name, forceDelete, cancellationToken).ConfigureAwait(false);
                var operation = new KubernetesConfigurationArmOperation(_kubernetesClusterExtensionExtensionsClientDiagnostics, Pipeline, _kubernetesClusterExtensionExtensionsRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.ResourceType.Namespace, Id.Parent.ResourceType.GetLastType(), Id.Parent.Name, Id.Name, forceDelete).Request, response, OperationFinalStateVia.AzureAsyncOperation);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Delete a Kubernetes Cluster Extension. This will cause the Agent to Uninstall the extension from the cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{clusterRp}/{clusterResourceName}/{clusterName}/providers/Microsoft.KubernetesConfiguration/extensions/{extensionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Extensions_Delete</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="forceDelete"> Delete the extension resource in Azure - not the normal asynchronous delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, bool? forceDelete = null, CancellationToken cancellationToken = default)
        {
            using var scope = _kubernetesClusterExtensionExtensionsClientDiagnostics.CreateScope("KubernetesClusterExtensionResource.Delete");
            scope.Start();
            try
            {
                var response = _kubernetesClusterExtensionExtensionsRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.ResourceType.Namespace, Id.Parent.ResourceType.GetLastType(), Id.Parent.Name, Id.Name, forceDelete, cancellationToken);
                var operation = new KubernetesConfigurationArmOperation(_kubernetesClusterExtensionExtensionsClientDiagnostics, Pipeline, _kubernetesClusterExtensionExtensionsRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.ResourceType.Namespace, Id.Parent.ResourceType.GetLastType(), Id.Parent.Name, Id.Name, forceDelete).Request, response, OperationFinalStateVia.AzureAsyncOperation);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Patch an existing Kubernetes Cluster Extension.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{clusterRp}/{clusterResourceName}/{clusterName}/providers/Microsoft.KubernetesConfiguration/extensions/{extensionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Extensions_Update</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="patch"> Properties to Patch in an existing Extension. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual async Task<ArmOperation<KubernetesClusterExtensionResource>> UpdateAsync(WaitUntil waitUntil, KubernetesClusterExtensionPatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using var scope = _kubernetesClusterExtensionExtensionsClientDiagnostics.CreateScope("KubernetesClusterExtensionResource.Update");
            scope.Start();
            try
            {
                var response = await _kubernetesClusterExtensionExtensionsRestClient.UpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.ResourceType.Namespace, Id.Parent.ResourceType.GetLastType(), Id.Parent.Name, Id.Name, patch, cancellationToken).ConfigureAwait(false);
                var operation = new KubernetesConfigurationArmOperation<KubernetesClusterExtensionResource>(new KubernetesClusterExtensionOperationSource(Client), _kubernetesClusterExtensionExtensionsClientDiagnostics, Pipeline, _kubernetesClusterExtensionExtensionsRestClient.CreateUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.ResourceType.Namespace, Id.Parent.ResourceType.GetLastType(), Id.Parent.Name, Id.Name, patch).Request, response, OperationFinalStateVia.AzureAsyncOperation);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Patch an existing Kubernetes Cluster Extension.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{clusterRp}/{clusterResourceName}/{clusterName}/providers/Microsoft.KubernetesConfiguration/extensions/{extensionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Extensions_Update</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="patch"> Properties to Patch in an existing Extension. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual ArmOperation<KubernetesClusterExtensionResource> Update(WaitUntil waitUntil, KubernetesClusterExtensionPatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using var scope = _kubernetesClusterExtensionExtensionsClientDiagnostics.CreateScope("KubernetesClusterExtensionResource.Update");
            scope.Start();
            try
            {
                var response = _kubernetesClusterExtensionExtensionsRestClient.Update(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.ResourceType.Namespace, Id.Parent.ResourceType.GetLastType(), Id.Parent.Name, Id.Name, patch, cancellationToken);
                var operation = new KubernetesConfigurationArmOperation<KubernetesClusterExtensionResource>(new KubernetesClusterExtensionOperationSource(Client), _kubernetesClusterExtensionExtensionsClientDiagnostics, Pipeline, _kubernetesClusterExtensionExtensionsRestClient.CreateUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.ResourceType.Namespace, Id.Parent.ResourceType.GetLastType(), Id.Parent.Name, Id.Name, patch).Request, response, OperationFinalStateVia.AzureAsyncOperation);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
