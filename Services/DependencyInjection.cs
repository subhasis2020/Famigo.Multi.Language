using Microsoft.Extensions.DependencyInjection;

namespace Famigo.MultiLanguage.Services
{
    public class DependencyInjection
    {
        public static void Configuration(IServiceCollection serviceCollection)
        {

            serviceCollection.AddSingleton<IEnvironmentService, EnvironmentService>();
            serviceCollection.AddSingleton<IConfigurationService, ConfigurationService>();
        }
    }
}
