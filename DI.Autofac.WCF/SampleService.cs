namespace DI.Autofac.WCF
{
    public class SampleService : ISampleService
    {
        public SampleService(IDependency dependency)
        {
            _Dependency = dependency;
        }

        readonly IDependency _Dependency;

        public void PerformOperation()
        {
            _Dependency.ShowToConsole();
        }
    }
}
