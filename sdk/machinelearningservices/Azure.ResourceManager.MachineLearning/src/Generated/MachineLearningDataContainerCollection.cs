// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.MachineLearning.Models;

namespace Azure.ResourceManager.MachineLearning
{
    /// <summary>
    /// A class representing a collection of <see cref="MachineLearningDataContainerResource" /> and their operations.
    /// Each <see cref="MachineLearningDataContainerResource" /> in the collection will belong to the same instance of <see cref="MachineLearningWorkspaceResource" />.
    /// To get a <see cref="MachineLearningDataContainerCollection" /> instance call the GetMachineLearningDataContainers method from an instance of <see cref="MachineLearningWorkspaceResource" />.
    /// </summary>
    public partial class MachineLearningDataContainerCollection : ArmCollection, IEnumerable<MachineLearningDataContainerResource>, IAsyncEnumerable<MachineLearningDataContainerResource>
    {
        private readonly ClientDiagnostics _machineLearningDataContainerDataContainersClientDiagnostics;
        private readonly DataContainersRestOperations _machineLearningDataContainerDataContainersRestClient;

        /// <summary> Initializes a new instance of the <see cref="MachineLearningDataContainerCollection"/> class for mocking. </summary>
        protected MachineLearningDataContainerCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MachineLearningDataContainerCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal MachineLearningDataContainerCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _machineLearningDataContainerDataContainersClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.MachineLearning", MachineLearningDataContainerResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(MachineLearningDataContainerResource.ResourceType, out string machineLearningDataContainerDataContainersApiVersion);
            _machineLearningDataContainerDataContainersRestClient = new DataContainersRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, machineLearningDataContainerDataContainersApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != MachineLearningWorkspaceResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, MachineLearningWorkspaceResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Create or update container.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/data/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DataContainers_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="name"> Container name. </param>
        /// <param name="data"> Container entity to create or update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<MachineLearningDataContainerResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string name, MachineLearningDataContainerData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _machineLearningDataContainerDataContainersClientDiagnostics.CreateScope("MachineLearningDataContainerCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _machineLearningDataContainerDataContainersRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, name, data, cancellationToken).ConfigureAwait(false);
                var operation = new MachineLearningArmOperation<MachineLearningDataContainerResource>(Response.FromValue(new MachineLearningDataContainerResource(Client, response), response.GetRawResponse()));
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
        /// Create or update container.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/data/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DataContainers_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="name"> Container name. </param>
        /// <param name="data"> Container entity to create or update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<MachineLearningDataContainerResource> CreateOrUpdate(WaitUntil waitUntil, string name, MachineLearningDataContainerData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _machineLearningDataContainerDataContainersClientDiagnostics.CreateScope("MachineLearningDataContainerCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _machineLearningDataContainerDataContainersRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, name, data, cancellationToken);
                var operation = new MachineLearningArmOperation<MachineLearningDataContainerResource>(Response.FromValue(new MachineLearningDataContainerResource(Client, response), response.GetRawResponse()));
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

        /// <summary>
        /// Get container.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/data/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DataContainers_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> Container name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<Response<MachineLearningDataContainerResource>> GetAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _machineLearningDataContainerDataContainersClientDiagnostics.CreateScope("MachineLearningDataContainerCollection.Get");
            scope.Start();
            try
            {
                var response = await _machineLearningDataContainerDataContainersRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new MachineLearningDataContainerResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get container.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/data/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DataContainers_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> Container name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<MachineLearningDataContainerResource> Get(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _machineLearningDataContainerDataContainersClientDiagnostics.CreateScope("MachineLearningDataContainerCollection.Get");
            scope.Start();
            try
            {
                var response = _machineLearningDataContainerDataContainersRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new MachineLearningDataContainerResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List data containers.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/data</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DataContainers_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="skip"> Continuation token for pagination. </param>
        /// <param name="listViewType"> View type for including/excluding (for example) archived entities. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="MachineLearningDataContainerResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<MachineLearningDataContainerResource> GetAllAsync(string skip = null, MachineLearningListViewType? listViewType = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _machineLearningDataContainerDataContainersRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, skip, listViewType);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _machineLearningDataContainerDataContainersRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, skip, listViewType);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new MachineLearningDataContainerResource(Client, MachineLearningDataContainerData.DeserializeMachineLearningDataContainerData(e)), _machineLearningDataContainerDataContainersClientDiagnostics, Pipeline, "MachineLearningDataContainerCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// List data containers.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/data</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DataContainers_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="skip"> Continuation token for pagination. </param>
        /// <param name="listViewType"> View type for including/excluding (for example) archived entities. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MachineLearningDataContainerResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<MachineLearningDataContainerResource> GetAll(string skip = null, MachineLearningListViewType? listViewType = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _machineLearningDataContainerDataContainersRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, skip, listViewType);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _machineLearningDataContainerDataContainersRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, skip, listViewType);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new MachineLearningDataContainerResource(Client, MachineLearningDataContainerData.DeserializeMachineLearningDataContainerData(e)), _machineLearningDataContainerDataContainersClientDiagnostics, Pipeline, "MachineLearningDataContainerCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/data/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DataContainers_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> Container name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _machineLearningDataContainerDataContainersClientDiagnostics.CreateScope("MachineLearningDataContainerCollection.Exists");
            scope.Start();
            try
            {
                var response = await _machineLearningDataContainerDataContainersRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, name, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/data/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DataContainers_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> Container name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<bool> Exists(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _machineLearningDataContainerDataContainersClientDiagnostics.CreateScope("MachineLearningDataContainerCollection.Exists");
            scope.Start();
            try
            {
                var response = _machineLearningDataContainerDataContainersRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, name, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/data/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DataContainers_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> Container name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<NullableResponse<MachineLearningDataContainerResource>> GetIfExistsAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _machineLearningDataContainerDataContainersClientDiagnostics.CreateScope("MachineLearningDataContainerCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _machineLearningDataContainerDataContainersRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, name, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<MachineLearningDataContainerResource>(response.GetRawResponse());
                return Response.FromValue(new MachineLearningDataContainerResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/data/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DataContainers_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> Container name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual NullableResponse<MachineLearningDataContainerResource> GetIfExists(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _machineLearningDataContainerDataContainersClientDiagnostics.CreateScope("MachineLearningDataContainerCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _machineLearningDataContainerDataContainersRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, name, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<MachineLearningDataContainerResource>(response.GetRawResponse());
                return Response.FromValue(new MachineLearningDataContainerResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<MachineLearningDataContainerResource> IEnumerable<MachineLearningDataContainerResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<MachineLearningDataContainerResource> IAsyncEnumerable<MachineLearningDataContainerResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
