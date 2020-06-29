namespace Catstagram.Server.Infrastructure
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class ConfigurationExtensions
    {
        public static string GetDefaultConnectionString(this IConfiguration configuration)
             => configuration.GetConnectionString("DefaultConnection");

        public static ApplicationSettings GetAppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            IConfigurationSection appSettingsSection = configuration.GetSection("ApplicationSettings");
            services.Configure<ApplicationSettings>(appSettingsSection);
            ApplicationSettings settings = appSettingsSection.Get<ApplicationSettings>();

            return settings;
        }
    }
}