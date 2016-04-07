using System.Collections.Generic;

namespace PackageDeploymentService
{
    public class DeploymentSettings
    {
        public string SourcePath { get; set; }
        public string ZipFileName { get; set; }
        public string TargetPath { get; set; }
        public List<string> FilesToExclude { get; set; }
        public string ServiceClientPath { get; set; }
        public string ExternalDependenciesPath { get; set; }
        public List<string> FilesToInclude { get; set; }
    }
}