using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;

namespace kitaazuDemoApp001
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AppIdAttribute());
        }
    }

    public class AppIdAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {

            base.OnActionExecuted(filterContext);

            var appInsights = new TelemetryClient();

            var inContext = appInsights.Context.GetInternalContext();


            //appInsights.Context.User.AccountId = filterContext.HttpContext.User.Identity.Name;

            appInsights.Context.Properties.Add("user", filterContext.HttpContext.User.Identity.Name);

            appInsights.Context.User.Id = filterContext.HttpContext.User.Identity.Name;

            var mailAddress = filterContext.HttpContext.User.Identity.Name;
            var dic = new Dictionary<string, string>();
            dic.Add("mail", mailAddress);

            appInsights.TrackEvent("userEvent", dic);
        }



        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            var appInsights = new TelemetryClient();

            base.OnResultExecuted(filterContext);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var appInsights = new TelemetryClient();

            base.OnResultExecuting(filterContext);
        }

    }
}
