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

using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Sql.JobAgent.Cmdlet
{
    /// <summary>
    /// Defines the Get-AzureRmSqlJobAgent cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmSqlJobAgent",
        ConfirmImpact = ConfirmImpact.Low, SupportsShouldProcess = true)]
    public class NewAzureSqlJobAgent : AzureSqlJobAgentCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the database server to use.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "SQL Database server name.")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the job account to use.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "SQL Database job account name.")]
        [ValidateNotNullOrEmpty]
        public string JobAgentName { get; set; }

        /// <summary>
        /// Gets or sets the name of the database to use.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "SQL Database database name.")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        /// <summary>
        /// The tags to associate with the Azure Sql Database Server
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The tags to associate with the Azure Sql Job Account")]
        public Dictionary<string, string> Tags { get; set; }

        /// <summary>
        /// Check to see if the job account already exists in this resource group.
        /// </summary>
        /// <returns>Null if the job account doesn't exist. Otherwise throws exception</returns>
        protected override IEnumerable<Model.AzureSqlJobAgentModel> GetEntity()
        {
            try
            {
                WriteDebugWithTimestamp("JobAgentName: {0}", JobAgentName);
                ModelAdapter.GetJobAgent(this.ResourceGroupName, this.ServerName, this.JobAgentName);
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // This is what we want.  We looked and there is no job account with this name.
                    return null;
                }

                // Unexpected exception encountered
                throw;
            }

            // The job account already exists
            throw new PSArgumentException(
                string.Format(Properties.Resources.JobAgentNameExists, this.JobAgentName, this.ServerName),
                "JobAgentName");
        }

        /// <summary>
        /// Generates the model from user input.
        /// </summary>
        /// <param name="model">This is null since the server doesn't exist yet</param>
        /// <returns>The generated model from user input</returns>
        protected override IEnumerable<Model.AzureSqlJobAgentModel> ApplyUserInputToModel(IEnumerable<Model.AzureSqlJobAgentModel> model)
        {
            string location = ModelAdapter.GetServerLocationAndThrowIfJobAgentNotSupportedByServer(this.ResourceGroupName, this.ServerName);

            List<Model.AzureSqlJobAgentModel> newEntity = new List<Model.AzureSqlJobAgentModel>
            {
                new Model.AzureSqlJobAgentModel
                {
                    Location = location,
                    ResourceGroupName = this.ResourceGroupName,
                    ServerName = this.ServerName,
                    JobAgentName = this.JobAgentName,
                    DatabaseName = this.DatabaseName,
                    Tags = this.Tags
                }
            };
            return newEntity;
        }

        /// <summary>
        /// Sends the changes to the service -> Creates the job account
        /// </summary>
        /// <param name="entity">The job account to create</param>
        /// <returns>The created job account</returns>
        protected override IEnumerable<Model.AzureSqlJobAgentModel> PersistChanges(IEnumerable<Model.AzureSqlJobAgentModel> entity)
        {
            return new List<Model.AzureSqlJobAgentModel>
            {
                ModelAdapter.UpsertJobAgent(entity.First())
            };
        }
    }
}
