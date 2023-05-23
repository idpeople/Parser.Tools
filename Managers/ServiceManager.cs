using Parser.Tools.Annotations;
using System;
using System.Reflection;

namespace Parser.Tools.Managers
{
    public sealed class ServiceManager
    {
        public static T Create<T>()
            where T : class
        {
            var instanceType = typeof(T);
            var attr = instanceType.GetCustomAttribute(typeof(T));
            if(attr is null)
                throw new Exception($"The Class {instanceType.Name} doesn't contain a ServiceInstance attribute");
            var serviceInstance = attr as ServiceInstanceAttribute;
            try
            {
                return Activator.CreateInstance(serviceInstance.Manager) as T;
            }
            catch(Exception ex)
            {
                throw new Exception($"Not possible to cast {serviceInstance.Manager.Name} as a new intance of {instanceType.Name}", ex);
            }
        }
    }
}
