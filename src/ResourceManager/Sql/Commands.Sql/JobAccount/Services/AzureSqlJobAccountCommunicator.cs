// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Management.Sql.LegacySdk;
using Microsoft.Azure.Management.Sql.LegacySdk.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Sql.JobAccount.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the audit REST endpoints
    /// </summary>
    public class AzureSqlJobAccountCommunicator
    {
        /// <summary>
        /// The Sql client to be used by this end points communicator
        /// </summary>
        private static SqlManagementClient SqlClient { get; set; }

        /// <summary>
        /// Gets or set the Azure subscription
        /// </summary>
        internal static IAzureSubscription Subscription { get; private set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Creates a communicator for Azure Sql Job Accounts
        /// </summary>
        /// <param name="context">The context.</param>
        public AzureSqlJobAccountCommunicator(IAzureContext context)
        {
            Context = context;
            if (context.Subscription != Subscription)
            {
                Subscription = context.Subscription;
                SqlClient = null;
            }
        }

        /// <summary>
        /// Gets the Azure Sql Database SErver
        /// </summary>
        public Management.Sql.LegacySdk.Models.JobAccount Get(string resourceGroupName, string serverName, string jobAccountName, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).JobAccounts.Get(resourceGroupName, serverName, jobAccountName).JobAccount;
        }

        /// <summary>
        /// Lists Azure Sql Database Servers
        /// </summary>
        public IList<Management.Sql.LegacySdk.Models.JobAccount> List(string resourceGroupName, string serverName, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).JobAccounts.List(resourceGroupName, serverName).JobAccounts;
        }

        /// <summary>
        /// Creates or updates a Azure Sql Database SErver
        /// </summary>
        public Management.Sql.LegacySdk.Models.JobAccount CreateOrUpdate(string resourceGroupName, string serverName, string jobAccountName, string clientRequestId, JobAccountCreateOrUpdateParameters parameters)
        {
            return GetCurrentSqlClient(clientRequestId).JobAccounts.CreateOrUpdate(resourceGroupName, serverName, jobAccountName, parameters).JobAccount;
        }

        /// <summary>
        /// Deletes a Azure Sql Database SErver
        /// </summary>
        public void Remove(string resourceGroupName, string serverName, string jobAccountName, string clientRequestId)
        {
            GetCurrentSqlClient(clientRequestId).JobAccounts.Delete(resourceGroupName, serverName, jobAccountName);
        }

        /// <summary>
        /// Retrieve the SQL Management client for the currently selected subscription, adding the session and request
        /// id tracing headers for the current cmdlet invocation.
        /// </summary>
        /// <returns>The SQL Management client for the currently selected subscription.</returns>
        private SqlManagementClient GetCurrentSqlClient(String clientRequestId)
        {
            // Get the SQL management client for the current subscription
            if (SqlClient == null)
            {
                SqlClient = AzureSession.Instance.ClientFactory.CreateClient<SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            }
            SqlClient.HttpClient.DefaultRequestHeaders.Remove(Constants.ClientRequestIdHeaderName);
            SqlClient.HttpClient.DefaultRequestHeaders.Add(Constants.ClientRequestIdHeaderName, clientRequestId);
            return SqlClient;
        }
    }
}