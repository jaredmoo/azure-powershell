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

using Microsoft.Azure.Commands.Sql.JobAccount.Model;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.JobAccount.Cmdlet
{
    /// <summary>
    /// Defines the Get-AzureRmSqlJobAccount cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmSqlJobAccount", ConfirmImpact = ConfirmImpact.None)]
    public class GetAzureSqlJobAccount : AzureSqlJobAccountCmdletBase
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
        public string JobAccountName { get; set; }

        /// <summary>
        /// Gets one or more job accounts from the service.
        /// </summary>
        /// <returns>A single server</returns>
        protected override IEnumerable<AzureSqlJobAccountModel> GetEntity()
        {
            ModelAdapter.ThrowIfJobAccountNotSupportedByServer(this.ResourceGroupName, this.ServerName, this.clientRequestId);

            if (this.MyInvocation.BoundParameters.ContainsKey("JobAccountName"))
            {
                return new List<AzureSqlJobAccountModel>
                {
                    ModelAdapter.GetJobAccount(this.ResourceGroupName, this.ServerName, this.JobAccountName, this.clientRequestId)
                };
            }
            else
            {
                return ModelAdapter.GetJobAccount(this.ResourceGroupName, this.ServerName, this.clientRequestId);
            }
        }

        /// <summary>
        /// No changes, thus nothing to persist.
        /// </summary>
        /// <param name="entity">The entity retrieved</param>
        /// <returns>The unchanged entity</returns>
        protected override IEnumerable<AzureSqlJobAccountModel> PersistChanges(IEnumerable<AzureSqlJobAccountModel> entity)
        {
            return entity;
        }

        /// <summary>
        /// No user input to apply to model.
        /// </summary>
        /// <param name="model">The model to modify</param>
        /// <returns>The input model</returns>
        protected override IEnumerable<AzureSqlJobAccountModel> ApplyUserInputToModel(IEnumerable<AzureSqlJobAccountModel> model)
        {
            return model;
        }
    }
}
