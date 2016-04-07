using System;
using System.IO;

namespace PackageDeploymentService.Actions
{
    public class CopyFilesByExtension : ActionBase
    {
        public override void Execute()
        {
            if (!Directory.Exists(TargetFolder))
            {
                Directory.CreateDirectory(TargetFolder);
            }

            var fileNames = Directory.GetFiles(SourceFolder, string.Format("*.{0}", Extension));

            foreach (var fileName in fileNames)
            {
                var shortFileName = fileName.Replace(SourceFolder, "");

                if (FileCanBeCopied(shortFileName))
                {
                    Console.WriteLine(fileName);

                    File.Copy(string.Format("{0}{1}", SourceFolder, shortFileName), string.Format("{0}{1}", TargetFolder, shortFileName), true);
                }
            }
        }

        protected override bool FileCanBeCopied(string shortFileName)
        {
            return Path.GetExtension(shortFileName) == string.Format(".{0}", Extension);
        }
    }
}