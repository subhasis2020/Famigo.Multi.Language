using Famigo.MultiLanguage.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Collections;
using System.Globalization;
using System.Resources.NetStandard;

namespace Famigo.MultiLanguage.Helpers
{
    public class CustomCultureInfo
    {
        public IConfigurationService _config { get; }
        private string _culture;
        private static string webSiteUrl = "";
        public CustomCultureInfo()
        {
            var serviceCollection = new ServiceCollection();
            DependencyInjection.Configuration(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            _config = serviceProvider.GetService<IConfigurationService>();

            _culture = CultureInfo.CurrentCulture.Name  ?? "en";
        }

        public static  string GetCultureInfoValue(string key)
        {
            var serviceCollection = new ServiceCollection();
            DependencyInjection.Configuration(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var cnfg = serviceProvider.GetService<IConfigurationService>();
            var culture = CultureInfo.CurrentCulture.Name ?? "en";

            var res = "";
            webSiteUrl = cnfg.GetConfiguration()["WebSiteUrl"].ToString();
           
            try
            {
                string resxFile = webSiteUrl + "ResourcesHelper/Index.en.resx";

                switch (culture)
                {
                    case "en":  resxFile = @"C:\Famigo\Core\wwwroot\ResourcesHelper\Index.en.resx";
                        break; 
                    case "es":  resxFile = @"C:\Famigo\Core\wwwroot\ResourcesHelper\Index.es.resx";
                        break; 
                    case "it":  resxFile = @"C:\Famigo\Core\wwwroot\ResourcesHelper\Index.it.resx";
                        break; 
                    case "fr":  resxFile = @"C:\Famigo\Core\wwwroot\ResourcesHelper\Index.fr.resx";
                        break; 
                    case "pt":  resxFile = @"C:\Famigo\Core\wwwroot\ResourcesHelper\Index.pt.resx";
                        break;                   
                }


                using (ResXResourceReader resxReader = new ResXResourceReader(resxFile))
                {
                    foreach (DictionaryEntry entry in resxReader)
                    {
                        if (((string)entry.Key).Equals(key))
                            res = entry.Value.ToString();                        
                    }
                }
            }
            catch (System.Exception)
            {

                throw;
            }
           
            return res;
        }
    }
}
