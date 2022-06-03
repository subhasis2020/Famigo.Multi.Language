using Famigo.MultiLanguage.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Collections;
using System.Globalization;
using System.Resources.NetStandard;

namespace Famigo.MultiLanguage.Services
{
    public class GlobalizationService : IGlobalizationService
    {
        public IConfigurationService _config { get; }
        private readonly string _path = @"C:\Famigo\Core\Resources\";
        private readonly string _enResourceFile = "Resource.en.resx";
        private readonly string _esResourceFile = "Resource.es.resx";
        private readonly string _itResourceFile = "Resource.it.resx";
        private readonly string _frResourceFile = "Resource.fr.resx";
        private readonly string _ptResourceFile = "Resource.pt.resx";


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
                        resxFilePath = _path + _enResourceFile;
                        break;
                    case "es":
                        resxFilePath = _path + _esResourceFile;
                        break;
                    case "it":
                        resxFilePath = _path + _itResourceFile;
                        break;
                    case "fr":
                        resxFilePath = _path + _frResourceFile;
                        break;
                    case "pt":
                        resxFilePath = _path + _ptResourceFile;
                        break;
                }

                //need to cache to increase the performence and reduce file operations

                using (ResXResourceReader resxReader = new ResXResourceReader(resxFilePath))
                {
                    foreach (DictionaryEntry entry in resxReader)
                    {
                        if (((string)entry.Key).Equals(key))
                            res = entry.Value.ToString();
                    }
                }
            }
            catch (System.Exception ex )
            {

                throw ex;
            }

            return res;
        }
    }
}
