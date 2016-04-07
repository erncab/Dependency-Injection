using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PackageDeploymentService;

namespace PackageDeploymentTest.Tests
{
    [TestClass]
    public class FWServicesDeploymentTest
    {
        [TestMethod]
        public void create_fwservices_deployment_package()
        {
            var deploymentSettings = new DeploymentSettings
            {
                SourcePath = @"C:\TFWServices Deployment\bin\",
                ZipFileName = "interface v5.23",
                TargetPath = @"C:\Ernesto\Learning\IoC Containers, Dependency Injection\DeepDiveIntoDI\Source\Tests\PackageDeploymentTest\Deployment Folder\",
                FilesToExclude = new List<string>
                {
                    "file_01.dll"
                }
            };

            var externalDependenciesSettings = new ExternalDependenciesSettings
            {
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

            deploymentService.UpdateExternalDependencies(externalDependenciesSettings.ServiceClientPath, externalDependenciesSettings.ExternalDependenciesPath, deploymentSettings.FilesToInclude);
        }
    }
}
