using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap.Graph;
using StructureMap.Pipeline;
using System.Web.Mvc;
using StructureMap.Configuration.DSL;
using StructureMap.TypeRules;

namespace TaskTracker.Web.Infrastructure
{
    public class ControllerConvention: IRegistrationConvention
    {
        public void Process(Type type, Registry registry)
        {
            if (type.CanBeCastTo(typeof(Controller)) && !type.IsAbstract)
                registry.For(type).LifecycleIs(new UniquePerRequestLifecycle()); 
        }
    }
}