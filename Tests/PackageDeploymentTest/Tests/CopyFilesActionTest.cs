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
            var actions = new List<ActionBase>
            {
                new CopyFiles
                {
                    SourceFolder = @"C:\TFWServices Deployment\bin\",
                    TargetFolder = @"C:\FWS_CIC_InterfaceService Deployment\CIC Integration Deployment\bin\AAAAA\",
                    FilesToExclude = new List<string>
                    {
                        "AutoMapper.dll",
                        "Oracle.DataAccess.dll"
                    },
                    Extension = "dll"
                },
                new CopyFilesByExtension
                {
                    SourceFolder = @"C:\TFWServices Deployment\",
                    TargetFolder = @"C:\FWS_CIC_InterfaceService Deployment\CIC Integration Deployment\bin\AAAAA\",
                    Extension = "svc"
                },
                new ZipFiles
                {
                    SourceFolder = @"C:\FWS_CIC_InterfaceService Deployment\CIC Integration Deployment\bin\AAAAA\",
                    TargetFolder = @"C:\FWS_CIC_InterfaceService Deployment\CIC Integration Deployment\bin\BBBBB\",
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
