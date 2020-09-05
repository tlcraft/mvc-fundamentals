using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Models;
using System.Linq;

namespace RazorPagesApp.ViewComponents
{
    public class CulturePickerViewComponent : ViewComponent
    {
        private readonly IOptions<RequestLocalizationOptions> localizationOptions;
        public CulturePickerViewComponent(IOptions<RequestLocalizationOptions> localizationOptions)
        {
            this.localizationOptions = localizationOptions;
        }

        public IViewComponentResult Invoke()
        {
            var cultureFeature = HttpContext.Features.Get<IRequestCultureFeature>();

            var model = new CultureManagerModel
            {
                SupportedCultures = localizationOptions.Value.SupportedCultures.ToList(),
                CurrentUICulture = cultureFeature.RequestCulture.UICulture
            };

            return View(model);
        }
    }
}
