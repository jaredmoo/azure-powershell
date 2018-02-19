﻿// ----------------------------------------------------------------------------------
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
using System.Globalization;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.JobAgent.Cmdlet
{
    /// <summary>
    /// Defines the Remove-AzureRmSqlJobAgent cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmSqlJobAgent",
        SupportsShouldProcess = true,
        ConfirmImpact = ConfirmImpact.High)]
    public class RemoveAzureSqlJobAgent : AzureSqlJobAgentCmdletBase
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
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "SQL Database job account name.")]
        [ValidateNotNullOrEmpty]
        public string JobAgentName { get; set; }

        /// <summary>
        /// Defines whether it is ok to skip the requesting of rule removal confirmation
        /// </summary>
        [Parameter(HelpMessage = "Skip confirmation message for performing the action")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Gets the entity to delete
        /// </summary>
        /// <returns>The entity going to be deleted</returns>
        protected override IEnumerable<Model.AzureSqlJobAgentModel> GetEntity()
        {
            return new List<Model.AzureSqlJobAgentModel>
            {
                ModelAdapter.GetJobAgent(this.ResourceGroupName, this.ServerName, this.JobAgentName)
            };
        }

        /// <summary>
        /// Apply user input.  Here nothing to apply
        /// </summary>
        /// <param name="model">The result of GetEntity</param>
        /// <returns>The input model</returns>
        protected override IEnumerable<Model.AzureSqlJobAgentModel> ApplyUserInputToModel(IEnumerable<Model.AzureSqlJobAgentModel> model)
        {
            return model;
        }

        /// <summary>
        /// Deletes the job account.
        /// </summary>
        /// <param name="entity">The job account being deleted</param>
        /// <returns>The job account that was deleted</returns>
        protected override IEnumerable<Model.AzureSqlJobAgentModel> PersistChanges(IEnumerable<Model.AzureSqlJobAgentModel> entity)
        {
            ModelAdapter.RemoveJobAgent(this.ResourceGroupName, this.ServerName, this.JobAgentName);
            return entity;
        }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (!Force.IsPresent && !ShouldProcess(
               string.Format(CultureInfo.InvariantCulture, Properties.Resources.RemoveAzureSqlJobAgentDescription, this.JobAgentName, this.ServerName),
               string.Format(CultureInfo.InvariantCulture, Properties.Resources.RemoveAzureSqlJobAgentWarning, this.JobAgentName, this.ServerName),
               Properties.Resources.ShouldProcessCaption))
            {
                return;
            }

            base.ExecuteCmdlet();
        }
    }
}
