using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PackageDeploymentService.Actions;

namespace PackageDeploymentTest.Tests
{
    [TestClass]
    public class CopyFilesActionTest
    {
        [TestMethod]
        public void CICPackageDeploymentTest()
        {
            // Arrange
            const string fwsDeploymentPath = @"C:\TFWServices Deployment\";
            const string cicIntegrationPath = @"C:\FWS_CIC_InterfaceService Deployment\CIC Integration Deployment\";

            var actions = new CompositeAction
            {
                new CopyFiles
                {
                    FileInfoCollection = new List<FileInfo>
                    {
                        new FileInfo
                        {
                            SourcePath = string.Format(@"{0}bin\", fwsDeploymentPath),
                            TargetPath = string.Format(@"{0}bin\", cicIntegrationPath),
                            Extension = "dll",
                            FilesToExclude = new List<string>
                            {
                                "AutoMapper.dll",
                                "Oracle.DataAccess.dll"
                            }
                        },
                        new FileInfo
                        {
                            SourcePath = fwsDeploymentPath,
                            TargetPath = cicIntegrationPath,
                            Extension = "svc"
                        }
                    }
                },
                new DotNetZipFiles
                {
                    FileName = "interface v5.23",
                    TargetPath = cicIntegrationPath,
                    SourceFolders = new List<string>
                    {
                        string.Format(@"{0}bin\", cicIntegrationPath)
                    },
                    FileInfoCollection = new List<FileInfo>
                    {
                        new FileInfo
                        {
                            SourcePath = cicIntegrationPath, 
                            Extension = "svc"
                        }
                    }
                }
            };

            // Act
            actions.Execute();

            Console.WriteLine(actions.Description);

            // Assert
            Assert.IsTrue(true);
        }
    }
}
