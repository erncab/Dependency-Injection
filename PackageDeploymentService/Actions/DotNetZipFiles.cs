using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ZipFile = Ionic.Zip.ZipFile;

namespace PackageDeploymentService.Actions
{
    /// <summary>
    /// http://dotnetzip.codeplex.com/wikipage?title=CS-Examples&referringTitle=Examples
    /// </summary>
    public class DotNetZipFiles : ActionBase
    {
        public string FileName { get; set; }
        public string TargetPath { get; set; }

        public override void Execute()
        {
            if (!string.IsNullOrEmpty(TargetPath) && !Directory.Exists(TargetPath))
            {
                Directory.CreateDirectory(TargetPath);
            }

            var zipFileFullName = string.Format(@"{0}{1}.zip", TargetPath, FileName);

            Buffer.AppendLine("");
            Buffer.AppendLine("Creating zip file ...");
            Buffer.AppendLine(string.Format("\t Name: {0}", zipFileFullName));

            if (File.Exists(zipFileFullName))
            {
                File.Delete(zipFileFullName);
            }

            using (var zip = new ZipFile())
            {
                AddDirectories(zip);

                AddFiles(zip);

                zip.Save(zipFileFullName);
            }
        }

        private void AddDirectories(ZipFile zip)
        {
            if (SourceFolders.Count > 0)
            {
                Buffer.AppendLine("");
                Buffer.AppendLine("Adding directories to zip ...");
            }

            foreach (var sourceFolder in SourceFolders)
            {
                Buffer.AppendLine(string.Format("\t Source: {0}", sourceFolder));

                zip.AddDirectory(sourceFolder, @"bin\");
            }
        }

        private void AddFiles(ZipFile zip)
        {
            foreach (var fileInfo in FileInfoCollection)
            {
                var fileNames = Directory.GetFiles(fileInfo.SourcePath, string.Format("*.{0}", fileInfo.Extension)).ToList();

                if (FilesShouldBeCopied(fileInfo, fileNames))
                {
                    Buffer.AppendLine("");
                    Buffer.AppendLine("Adding files to zip ...");
                }

                foreach (var fileName in fileNames)
                {
                    var shortFileName = fileName.Replace(fileInfo.SourcePath, "");

                    if (fileInfo.FileShouldBeCopied(shortFileName))
                    {
                        Buffer.AppendLine(string.Format("\t {0}", shortFileName));

                        // Add file to the zip root path
                        zip.AddFile(fileName, "");
                    }
                }
            }
        }

        private bool FilesShouldBeCopied(FileInfo fileInfo, IEnumerable<string> fileNames)
        {
            foreach (var fileName in fileNames)
            {
                var shortFileName = fileName.Replace(fileInfo.SourcePath, "");

                if (fileInfo.FileShouldBeCopied(shortFileName))
                {
                    return true;
                }
            }

            return false;
        }
    }
}