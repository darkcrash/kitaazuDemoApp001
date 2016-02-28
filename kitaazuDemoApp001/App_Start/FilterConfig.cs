using Microsoft.ApplicationInsights;
using System.Web;
using System.Web.Mvc;

namespace kitaazuDemoApp001
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }

    public class AppIdAttribute : ActionFilterAttribute {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var appInsights = new TelemetryClient();
            appInsights.Context.User.AccountId = filterContext.HttpContext.User.Identity.Name;

        }

    }
}
