using System.IO;

namespace PackageDeploymentService.Actions
{
    public class CopyFiles : ActionBase
    {
        public override void Execute()
        {
            foreach (var fileInfo in FileInfoCollection)
            {
                Buffer.AppendLine("");
                Buffer.AppendLine("Copying files ...");
                Buffer.AppendLine(string.Format("\t Source: {0}", fileInfo.SourcePath));
                Buffer.AppendLine(string.Format("\t Target: {0}", fileInfo.TargetPath));

                if (!string.IsNullOrEmpty(fileInfo.TargetPath) && !Directory.Exists(fileInfo.TargetPath))
                {
                    Directory.CreateDirectory(fileInfo.TargetPath);

                    Buffer.AppendLine(string.Format("Created folder: {0}", fileInfo.TargetPath));
                }

                var fileNames = Directory.GetFiles(fileInfo.SourcePath, string.Format("*.{0}", fileInfo.Extension));

                foreach (var fileName in fileNames)
                {
                    var shortFileName = fileName.Replace(fileInfo.SourcePath, "");

                    if (fileInfo.FileShouldBeCopied(shortFileName))
                    {
                        File.Copy(string.Format("{0}{1}", fileInfo.SourcePath, shortFileName), string.Format("{0}{1}", fileInfo.TargetPath, shortFileName), true);

                        Buffer.AppendLine(string.Format("\t {0}", shortFileName));
                    }
                }
            }
        }
    }
}
