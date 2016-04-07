using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PackageDeploymentService.Actions;

namespace PackageDeploymentTest.Tests
{
    [TestClass]
    public class CopyFilesActionTest
    {
        [TestMethod]
        public void CopyFilesAction()
        {
            // Arrange
            const string fwsDeploymentPath = @"C:\TFWServices Deployment";
            const string cicIntegrationPath = @"C:\FWS_CIC_InterfaceService Deployment\CIC Integration Deployment";
 
            var actions = new List<ActionBase>
            {
                new CopyFiles
                {
                    SourceFolder = string.Format(@"{0}\bin", fwsDeploymentPath),
                    TargetFolder = string.Format(@"{0}\bin", cicIntegrationPath),
                    FilesToExclude = new List<string>
                    {
                        "AutoMapper.dll",
                        "Oracle.DataAccess.dll"
                    },
                    Extension = "dll"
                },
                new CopyFilesByExtension
                {
                    SourceFolder = fwsDeploymentPath,
                    TargetFolder = cicIntegrationPath,
                    Extension = "svc"
                },
                new ZipFiles
                {
                    SourceFolder = cicIntegrationPath,
                    TargetFolder = cicIntegrationPath,
                    FileName = "interface v5.23",
                    Extension = "svc"
                }
            };

            // Act
            foreach (var action in actions)
            {
                action.Execute();
            }

            // Assert
            Assert.IsTrue(true);
        }
    }
}
