namespace Famigo.MultiLanguage.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILocalizationService
    {
        /// <summary>
        /// Fetching Resource based on culture
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetCurrentCultureResource(string key);
    }
}