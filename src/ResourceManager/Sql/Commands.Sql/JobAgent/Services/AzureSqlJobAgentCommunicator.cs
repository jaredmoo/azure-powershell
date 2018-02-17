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
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Sql.JobAgent.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the audit REST endpoints
    /// </summary>
    public class AzureSqlJobAgentCommunicator
    {
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
        public AzureSqlJobAgentCommunicator(IAzureContext context)
        {
            Context = context;
            if (context.Subscription != Subscription)
            {
                Subscription = context.Subscription;
            }
        }

        /// <summary>
        /// Gets the Azure Sql Database SErver
        /// </summary>
        public Management.Sql.Models.JobAgent Get(string resourceGroupName, string serverName, string jobAgentName)
        {
            return GetCurrentSqlClient().JobAgents.Get(resourceGroupName, serverName, jobAgentName);
        }

        /// <summary>
        /// Lists Azure Sql Database Servers
        /// </summary>
        public IPage<Management.Sql.Models.JobAgent> List(string resourceGroupName, string serverName)
        {
            return GetCurrentSqlClient().JobAgents.ListByServer(resourceGroupName, serverName);
        }

        /// <summary>
        /// Creates or updates a Azure Sql Database SErver
        /// </summary>
        public Management.Sql.Models.JobAgent CreateOrUpdate(string resourceGroupName, string serverName, string jobAgentName, Management.Sql.Models.JobAgent parameters)
        {
            return GetCurrentSqlClient().JobAgents.CreateOrUpdate(resourceGroupName, serverName, jobAgentName, parameters);
        }

        /// <summary>
        /// Deletes a Azure Sql Database SErver
        /// </summary>
        public void Remove(string resourceGroupName, string serverName, string jobAgentName)
        {
            GetCurrentSqlClient().JobAgents.Delete(resourceGroupName, serverName, jobAgentName);
        }

        /// <summary>
        /// Retrieve the SQL Management client for the currently selected subscription, adding the session and request
        /// id tracing headers for the current cmdlet invocation.
        /// </summary>
        /// <returns>The SQL Management client for the currently selected subscription.</returns>
        private SqlManagementClient GetCurrentSqlClient()
        {
            // Get the SQL management client for the current subscription
            // Note: client is not cached in static field because that causes ObjectDisposedException in functional tests.
            var sqlClient = AzureSession.Instance.ClientFactory.CreateArmClient<Management.Sql.SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            return sqlClient;
        }
    }
}