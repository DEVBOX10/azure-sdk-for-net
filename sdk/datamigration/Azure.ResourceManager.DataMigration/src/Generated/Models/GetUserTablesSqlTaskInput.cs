// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.ResourceManager.DataMigration.Models
{
    /// <summary> Input for the task that collects user tables for the given list of databases. </summary>
    public partial class GetUserTablesSqlTaskInput
    {
        /// <summary> Initializes a new instance of GetUserTablesSqlTaskInput. </summary>
        /// <param name="connectionInfo"> Connection information for SQL Server. </param>
        /// <param name="selectedDatabases"> List of database names to collect tables for. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionInfo"/> or <paramref name="selectedDatabases"/> is null. </exception>
        public GetUserTablesSqlTaskInput(SqlConnectionInfo connectionInfo, IEnumerable<string> selectedDatabases)
        {
            Argument.AssertNotNull(connectionInfo, nameof(connectionInfo));
            Argument.AssertNotNull(selectedDatabases, nameof(selectedDatabases));

            ConnectionInfo = connectionInfo;
            SelectedDatabases = selectedDatabases.ToList();
        }

        /// <summary> Initializes a new instance of GetUserTablesSqlTaskInput. </summary>
        /// <param name="connectionInfo"> Connection information for SQL Server. </param>
        /// <param name="selectedDatabases"> List of database names to collect tables for. </param>
        /// <param name="encryptedKeyForSecureFields"> encrypted key for secure fields. </param>
        internal GetUserTablesSqlTaskInput(SqlConnectionInfo connectionInfo, IList<string> selectedDatabases, string encryptedKeyForSecureFields)
        {
            ConnectionInfo = connectionInfo;
            SelectedDatabases = selectedDatabases;
            EncryptedKeyForSecureFields = encryptedKeyForSecureFields;
        }

        /// <summary> Connection information for SQL Server. </summary>
        public SqlConnectionInfo ConnectionInfo { get; set; }
        /// <summary> List of database names to collect tables for. </summary>
        public IList<string> SelectedDatabases { get; }
        /// <summary> encrypted key for secure fields. </summary>
        public string EncryptedKeyForSecureFields { get; set; }
    }
}
