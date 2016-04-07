using System.Collections.Generic;

namespace PackageDeploymentService
{
    public class ExternalDependenciesSettings
    {
        public string ServiceClientPath { get; set; }
        public string ExternalDependenciesPath { get; set; }
        public List<string> FilesToInclude { get; set; }
    }
}