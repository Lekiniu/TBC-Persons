using System.Globalization;

namespace Person.API.Middleware
{
    /// <summary>
    /// Request Localization Middleware
    /// </summary>
    public class LocalizationMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="next"></param>
        public LocalizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            var userLangs = context.Request.Headers["Accept-Language"].ToString().Split(',');

            var lang = CultureConfigs.DefaultCulture;
            if (userLangs.Any(x => x.Contains(CultureConfigs.SecondaryCulture)))
                lang = CultureConfigs.SecondaryCulture;

            var cultureInfo = new CultureInfo(lang);
            //switch culture
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            await _next(context);
        }

        public class CultureConfigs
        {
            public const string DefaultCulture = "en-US";
            public const string SecondaryCulture = "ka-GE";
        }
    }
}
