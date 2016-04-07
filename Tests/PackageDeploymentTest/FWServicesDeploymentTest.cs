using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PackageDeploymentService;

namespace PackageDeploymentTest
{
    [TestClass]
    public class FWServicesDeploymentTest
    {
        [TestMethod]
        public void create_fwservices_deployment_package()
        {
            var deploymentSettings = new DeploymentSettings
            {
                SourcePath = @"C:\Ernesto\Learning\IoC Containers, Dependency Injection\DeepDiveIntoDI\Source\Tests\PackageDeploymentTest\Source Files\",
                ZipFileName = "interface 5.5v",
                TargetPath = @"C:\Ernesto\Learning\IoC Containers, Dependency Injection\DeepDiveIntoDI\Source\Tests\PackageDeploymentTest\Deployment Folder\",
                FilesToExclude = new List<string>
                {
                    "file_01.dll"
                },
                ServiceClientPath = @"C:\Ernesto\Learning\IoC Containers, Dependency Injection\DeepDiveIntoDI\Source\Tests\PackageDeploymentTest\Source Files\bin\Release\",
                ExternalDependenciesPath = @"C:\Ernesto\Learning\IoC Containers, Dependency Injection\DeepDiveIntoDI\Source\Tests\PackageDeploymentTest\ExternalDependencies\",
                FilesToInclude = new List<string>
                {
                    "file_02.dll",
                    "file_03.dll"
                }
            };

            var deploymentService = new DeploymentService();

            deploymentService.CreateDeploymentPackage(deploymentSettings);

            deploymentService.UpdateExternalDependencies(deploymentSettings.ServiceClientPath, deploymentSettings.ExternalDependenciesPath, deploymentSettings.FilesToInclude);
        }
    }
}
