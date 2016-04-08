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

        protected override void ExecuteAction()
        {
            if (!string.IsNullOrEmpty(TargetPath) && !Directory.Exists(TargetPath))
            {
                Directory.CreateDirectory(TargetPath);
            }

            var zipFileFullName = string.Format(@"{0}{1}.zip", TargetPath, FileName);

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
            foreach (var sourceFolder in SourceFolders)
            {
                zip.AddDirectory(sourceFolder, @"bin\");
            }
        }

        private void AddFiles(ZipFile zip)
        {
            foreach (var fileInfo in FileInfoCollection)
            {
                var fileNames = Directory.GetFiles(fileInfo.SourcePath, string.Format("*.{0}", fileInfo.Extension)).ToList();

                foreach (var fileName in fileNames)
                {
                    var shortFileName = fileName.Replace(fileInfo.SourcePath, "");

                    if (fileInfo.FileShouldBeCopied(shortFileName))
                    {
                        // Add file to the zip root path
                        zip.AddFile(fileName, "");
                    }
                }
            }
        }

        public override string Description
        {
            get
            {
                var sb = new StringBuilder("Zipped files");

                sb.AppendLine(GetType().Name);

                return sb.ToString();
            }
        }
    }
}