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

using Microsoft.Azure.Commands.Sql.JobAgent.Model;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.JobAgent.Cmdlet
{
    /// <summary>
    /// Defines the Get-AzureRmSqlJobAgent cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmSqlJobAgent", ConfirmImpact = ConfirmImpact.None)]
    public class GetAzureSqlJobAgent : AzureSqlJobAgentCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the database server to use.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "SQL Database server name.")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the job account to use.
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "SQL Database job account name.")]
        [ValidateNotNullOrEmpty]
        public string JobAgentName { get; set; }

        /// <summary>
        /// Gets one or more job accounts from the service.
        /// </summary>
        /// <returns>A single server</returns>
        protected override IEnumerable<AzureSqlJobAgentModel> GetEntity()
        {
            if (this.MyInvocation.BoundParameters.ContainsKey("JobAgentName"))
            {
                return new List<AzureSqlJobAgentModel>
                {
                    ModelAdapter.GetJobAgent(this.ResourceGroupName, this.ServerName, this.JobAgentName)
                };
            }
            else
            {
                return ModelAdapter.GetJobAgent(this.ResourceGroupName, this.ServerName);
            }
        }

        /// <summary>
        /// No changes, thus nothing to persist.
        /// </summary>
        /// <param name="entity">The entity retrieved</param>
        /// <returns>The unchanged entity</returns>
        protected override IEnumerable<AzureSqlJobAgentModel> PersistChanges(IEnumerable<AzureSqlJobAgentModel> entity)
        {
            return entity;
        }

        /// <summary>
        /// No user input to apply to model.
        /// </summary>
        /// <param name="model">The model to modify</param>
        /// <returns>The input model</returns>
        protected override IEnumerable<AzureSqlJobAgentModel> ApplyUserInputToModel(IEnumerable<AzureSqlJobAgentModel> model)
        {
            return model;
        }
    }
}
