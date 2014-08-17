using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using TaskTracker.Web.Infrastructure.Tasks;
using TaskTracker.Web.Infrastructure.Mapping;
using AutoMapper;

namespace TaskTracker.Web.App_Start
{
    public class AutoMapperConfig : IRunAtInit
    {
        public void Execute() 
        {
            var types = Assembly.GetExecutingAssembly().GetExportedTypes();

            LoadStandardMappings(types);

            LoadCustomMappings(types);
        }

        private static void LoadCustomMappings(IEnumerable<Type> types)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where typeof(IHaveCustomMappings).IsAssignableFrom(t) &&
                            !t.IsAbstract &&
                            !t.IsInterface
                        select (IHaveCustomMappings)Activator.CreateInstance(t)).ToArray();

            //var maps2 = types.Where
            //(
            //    t => typeof(IHaveCustomMappings)
            //    .IsAssignableFrom(t) && 
            //    !t.IsAbstract && 
            //    !t.IsInterface
            //).Select
            //(
            //    t => (IHaveCustomMappings)Activator.CreateInstance(t)
            //).ToArray();

            foreach (var map in maps) map.CreateMappings(Mapper.Configuration);
        }

        private static void LoadStandardMappings(IEnumerable<Type> types)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where i.IsGenericType &&
                            i.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                            !t.IsAbstract &&
                            !t.IsInterface
                        select new
                        {
                            Source = i.GetGenericArguments()[0],
                            Destination = t
                        }).ToArray();

            foreach (var map in maps)  Mapper.CreateMap(map.Source, map.Destination);
        }
    }
}