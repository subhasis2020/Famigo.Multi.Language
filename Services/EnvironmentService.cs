using Famigo.MultiLanguage.Helpers;
using System;

namespace Famigo.MultiLanguage.Services
{
    /// <summary>
    /// This service will handle the environment
    /// </summary>
    public class EnvironmentService : IEnvironmentService
    {
        public EnvironmentService()
        {
            EnvironmentName = Environment.GetEnvironmentVariable(EnvironmentVariables.AspnetCoreEnvironment)
                ?? Environments.Production;
        }

        public string EnvironmentName { get; set; }
    }


    public interface IEnvironmentService
    {
        string EnvironmentName { get; set; }
    }
}
