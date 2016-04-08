using System.Collections.Generic;

namespace PackageDeploymentService.Actions
{
    public abstract class ActionBase
    {
        public List<string> SourceFolders { get; set; }
        public List<FileInfo> FileInfoCollection { get; set; }

        protected virtual bool FileCanBeCopied(string shortFileName)
        {
            return true; 
        }

        public abstract string Description { get; }

        public virtual void Execute()
        {
            ExecuteAction();
        }

        protected abstract void ExecuteAction();
    }
}
