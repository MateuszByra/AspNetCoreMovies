using Autofac;
using Microsoft.Extensions.Configuration;
using Movies.Infrastructure.Extensions;
using Movies.Infrastructure.LiteDB;

namespace Movies.Infrastructure.IoC.Modules
{
    public class SettingsModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public SettingsModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration.GetSettings<LiteDbSettings>()).SingleInstance();
        }
    }
}