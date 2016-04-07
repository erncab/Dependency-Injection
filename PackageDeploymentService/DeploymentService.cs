using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace PackageDeploymentService
{
    public class DeploymentService
    {
        public void CreateDeploymentPackage(DeploymentSettings deploymentSettings)
        {
            if (!Directory.Exists(deploymentSettings.TargetPath))
            {
                Directory.CreateDirectory(deploymentSettings.TargetPath);
            }

            using (var memoryStream = new MemoryStream())
            {
                var zipFile = string.Format("{0}{1}.zip", deploymentSettings.TargetPath, deploymentSettings.ZipFileName);

                using (var zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    var pathToReplace = string.Format(@"{0}bin\Release\", deploymentSettings.SourcePath);
                    var fileNames = Directory.GetFiles(pathToReplace, "*.dll");
                    CreateZipEntriesFromFiles(fileNames, zipArchive, deploymentSettings, pathToReplace);

                    pathToReplace = string.Format(@"{0}", deploymentSettings.SourcePath);
                    fileNames = Directory.GetFiles(pathToReplace, "*.svc");

                    CreateZipEntriesFromFiles(fileNames, zipArchive, deploymentSettings, pathToReplace);
                }

                using (var fileStream = new FileStream(zipFile, FileMode.Create))
                {
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    memoryStream.CopyTo(fileStream);
                }
            }
        }

        public void UpdateExternalDependencies(string sourceFileName, string destFileName, List<string> filesToInclude)
        {
            if (!Directory.Exists(destFileName))
            {
                Directory.CreateDirectory(destFileName);
            }

            var fileNames = Directory.GetFiles(sourceFileName, "*.dll");

            foreach (var fileName in fileNames)
            {
                var shortFileName = fileName.Replace(sourceFileName, "");

                if (filesToInclude.Contains(shortFileName))
                {
                    Console.WriteLine(fileName);

                    File.Copy(string.Format("{0}{1}", sourceFileName, shortFileName), string.Format("{0}{1}", destFileName, shortFileName), true);
                }
            }
        }

        public void UpdateExternalDependencies(ExternalDependenciesSettings externalDependenciesSettings)
        {
            throw new NotImplementedException();
        }

        private static void CreateZipEntriesFromFiles(IEnumerable<string> fileNames, ZipArchive zipArchive, DeploymentSettings deploymentSettings, string path)
        {
            foreach (var fileName in fileNames)
            {
                var shortFileName = fileName.Replace(path, "");

                if (!deploymentSettings.FilesToExclude.Contains(shortFileName))
                {
                    Console.WriteLine(fileName);

                    zipArchive.CreateEntryFromFile(fileName, fileName.Replace(deploymentSettings.SourcePath, ""));
                }
            }
        }
    }
}
