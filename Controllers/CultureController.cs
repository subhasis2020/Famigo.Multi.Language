using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Famigo.MultiLanguage.Controllers
{
    public class CultureController : Controller
    {
        /// <summary>
        /// Setting Culture based on localization
        /// </summary>
        /// <param name="culture"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SetCulture(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );
            return LocalRedirect(returnUrl);
        }
    }
}