using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Famigo.MultiLanguage.Services
{
    public class ConfigurationService : IConfigurationService
    {
        public IEnvironmentService EnvService { get; }

        public ConfigurationService(IEnvironmentService envService)
        {
            EnvService = envService;
        }

        public IConfiguration GetConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("AppSettings.json", optional: false, reloadOnChange: false)
                .AddJsonFile($"appsettings.{EnvService.EnvironmentName}.json", optional: true, reloadOnChange: false)
                .AddEnvironmentVariables()
                .Build();
        }
    }


    public interface IConfigurationService
    {
        IConfiguration GetConfiguration();
    }
}
