using Famigo.MultiLanguage.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Collections;
using System.Globalization;
using System.Resources.NetStandard;

namespace Famigo.MultiLanguage.Services
{
    public class GlobalizationService: IGlobalizationService
    {
        public IConfigurationService _config { get; }
            
        public GlobalizationService(IConfigurationService config)
        {
            _config = config;            
        }

        public string GetCurrentCultureResource(string key)
        {           
            var res = ""; 
            try
            {
                string resxFilePath = string.Empty;
                string _culture = CultureInfo.CurrentCulture.Name ?? "en";

                switch (_culture)
                {
                    case "en":  
                        resxFilePath = @"C:\Famigo\Core\Resources\Resource.en.resx";
                        break; 
                    case "es":  
                        resxFilePath = @"C:\Famigo\Core\Resources\Resource.es.resx";
                        break; 
                    case "it":  
                        resxFilePath = @"C:\Famigo\Core\Resources\Resource.it.resx";
                        break; 
                    case "fr":  
                        resxFilePath = @"C:\Famigo\Core\Resources\Resource.fr.resx";
                        break; 
                    case "pt":  
                        resxFilePath = @"C:\Famigo\Core\Resources\Resource.pt.resx";
                        break;                   
                }


                using (ResXResourceReader resxReader = new ResXResourceReader(resxFilePath))
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
