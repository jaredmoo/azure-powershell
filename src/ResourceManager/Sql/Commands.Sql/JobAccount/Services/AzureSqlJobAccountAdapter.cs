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
using Microsoft.Azure.Commands.Sql.Services;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

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
        /// <returns>The job account</returns>
        public AzureSqlJobAccountModel GetJobAccount(string resourceGroupName, string serverName, string jobAccountName)
        {
            var resp = Communicator.Get(resourceGroupName, serverName, jobAccountName, Util.GenerateTracingId());
            return CreateJobAccountModelFromResponse(resourceGroupName, serverName, resp);
        }

        /// <summary>
        /// Gets a list of all the servers in a resource group
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The server the job account is in</param>
        /// <returns>A list of all the job account</returns>
        public List<AzureSqlJobAccountModel> GetJobAccount(string resourceGroupName, string serverName)
        {
            var resp = Communicator.List(resourceGroupName, serverName, Util.GenerateTracingId());
            return resp.Select(s => CreateJobAccountModelFromResponse(resourceGroupName, serverName, s)).ToList();
        }

        /// <summary>
        /// Upserts a server
        /// </summary>
        /// <param name="model">The server to upsert</param>
        /// <returns>The updated server model</returns>
        public AzureSqlJobAccountModel UpsertJobAccount(AzureSqlJobAccountModel model)
        {
            // Construct database id
            string databaseId = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Sql/servers/{2}/databases/{3}",
                AzureSqlJobAccountCommunicator.Subscription.Id,
                model.ResourceGroupName,
                model.ServerName,
                model.DatabaseName);

            var resp = Communicator.CreateOrUpdate(model.ResourceGroupName, model.ServerName, model.JobAccountName, Util.GenerateTracingId(), new JobAccountCreateOrUpdateParameters
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
        public void RemoveJobAccount(string resourceGroupName, string serverName, string jobAccountName)
        {
            Communicator.Remove(resourceGroupName, serverName, jobAccountName, Util.GenerateTracingId());
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

            AzureSqlJobAccountModel jobAccount = new AzureSqlJobAccountModel();

            jobAccount.ResourceGroupName = resourceGroupName;
            jobAccount.ServerName = serverName;
            jobAccount.JobAccountName = resp.Name;
            jobAccount.Location = resp.Location;
            jobAccount.DatabaseName = databaseName;

            return jobAccount;
        }

        /// <summary>
        /// Convert a <see cref="System.Security.SecureString"/> to a plain-text string representation.
        /// This should only be used in a proetected context, and must be done in the same logon and process context
        /// in which the <see cref="System.Security.SecureString"/> was constructed.
        /// </summary>
        /// <param name="secureString">The encrypted <see cref="System.Security.SecureString"/>.</param>
        /// <returns>The plain-text string representation.</returns>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        internal static string Decrypt(SecureString secureString)
        {
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
