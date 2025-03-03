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

namespace Azure.ResourceManager.DevCenter
{
    /// <summary>
    /// A class representing a collection of <see cref="DevBoxDefinitionResource" /> and their operations.
    /// Each <see cref="DevBoxDefinitionResource" /> in the collection will belong to the same instance of <see cref="DevCenterResource" />.
    /// To get a <see cref="DevBoxDefinitionCollection" /> instance call the GetDevBoxDefinitions method from an instance of <see cref="DevCenterResource" />.
    /// </summary>
    public partial class DevBoxDefinitionCollection : ArmCollection, IEnumerable<DevBoxDefinitionResource>, IAsyncEnumerable<DevBoxDefinitionResource>
    {
        private readonly ClientDiagnostics _devBoxDefinitionClientDiagnostics;
        private readonly DevBoxDefinitionsRestOperations _devBoxDefinitionRestClient;

        /// <summary> Initializes a new instance of the <see cref="DevBoxDefinitionCollection"/> class for mocking. </summary>
        protected DevBoxDefinitionCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="DevBoxDefinitionCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal DevBoxDefinitionCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _devBoxDefinitionClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.DevCenter", DevBoxDefinitionResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(DevBoxDefinitionResource.ResourceType, out string devBoxDefinitionApiVersion);
            _devBoxDefinitionRestClient = new DevBoxDefinitionsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, devBoxDefinitionApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != DevCenterResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, DevCenterResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates or updates a Dev Box definition.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devcenters/{devCenterName}/devboxdefinitions/{devBoxDefinitionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DevBoxDefinitions_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="devBoxDefinitionName"> The name of the Dev Box definition. </param>
        /// <param name="data"> Represents a Dev Box definition. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="devBoxDefinitionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="devBoxDefinitionName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<DevBoxDefinitionResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string devBoxDefinitionName, DevBoxDefinitionData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(devBoxDefinitionName, nameof(devBoxDefinitionName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _devBoxDefinitionClientDiagnostics.CreateScope("DevBoxDefinitionCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _devBoxDefinitionRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, devBoxDefinitionName, data, cancellationToken).ConfigureAwait(false);
                var operation = new DevCenterArmOperation<DevBoxDefinitionResource>(new DevBoxDefinitionOperationSource(Client), _devBoxDefinitionClientDiagnostics, Pipeline, _devBoxDefinitionRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, devBoxDefinitionName, data).Request, response, OperationFinalStateVia.AzureAsyncOperation);
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
        /// Creates or updates a Dev Box definition.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devcenters/{devCenterName}/devboxdefinitions/{devBoxDefinitionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DevBoxDefinitions_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="devBoxDefinitionName"> The name of the Dev Box definition. </param>
        /// <param name="data"> Represents a Dev Box definition. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="devBoxDefinitionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="devBoxDefinitionName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<DevBoxDefinitionResource> CreateOrUpdate(WaitUntil waitUntil, string devBoxDefinitionName, DevBoxDefinitionData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(devBoxDefinitionName, nameof(devBoxDefinitionName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _devBoxDefinitionClientDiagnostics.CreateScope("DevBoxDefinitionCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _devBoxDefinitionRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, devBoxDefinitionName, data, cancellationToken);
                var operation = new DevCenterArmOperation<DevBoxDefinitionResource>(new DevBoxDefinitionOperationSource(Client), _devBoxDefinitionClientDiagnostics, Pipeline, _devBoxDefinitionRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, devBoxDefinitionName, data).Request, response, OperationFinalStateVia.AzureAsyncOperation);
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
        /// Gets a Dev Box definition
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devcenters/{devCenterName}/devboxdefinitions/{devBoxDefinitionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DevBoxDefinitions_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="devBoxDefinitionName"> The name of the Dev Box definition. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="devBoxDefinitionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="devBoxDefinitionName"/> is null. </exception>
        public virtual async Task<Response<DevBoxDefinitionResource>> GetAsync(string devBoxDefinitionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(devBoxDefinitionName, nameof(devBoxDefinitionName));

            using var scope = _devBoxDefinitionClientDiagnostics.CreateScope("DevBoxDefinitionCollection.Get");
            scope.Start();
            try
            {
                var response = await _devBoxDefinitionRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, devBoxDefinitionName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DevBoxDefinitionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a Dev Box definition
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devcenters/{devCenterName}/devboxdefinitions/{devBoxDefinitionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DevBoxDefinitions_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="devBoxDefinitionName"> The name of the Dev Box definition. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="devBoxDefinitionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="devBoxDefinitionName"/> is null. </exception>
        public virtual Response<DevBoxDefinitionResource> Get(string devBoxDefinitionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(devBoxDefinitionName, nameof(devBoxDefinitionName));

            using var scope = _devBoxDefinitionClientDiagnostics.CreateScope("DevBoxDefinitionCollection.Get");
            scope.Start();
            try
            {
                var response = _devBoxDefinitionRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, devBoxDefinitionName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DevBoxDefinitionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List Dev Box definitions for a devcenter.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devcenters/{devCenterName}/devboxdefinitions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DevBoxDefinitions_ListByDevCenter</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: '$top=10'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DevBoxDefinitionResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DevBoxDefinitionResource> GetAllAsync(int? top = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _devBoxDefinitionRestClient.CreateListByDevCenterRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, top);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _devBoxDefinitionRestClient.CreateListByDevCenterNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, top);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new DevBoxDefinitionResource(Client, DevBoxDefinitionData.DeserializeDevBoxDefinitionData(e)), _devBoxDefinitionClientDiagnostics, Pipeline, "DevBoxDefinitionCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// List Dev Box definitions for a devcenter.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devcenters/{devCenterName}/devboxdefinitions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DevBoxDefinitions_ListByDevCenter</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: '$top=10'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DevBoxDefinitionResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DevBoxDefinitionResource> GetAll(int? top = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _devBoxDefinitionRestClient.CreateListByDevCenterRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, top);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _devBoxDefinitionRestClient.CreateListByDevCenterNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, top);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new DevBoxDefinitionResource(Client, DevBoxDefinitionData.DeserializeDevBoxDefinitionData(e)), _devBoxDefinitionClientDiagnostics, Pipeline, "DevBoxDefinitionCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devcenters/{devCenterName}/devboxdefinitions/{devBoxDefinitionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DevBoxDefinitions_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="devBoxDefinitionName"> The name of the Dev Box definition. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="devBoxDefinitionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="devBoxDefinitionName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string devBoxDefinitionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(devBoxDefinitionName, nameof(devBoxDefinitionName));

            using var scope = _devBoxDefinitionClientDiagnostics.CreateScope("DevBoxDefinitionCollection.Exists");
            scope.Start();
            try
            {
                var response = await _devBoxDefinitionRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, devBoxDefinitionName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devcenters/{devCenterName}/devboxdefinitions/{devBoxDefinitionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DevBoxDefinitions_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="devBoxDefinitionName"> The name of the Dev Box definition. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="devBoxDefinitionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="devBoxDefinitionName"/> is null. </exception>
        public virtual Response<bool> Exists(string devBoxDefinitionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(devBoxDefinitionName, nameof(devBoxDefinitionName));

            using var scope = _devBoxDefinitionClientDiagnostics.CreateScope("DevBoxDefinitionCollection.Exists");
            scope.Start();
            try
            {
                var response = _devBoxDefinitionRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, devBoxDefinitionName, cancellationToken: cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devcenters/{devCenterName}/devboxdefinitions/{devBoxDefinitionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DevBoxDefinitions_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="devBoxDefinitionName"> The name of the Dev Box definition. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="devBoxDefinitionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="devBoxDefinitionName"/> is null. </exception>
        public virtual async Task<NullableResponse<DevBoxDefinitionResource>> GetIfExistsAsync(string devBoxDefinitionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(devBoxDefinitionName, nameof(devBoxDefinitionName));

            using var scope = _devBoxDefinitionClientDiagnostics.CreateScope("DevBoxDefinitionCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _devBoxDefinitionRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, devBoxDefinitionName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<DevBoxDefinitionResource>(response.GetRawResponse());
                return Response.FromValue(new DevBoxDefinitionResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devcenters/{devCenterName}/devboxdefinitions/{devBoxDefinitionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DevBoxDefinitions_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="devBoxDefinitionName"> The name of the Dev Box definition. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="devBoxDefinitionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="devBoxDefinitionName"/> is null. </exception>
        public virtual NullableResponse<DevBoxDefinitionResource> GetIfExists(string devBoxDefinitionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(devBoxDefinitionName, nameof(devBoxDefinitionName));

            using var scope = _devBoxDefinitionClientDiagnostics.CreateScope("DevBoxDefinitionCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _devBoxDefinitionRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, devBoxDefinitionName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<DevBoxDefinitionResource>(response.GetRawResponse());
                return Response.FromValue(new DevBoxDefinitionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<DevBoxDefinitionResource> IEnumerable<DevBoxDefinitionResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<DevBoxDefinitionResource> IAsyncEnumerable<DevBoxDefinitionResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
