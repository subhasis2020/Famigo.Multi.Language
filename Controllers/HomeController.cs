using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Builder;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Resources;
using System.Globalization;

namespace Famigo.MultiLanguage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IOptions<RequestLocalizationOptions> _locOptions;
        private readonly IViewLocalizer _localizer;

        public HomeController(ILogger<HomeController> logger, IOptions<RequestLocalizationOptions> locOptions, IViewLocalizer localizer)
        {
            _logger = logger;
            _locOptions = locOptions;
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            //current culture en
            var str = CultureInfo.CurrentCulture.Name;
            return View();
        }
    }
}
