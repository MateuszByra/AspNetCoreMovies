using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Autofac;
using Movies.Core.Repositories;
using Movies.Infrastructure.LiteDB;
using Movies.Infrastructure.Repositories;

namespace Movies.Infrastructure.IoC.Modules
{
    public class LiteDbModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(LiteDbModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<ILiteDbRepository>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
