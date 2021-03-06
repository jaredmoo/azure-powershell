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

using Microsoft.Azure;
using Microsoft.WindowsAzure.Commands.Compute.Automation.Models;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.Compute.Automation
{
    public abstract class ComputeAutomationBaseCmdlet : Microsoft.WindowsAzure.Commands.Utilities.Common.ServiceManagementBaseCmdlet
    {
        protected static PSArgument[] ConvertFromObjectsToArguments(string[] names, object[] objects)
        {
            var arguments = new PSArgument[objects.Length];
            
            for (int index = 0; index < objects.Length; index++)
            {
                arguments[index] = new PSArgument
                {
                    Name = names[index],
                    Type = objects[index].GetType(),
                    Value = objects[index]
                };
            }

            return arguments;
        }

        protected static object[] ConvertFromArgumentsToObjects(object[] arguments)
        {
            var objects = new object[arguments.Length];
            
            for (int index = 0; index < arguments.Length; index++)
            {
                if (arguments[index] is PSArgument)
                {
                    objects[index] = ((PSArgument)arguments[index]).Value;
                }
                else
                {
                    objects[index] = arguments[index];
                }
            }

            return objects;
        }

        public IDeploymentOperations DeploymentClient
        {
            get
            {
                return ComputeClient.Deployments;
            }
        }

        public IDNSServerOperations DNSServerClient
        {
            get
            {
                return ComputeClient.DnsServer;
            }
        }

        public IExtensionImageOperations ExtensionImageClient
        {
            get
            {
                return ComputeClient.ExtensionImages;
            }
        }

        public IHostedServiceOperations HostedServiceClient
        {
            get
            {
                return ComputeClient.HostedServices;
            }
        }

        public ILoadBalancerOperations LoadBalancerClient
        {
            get
            {
                return ComputeClient.LoadBalancers;
            }
        }

        public IOperatingSystemOperations OperatingSystemClient
        {
            get
            {
                return ComputeClient.OperatingSystems;
            }
        }

        public IServiceCertificateOperations ServiceCertificateClient
        {
            get
            {
                return ComputeClient.ServiceCertificates;
            }
        }

        public IVirtualMachineDiskOperations VirtualMachineDiskClient
        {
            get
            {
                return ComputeClient.VirtualMachineDisks;
            }
        }

        public IVirtualMachineExtensionOperations VirtualMachineExtensionClient
        {
            get
            {
                return ComputeClient.VirtualMachineExtensions;
            }
        }

        public IVirtualMachineOperations VirtualMachineClient
        {
            get
            {
                return ComputeClient.VirtualMachines;
            }
        }

        public IVirtualMachineOSImageOperations VirtualMachineOSImageClient
        {
            get
            {
                return ComputeClient.VirtualMachineOSImages;
            }
        }

        public IVirtualMachineVMImageOperations VirtualMachineVMImageClient
        {
            get
            {
                return ComputeClient.VirtualMachineVMImages;
            }
        }
    }
}
