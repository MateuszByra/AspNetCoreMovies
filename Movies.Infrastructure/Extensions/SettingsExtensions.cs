using Microsoft.Extensions.Configuration;

namespace Movies.Infrastructure.Extensions
{
    public static class SettingsExtensions
    {
        public static T GetSettings<T>(this IConfiguration configuration) where T : new()
        {
            var section = typeof(T).Name.Replace("Settings", string.Empty);
            var settings = new T();
            //configuration.GetSection(section).Bind(settings); TODO check reference for Bind method

            return settings;
        }
    }
}