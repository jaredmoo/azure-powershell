// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using AutoMapper;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    public partial class InvokeAzureComputeMethodCmdlet : ComputeAutomationBaseCmdlet
    {
        protected object CreateVirtualMachineScaleSetVMGetDynamicParameters()
        {
            dynamicParameters = new RuntimeDefinedParameterDictionary();
            var pResourceGroupName = new RuntimeDefinedParameter();
            pResourceGroupName.Name = "ResourceGroupName";
            pResourceGroupName.ParameterType = typeof(string);
            pResourceGroupName.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParameters",
                Position = 1,
                Mandatory = true
            });
            pResourceGroupName.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("ResourceGroupName", pResourceGroupName);

            var pVMScaleSetName = new RuntimeDefinedParameter();
            pVMScaleSetName.Name = "VMScaleSetName";
            pVMScaleSetName.ParameterType = typeof(string);
            pVMScaleSetName.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParameters",
                Position = 2,
                Mandatory = true
            });
            pVMScaleSetName.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("VMScaleSetName", pVMScaleSetName);

            var pInstanceId = new RuntimeDefinedParameter();
            pInstanceId.Name = "InstanceId";
            pInstanceId.ParameterType = typeof(string);
            pInstanceId.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParameters",
                Position = 3,
                Mandatory = true
            });
            pInstanceId.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("InstanceId", pInstanceId);

            var pArgumentList = new RuntimeDefinedParameter();
            pArgumentList.Name = "ArgumentList";
            pArgumentList.ParameterType = typeof(object[]);
            pArgumentList.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByStaticParameters",
                Position = 4,
                Mandatory = true
            });
            pArgumentList.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("ArgumentList", pArgumentList);

            return dynamicParameters;
        }

        protected void ExecuteVirtualMachineScaleSetVMGetMethod(object[] invokeMethodInputParameters)
        {
            string resourceGroupName = (string)ParseParameter(invokeMethodInputParameters[0]);
            string vmScaleSetName = (string)ParseParameter(invokeMethodInputParameters[1]);
            string instanceId = (string)ParseParameter(invokeMethodInputParameters[2]);

            if (!string.IsNullOrEmpty(resourceGroupName) && !string.IsNullOrEmpty(vmScaleSetName) && !string.IsNullOrEmpty(instanceId))
            {
                var result = VirtualMachineScaleSetVMsClient.Get(resourceGroupName, vmScaleSetName, instanceId);
                var psObject = new PSVirtualMachineScaleSetVM();
                Mapper.Map<VirtualMachineScaleSetVM, PSVirtualMachineScaleSetVM>(result, psObject);
                WriteObject(psObject);
            }
            else if (!string.IsNullOrEmpty(resourceGroupName) && !string.IsNullOrEmpty(vmScaleSetName))
            {
                var result = VirtualMachineScaleSetVMsClient.List(resourceGroupName, vmScaleSetName);
                var resultList = result.ToList();
                var nextPageLink = result.NextPageLink;
                while (!string.IsNullOrEmpty(nextPageLink))
                {
                    var pageResult = VirtualMachineScaleSetVMsClient.ListNext(nextPageLink);
                    foreach (var pageItem in pageResult)
                    {
                        resultList.Add(pageItem);
                    }
                    nextPageLink = pageResult.NextPageLink;
                }
                var psObject = new List<PSVirtualMachineScaleSetVMList>();
                foreach (var r in resultList)
                {
                    psObject.Add(Mapper.Map<VirtualMachineScaleSetVM, PSVirtualMachineScaleSetVMList>(r));
                }
                WriteObject(psObject);
            }
        }

    }

    public partial class NewAzureComputeArgumentListCmdlet : ComputeAutomationBaseCmdlet
    {
        protected PSArgument[] CreateVirtualMachineScaleSetVMGetParameters()
        {
            string resourceGroupName = string.Empty;
            string vmScaleSetName = string.Empty;
            string instanceId = string.Empty;

            return ConvertFromObjectsToArguments(
                 new string[] { "ResourceGroupName", "VMScaleSetName", "InstanceId" },
                 new object[] { resourceGroupName, vmScaleSetName, instanceId });
        }
    }

    [Cmdlet(VerbsCommon.Get, "AzureRmVmssVM", DefaultParameterSetName = "InvokeByDynamicParameters")]
    public partial class GetAzureRmVmssVM : InvokeAzureComputeMethodCmdlet
    {
        public override string MethodName { get; set; }

        protected override void ProcessRecord()
        {
            if (this.ParameterSetName == "InvokeByDynamicParameters")
            {
                this.MethodName = "VirtualMachineScaleSetVMGet";
            }
            else
            {
                this.MethodName = "VirtualMachineScaleSetVMGetInstanceView";
            }
            base.ProcessRecord();
        }

        public override object GetDynamicParameters()
        {
            dynamicParameters = new RuntimeDefinedParameterDictionary();
            var pResourceGroupName = new RuntimeDefinedParameter();
            pResourceGroupName.Name = "ResourceGroupName";
            pResourceGroupName.ParameterType = typeof(string);
            pResourceGroupName.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParameters",
                Position = 1,
                Mandatory = false,
                ValueFromPipelineByPropertyName = true,
                ValueFromPipeline = false
            });
            pResourceGroupName.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParametersForFriendMethod",
                Position = 1,
                Mandatory = false,
                ValueFromPipelineByPropertyName = true,
                ValueFromPipeline = false
            });
            pResourceGroupName.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("ResourceGroupName", pResourceGroupName);

            var pVMScaleSetName = new RuntimeDefinedParameter();
            pVMScaleSetName.Name = "VMScaleSetName";
            pVMScaleSetName.ParameterType = typeof(string);
            pVMScaleSetName.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParameters",
                Position = 2,
                Mandatory = false,
                ValueFromPipelineByPropertyName = true,
                ValueFromPipeline = false
            });
            pVMScaleSetName.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParametersForFriendMethod",
                Position = 2,
                Mandatory = false,
                ValueFromPipelineByPropertyName = true,
                ValueFromPipeline = false
            });
            pVMScaleSetName.Attributes.Add(new AliasAttribute("Name"));
            pVMScaleSetName.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("VMScaleSetName", pVMScaleSetName);

            var pInstanceId = new RuntimeDefinedParameter();
            pInstanceId.Name = "InstanceId";
            pInstanceId.ParameterType = typeof(string);
            pInstanceId.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParameters",
                Position = 3,
                Mandatory = false,
                ValueFromPipelineByPropertyName = true,
                ValueFromPipeline = false
            });
            pInstanceId.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParametersForFriendMethod",
                Position = 3,
                Mandatory = false,
                ValueFromPipelineByPropertyName = true,
                ValueFromPipeline = false
            });
            pInstanceId.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("InstanceId", pInstanceId);

            var pInstanceView = new RuntimeDefinedParameter();
            pInstanceView.Name = "InstanceView";
            pInstanceView.ParameterType = typeof(SwitchParameter);
            pInstanceView.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParametersForFriendMethod",
                Position = 4,
                Mandatory = true
            });
            pInstanceView.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("InstanceView", pInstanceView);

            return dynamicParameters;
        }
    }
}
