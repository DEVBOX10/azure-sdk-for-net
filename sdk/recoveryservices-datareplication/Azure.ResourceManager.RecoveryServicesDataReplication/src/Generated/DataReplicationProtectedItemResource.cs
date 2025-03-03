// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.RecoveryServicesDataReplication.Models;

namespace Azure.ResourceManager.RecoveryServicesDataReplication
{
    /// <summary>
    /// A Class representing a DataReplicationProtectedItem along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="DataReplicationProtectedItemResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetDataReplicationProtectedItemResource method.
    /// Otherwise you can get one from its parent resource <see cref="DataReplicationVaultResource" /> using the GetDataReplicationProtectedItem method.
    /// </summary>
    public partial class DataReplicationProtectedItemResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="DataReplicationProtectedItemResource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="vaultName"> The vaultName. </param>
        /// <param name="protectedItemName"> The protectedItemName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string protectedItemName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataReplication/replicationVaults/{vaultName}/protectedItems/{protectedItemName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _dataReplicationProtectedItemProtectedItemClientDiagnostics;
        private readonly ProtectedItemRestOperations _dataReplicationProtectedItemProtectedItemRestClient;
        private readonly DataReplicationProtectedItemData _data;

        /// <summary> Initializes a new instance of the <see cref="DataReplicationProtectedItemResource"/> class for mocking. </summary>
        protected DataReplicationProtectedItemResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "DataReplicationProtectedItemResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal DataReplicationProtectedItemResource(ArmClient client, DataReplicationProtectedItemData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="DataReplicationProtectedItemResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal DataReplicationProtectedItemResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _dataReplicationProtectedItemProtectedItemClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.RecoveryServicesDataReplication", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string dataReplicationProtectedItemProtectedItemApiVersion);
            _dataReplicationProtectedItemProtectedItemRestClient = new ProtectedItemRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, dataReplicationProtectedItemProtectedItemApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.DataReplication/replicationVaults/protectedItems";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual DataReplicationProtectedItemData Data
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

        /// <summary> Gets a collection of DataReplicationRecoveryPointResources in the DataReplicationProtectedItem. </summary>
        /// <returns> An object representing collection of DataReplicationRecoveryPointResources and their operations over a DataReplicationRecoveryPointResource. </returns>
        public virtual DataReplicationRecoveryPointCollection GetDataReplicationRecoveryPoints()
        {
            return GetCachedClient(Client => new DataReplicationRecoveryPointCollection(Client, Id));
        }

        /// <summary>
        /// Gets the details of the recovery point of a protected item.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataReplication/replicationVaults/{vaultName}/protectedItems/{protectedItemName}/recoveryPoints/{recoveryPointName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecoveryPoints_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="recoveryPointName"> The recovery point name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="recoveryPointName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="recoveryPointName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<DataReplicationRecoveryPointResource>> GetDataReplicationRecoveryPointAsync(string recoveryPointName, CancellationToken cancellationToken = default)
        {
            return await GetDataReplicationRecoveryPoints().GetAsync(recoveryPointName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the details of the recovery point of a protected item.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataReplication/replicationVaults/{vaultName}/protectedItems/{protectedItemName}/recoveryPoints/{recoveryPointName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecoveryPoints_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="recoveryPointName"> The recovery point name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="recoveryPointName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="recoveryPointName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<DataReplicationRecoveryPointResource> GetDataReplicationRecoveryPoint(string recoveryPointName, CancellationToken cancellationToken = default)
        {
            return GetDataReplicationRecoveryPoints().Get(recoveryPointName, cancellationToken);
        }

        /// <summary>
        /// Gets the details of the protected item.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataReplication/replicationVaults/{vaultName}/protectedItems/{protectedItemName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProtectedItem_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DataReplicationProtectedItemResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _dataReplicationProtectedItemProtectedItemClientDiagnostics.CreateScope("DataReplicationProtectedItemResource.Get");
            scope.Start();
            try
            {
                var response = await _dataReplicationProtectedItemProtectedItemRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DataReplicationProtectedItemResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the details of the protected item.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataReplication/replicationVaults/{vaultName}/protectedItems/{protectedItemName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProtectedItem_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DataReplicationProtectedItemResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _dataReplicationProtectedItemProtectedItemClientDiagnostics.CreateScope("DataReplicationProtectedItemResource.Get");
            scope.Start();
            try
            {
                var response = _dataReplicationProtectedItemProtectedItemRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DataReplicationProtectedItemResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes the protected item.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataReplication/replicationVaults/{vaultName}/protectedItems/{protectedItemName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProtectedItem_Delete</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="forceDelete"> A flag indicating whether to do force delete or not. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, bool? forceDelete = null, CancellationToken cancellationToken = default)
        {
            using var scope = _dataReplicationProtectedItemProtectedItemClientDiagnostics.CreateScope("DataReplicationProtectedItemResource.Delete");
            scope.Start();
            try
            {
                var response = await _dataReplicationProtectedItemProtectedItemRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, forceDelete, cancellationToken).ConfigureAwait(false);
                var operation = new RecoveryServicesDataReplicationArmOperation(_dataReplicationProtectedItemProtectedItemClientDiagnostics, Pipeline, _dataReplicationProtectedItemProtectedItemRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, forceDelete).Request, response, OperationFinalStateVia.Location);
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
        /// Removes the protected item.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataReplication/replicationVaults/{vaultName}/protectedItems/{protectedItemName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProtectedItem_Delete</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="forceDelete"> A flag indicating whether to do force delete or not. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, bool? forceDelete = null, CancellationToken cancellationToken = default)
        {
            using var scope = _dataReplicationProtectedItemProtectedItemClientDiagnostics.CreateScope("DataReplicationProtectedItemResource.Delete");
            scope.Start();
            try
            {
                var response = _dataReplicationProtectedItemProtectedItemRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, forceDelete, cancellationToken);
                var operation = new RecoveryServicesDataReplicationArmOperation(_dataReplicationProtectedItemProtectedItemClientDiagnostics, Pipeline, _dataReplicationProtectedItemProtectedItemRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, forceDelete).Request, response, OperationFinalStateVia.Location);
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
        /// Creates the protected item.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataReplication/replicationVaults/{vaultName}/protectedItems/{protectedItemName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProtectedItem_Create</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> Protected item model. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<DataReplicationProtectedItemResource>> UpdateAsync(WaitUntil waitUntil, DataReplicationProtectedItemData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _dataReplicationProtectedItemProtectedItemClientDiagnostics.CreateScope("DataReplicationProtectedItemResource.Update");
            scope.Start();
            try
            {
                var response = await _dataReplicationProtectedItemProtectedItemRestClient.CreateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, data, cancellationToken).ConfigureAwait(false);
                var operation = new RecoveryServicesDataReplicationArmOperation<DataReplicationProtectedItemResource>(new DataReplicationProtectedItemOperationSource(Client), _dataReplicationProtectedItemProtectedItemClientDiagnostics, Pipeline, _dataReplicationProtectedItemProtectedItemRestClient.CreateCreateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, data).Request, response, OperationFinalStateVia.Location);
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
        /// Creates the protected item.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataReplication/replicationVaults/{vaultName}/protectedItems/{protectedItemName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProtectedItem_Create</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> Protected item model. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<DataReplicationProtectedItemResource> Update(WaitUntil waitUntil, DataReplicationProtectedItemData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _dataReplicationProtectedItemProtectedItemClientDiagnostics.CreateScope("DataReplicationProtectedItemResource.Update");
            scope.Start();
            try
            {
                var response = _dataReplicationProtectedItemProtectedItemRestClient.Create(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, data, cancellationToken);
                var operation = new RecoveryServicesDataReplicationArmOperation<DataReplicationProtectedItemResource>(new DataReplicationProtectedItemOperationSource(Client), _dataReplicationProtectedItemProtectedItemClientDiagnostics, Pipeline, _dataReplicationProtectedItemProtectedItemRestClient.CreateCreateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, data).Request, response, OperationFinalStateVia.Location);
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
        /// Performs the planned failover on the protected item.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataReplication/replicationVaults/{vaultName}/protectedItems/{protectedItemName}/plannedFailover</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProtectedItem_PlannedFailover</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="body"> Planned failover model. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation<PlannedFailoverModel>> PlannedFailoverAsync(WaitUntil waitUntil, PlannedFailoverModel body = null, CancellationToken cancellationToken = default)
        {
            using var scope = _dataReplicationProtectedItemProtectedItemClientDiagnostics.CreateScope("DataReplicationProtectedItemResource.PlannedFailover");
            scope.Start();
            try
            {
                var response = await _dataReplicationProtectedItemProtectedItemRestClient.PlannedFailoverAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, body, cancellationToken).ConfigureAwait(false);
                var operation = new RecoveryServicesDataReplicationArmOperation<PlannedFailoverModel>(new PlannedFailoverModelOperationSource(), _dataReplicationProtectedItemProtectedItemClientDiagnostics, Pipeline, _dataReplicationProtectedItemProtectedItemRestClient.CreatePlannedFailoverRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, body).Request, response, OperationFinalStateVia.Location);
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
        /// Performs the planned failover on the protected item.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataReplication/replicationVaults/{vaultName}/protectedItems/{protectedItemName}/plannedFailover</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProtectedItem_PlannedFailover</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="body"> Planned failover model. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<PlannedFailoverModel> PlannedFailover(WaitUntil waitUntil, PlannedFailoverModel body = null, CancellationToken cancellationToken = default)
        {
            using var scope = _dataReplicationProtectedItemProtectedItemClientDiagnostics.CreateScope("DataReplicationProtectedItemResource.PlannedFailover");
            scope.Start();
            try
            {
                var response = _dataReplicationProtectedItemProtectedItemRestClient.PlannedFailover(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, body, cancellationToken);
                var operation = new RecoveryServicesDataReplicationArmOperation<PlannedFailoverModel>(new PlannedFailoverModelOperationSource(), _dataReplicationProtectedItemProtectedItemClientDiagnostics, Pipeline, _dataReplicationProtectedItemProtectedItemRestClient.CreatePlannedFailoverRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, body).Request, response, OperationFinalStateVia.Location);
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
