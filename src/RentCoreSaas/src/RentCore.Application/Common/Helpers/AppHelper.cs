using Microsoft.Extensions.Localization;
using RentCore.Application.Resources;
using System.Globalization;

namespace RentCore.Application.Common.Helpers
{
    public static class AppHelper
    {
        private static IStringLocalizer<Resource> _localizer;

        public static void Configure(IStringLocalizer<Resource> localizer)
        {
            _localizer = localizer;
        }

        public static string Translate(string key)
        {
            var localized = _localizer[key];
            if (!localized.ResourceNotFound && !string.IsNullOrEmpty(localized.Value))
            {
                return localized.Value;
            }

            var previousCulture = CultureInfo.CurrentUICulture;
            CultureInfo.CurrentUICulture = new CultureInfo("de-DE");
            try
            {
                return _localizer[key].Value;
            }
            finally
            {
                CultureInfo.CurrentUICulture = previousCulture;
            }
        }
    }
}
