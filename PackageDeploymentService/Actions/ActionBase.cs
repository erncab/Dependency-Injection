using System.Collections.Generic;
using System.Text;

namespace PackageDeploymentService.Actions
{
    public abstract class ActionBase
    {
        public List<string> SourceFolders { get; set; }
        public List<FileInfo> FileInfoCollection { get; set; }

        public StringBuilder Buffer = new StringBuilder();

        protected virtual bool FileCanBeCopied(string shortFileName)
        {
            return true; 
        }

        public virtual string Description
        {
            get { return Buffer.ToString(); }
        }

        public abstract void Execute();
    }
}
