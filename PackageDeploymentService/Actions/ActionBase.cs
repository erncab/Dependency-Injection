using System.Collections.Generic;

namespace PackageDeploymentService.Actions
{
    public abstract class ActionBase
    {
        protected virtual bool FileCanBeCopied(string shortFileName)
        {
            return true; 
        }

        public string SourceFolder { get; set; }
        public string TargetFolder { get; set; }
        public string Extension { get; set; }

        public List<string> FileNames = new List<string>();
        public List<string> FilesToInclude = new List<string>();
        public List<string> FilesToExclude = new List<string>();

        public abstract void Execute();
    }
}
