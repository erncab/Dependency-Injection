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

        public abstract void Execute();
    }
}
