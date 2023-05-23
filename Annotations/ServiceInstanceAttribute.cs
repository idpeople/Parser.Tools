using System;

namespace Parser.Tools.Annotations
{
    public sealed class ServiceInstanceAttribute : Attribute
    {
        public readonly Type Manager;

        public ServiceInstanceAttribute(Type manager)
        {
            Manager = manager;
        }
    }
}
