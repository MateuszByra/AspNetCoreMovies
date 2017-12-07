using Autofac;
using Movies.Infrastructure.Mappers;
using Microsoft.Extensions.Configuration;

namespace Movies.Infrastructure.IoC.Modules
{
    public class ContainerModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public ContainerModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<CommandModule>();
            builder.RegisterModule<QueryModule>();
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule(new SettingsModule(_configuration));
            builder.RegisterInstance(AutoMapperConfig.Initialize())
                                                    .SingleInstance();
        }
    }
}
