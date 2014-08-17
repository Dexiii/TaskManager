using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using StructureMap;
using System.Web.Mvc;

namespace TaskTracker.Web.Infrastructure
{
    public class StructureMapDependencyResolver: IDependencyResolver
    {
        private readonly Func<IContainer> _containerFactory;

        public StructureMapDependencyResolver(Func<IContainer> containerFactory)
        {
            _containerFactory = containerFactory;    
        }

        object IDependencyResolver.GetService(Type serviceType)
        {
            if (serviceType == null)
                return null;

            var container = _containerFactory();

            //TODO: try suggestion of not using objectfactory container
            return serviceType.IsAbstract || serviceType.IsInterface ? container.TryGetInstance(serviceType) : container.GetInstance(serviceType);
        }

        IEnumerable<object> IDependencyResolver.GetServices(Type serviceType)
        {
            return _containerFactory().GetAllInstances(serviceType).Cast<object>();
        }
    }
}