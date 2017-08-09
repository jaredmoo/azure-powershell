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
using System.Globalization;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.JobAccount.Cmdlet
{
    /// <summary>
    /// Defines the Remove-AzureRmSqlJobAccount cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmSqlJobAccount",
        SupportsShouldProcess = true,
        ConfirmImpact = ConfirmImpact.High)]
    public class RemoveAzureSqlJobAccount : AzureSqlJobAccountCmdletBase
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
        public string JobAccountName { get; set; }

        /// <summary>
        /// Defines whether it is ok to skip the requesting of rule removal confirmation
        /// </summary>
        [Parameter(HelpMessage = "Skip confirmation message for performing the action")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Gets the entity to delete
        /// </summary>
        /// <returns>The entity going to be deleted</returns>
        protected override IEnumerable<Model.AzureSqlJobAccountModel> GetEntity()
        {
            return new List<Model.AzureSqlJobAccountModel>
            {
                ModelAdapter.GetJobAccount(this.ResourceGroupName, this.ServerName, this.JobAccountName)
            };
        }

        /// <summary>
        /// Apply user input.  Here nothing to apply
        /// </summary>
        /// <param name="model">The result of GetEntity</param>
        /// <returns>The input model</returns>
        protected override IEnumerable<Model.AzureSqlJobAccountModel> ApplyUserInputToModel(IEnumerable<Model.AzureSqlJobAccountModel> model)
        {
            return model;
        }

        /// <summary>
        /// Deletes the job account.
        /// </summary>
        /// <param name="entity">The job account being deleted</param>
        /// <returns>The job account that was deleted</returns>
        protected override IEnumerable<Model.AzureSqlJobAccountModel> PersistChanges(IEnumerable<Model.AzureSqlJobAccountModel> entity)
        {
            ModelAdapter.RemoveJobAccount(this.ResourceGroupName, this.ServerName, this.JobAccountName);
            return entity;
        }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (!Force.IsPresent && !ShouldProcess(
               string.Format(CultureInfo.InvariantCulture, Properties.Resources.RemoveAzureSqlJobAccountDescription, this.JobAccountName, this.ServerName),
               string.Format(CultureInfo.InvariantCulture, Properties.Resources.RemoveAzureSqlJobAccountWarning, this.JobAccountName, this.ServerName),
               Properties.Resources.ShouldProcessCaption))
            {
                return;
            }

            base.ExecuteCmdlet();
        }
    }
}
