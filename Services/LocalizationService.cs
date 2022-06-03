using System.Collections;
using System.Globalization;
using System.Resources.NetStandard;

namespace Famigo.MultiLanguage.Services
{
    /// <summary>
    /// This service is used to handle multilingual
    /// </summary>
    public class LocalizationService : ILocalizationService
    {
        public IConfigurationService _config { get; }
        private readonly string _path = @"C:\Famigo\Core\Resources\";
        private readonly string _enResourceFile = "Resource.en.resx";
        private readonly string _esResourceFile = "Resource.es.resx";
        private readonly string _itResourceFile = "Resource.it.resx";
        private readonly string _frResourceFile = "Resource.fr.resx";
        private readonly string _ptResourceFile = "Resource.pt.resx";

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="config"></param>
        public LocalizationService(IConfigurationService config)
        {
            _config = config;
        }

        /// <summary>
        /// Fetching Resource based on culture
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
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
