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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.JobAccount.Model;
using Microsoft.Azure.Commands.Sql.JobAccount.Services;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.Sql.Server.Services;

namespace Microsoft.Azure.Commands.Sql.JobAccount.Adapter
{
    /// <summary>
    /// Adapter for server operations
    /// </summary>
    public class AzureSqlJobAccountAdapter
    {
        /// <summary>
        /// Gets or sets the AzureEndpointsCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlJobAccountCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public AzureContext Context { get; set; }

        /// <summary>
        /// Constructs a server adapter
        /// </summary>
        /// <param name="context">The current azure profile</param>
        public AzureSqlJobAccountAdapter(AzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlJobAccountCommunicator(Context);
        }

        /// <summary>
        /// Gets a server in a resource group
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The server the job account is in</param>
        /// <param name="jobAccountName">Name of the job account.</param>
        /// <param name="clientId">The client identifier.</param>
        /// <returns>
        /// The job account
        /// </returns>
        public AzureSqlJobAccountModel GetJobAccount(string resourceGroupName, string serverName, string jobAccountName, string clientId)
        {
            var resp = Communicator.Get(resourceGroupName, serverName, jobAccountName, clientId);
            return CreateJobAccountModelFromResponse(resourceGroupName, serverName, resp);
        }

        /// <summary>
        /// Gets a list of all the servers in a resource group
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The server the job account is in</param>
        /// <param name="clientId">The client identifier.</param>
        /// <returns>
        /// A list of all the job account
        /// </returns>
        public List<AzureSqlJobAccountModel> GetJobAccount(string resourceGroupName, string serverName, string clientId)
        {
            var resp = Communicator.List(resourceGroupName, serverName, clientId);
            return resp.Select(s => CreateJobAccountModelFromResponse(resourceGroupName, serverName, s)).ToList();
        }

        /// <summary>
        /// Upserts a server
        /// </summary>
        /// <param name="model">The server to upsert</param>
        /// <param name="clientId">The client identifier.</param>
        /// <returns>
        /// The updated server model
        /// </returns>
        public AzureSqlJobAccountModel UpsertJobAccount(AzureSqlJobAccountModel model, string clientId)
        {
            // Construct database id
            string databaseId = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Sql/servers/{2}/databases/{3}",
                AzureSqlJobAccountCommunicator.Subscription.Id,
                model.ResourceGroupName,
                model.ServerName,
                model.DatabaseName);

            var resp = Communicator.CreateOrUpdate(model.ResourceGroupName, model.ServerName, model.JobAccountName, clientId, new JobAccountCreateOrUpdateParameters
            {
                Location = model.Location,
                Tags = model.Tags,
                Properties = new JobAccountCreateOrUpdateProperties
                {
                    DatabaseId = databaseId
                }
            });

            return CreateJobAccountModelFromResponse(model.ResourceGroupName, model.ServerName, resp);
        }

        /// <summary>
        /// Deletes a server
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="serverName">The server the job account is in</param>
        /// <param name="jobAccountName">Name of the job account to delete.</param>
        /// <param name="clientId">The client identifier.</param>
        public void RemoveJobAccount(string resourceGroupName, string serverName, string jobAccountName, string clientId)
        {
            Communicator.Remove(resourceGroupName, serverName, jobAccountName, clientId);
        }

        /// <summary>
        /// Convert a Management.Sql.Models.JobAccount to AzureSqlDatabaseServerModel
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="serverName">The server the job account is in</param>
        /// <param name="resp">The management client server response to convert</param>
        /// <returns>The converted job account model</returns>
        private static AzureSqlJobAccountModel CreateJobAccountModelFromResponse(string resourceGroupName, string serverName, Management.Sql.Models.JobAccount resp)
        {
            // Parse database name from database id
            // This is not expected to ever fail, but in case we have a bug here it's better to provide a more detailed error message
            int lastSlashIndex = resp.Properties.DatabaseId.LastIndexOf('/');
            string databaseName = resp.Properties.DatabaseId.Substring(lastSlashIndex + 1);

            AzureSqlJobAccountModel jobAccount = new AzureSqlJobAccountModel
            {
                ResourceGroupName = resourceGroupName,
                ServerName = serverName,
                JobAccountName = resp.Name,
                Location = resp.Location,
                DatabaseName = databaseName
            };

            return jobAccount;
        }

        /// <summary>
        /// Gets the Location of the server. Throws an exception if the server does not support job accounts.
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="clientId">The client identifier.</param>
        /// <returns></returns>
        /// <remarks>
        /// These 2 operations (get location, throw if not supported) are combined in order to minimize round trips.
        /// </remarks>
        public string GetServerLocationAndThrowIfJobAccountNotSupportedByServer(string resourceGroupName, string serverName, string clientId)
        {
            AzureSqlServerCommunicator serverCommunicator = new AzureSqlServerCommunicator(Context);
            var server = serverCommunicator.Get(resourceGroupName, serverName, clientId);

            ThrowIfJobAccountNotSupportedByServer(server);

            return server.Location;
        }

        /// <summary>
        /// Throws an exception if the server does not support job accounts.
        /// </summary>
        public void ThrowIfJobAccountNotSupportedByServer(string resourceGroupName, string serverName, string clientId)
        {
            AzureSqlServerCommunicator serverCommunicator = new AzureSqlServerCommunicator(Context);
            Management.Sql.Models.Server server = serverCommunicator.Get(resourceGroupName, serverName, clientId);
            ThrowIfJobAccountNotSupportedByServer(server);
        }

        /// <summary>
        /// Throws an exception if the server does not support job accounts.
        /// </summary>
        private static void ThrowIfJobAccountNotSupportedByServer(Management.Sql.Models.Server server)
        {
            if (server.Properties.Version != "12.0")
            {
                throw new InvalidOperationException(string.Format(Properties.Resources.ServerNotApplicableForJobAccount, server.Name));
            }
        }
    }
}
