using System;

namespace DI.PoorMansContainer.DIContainer
{
    public class ContainerItem
    {
        public Type AbstractionType { get; set; }
        public Type ConcreteType { get; set; }
    }
}
