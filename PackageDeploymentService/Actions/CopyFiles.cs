using System.IO;
using System.Text;

namespace PackageDeploymentService.Actions
{
    public class CopyFiles : ActionBase
    {
        protected override void ExecuteAction()
        {
            foreach (var fileInfo in FileInfoCollection)
            {
                if (!string.IsNullOrEmpty(fileInfo.TargetPath) && !Directory.Exists(fileInfo.TargetPath))
                {
                    Directory.CreateDirectory(fileInfo.TargetPath);
                }

                var fileNames = Directory.GetFiles(fileInfo.SourcePath, string.Format("*.{0}", fileInfo.Extension));

                foreach (var fileName in fileNames)
                {
                    var shortFileName = fileName.Replace(fileInfo.SourcePath, "");

                    if (fileInfo.FileShouldBeCopied(shortFileName))
                    {
                        File.Copy(string.Format("{0}{1}", fileInfo.SourcePath, shortFileName), string.Format("{0}{1}", fileInfo.TargetPath, shortFileName), true);
                    }
                }
            }
        }

        public override string Description
        {
            get
            {
                var sb = new StringBuilder("Copied files ...");

                sb.AppendLine(GetType().Name);

                return sb.ToString();
            }
        }
    }
}
