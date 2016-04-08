using System.Collections.Generic;
using System.IO;

namespace PackageDeploymentService.Actions
{
    public class FileInfo
    {
        public string SourcePath { get; set; }
        public string TargetPath { get; set; }

        public string Extension = "*";
        public List<string> FilesToInclude = new List<string>();
        public List<string> FilesToExclude = new List<string>();

        public bool FileShouldBeCopied(string shortFileName)
        {
            if (FilesToInclude.Count > 0 && !FilesToInclude.Contains(shortFileName))
            {
                return false;
            }

            if (FilesToExclude.Count > 0 && FilesToExclude.Contains(shortFileName))
            {
                return false;
            }

            if (Extension != "*" && Path.GetExtension(shortFileName) != string.Format(".{0}", Extension))
            {
                return false;
            }

            return true;
        }
    }
}