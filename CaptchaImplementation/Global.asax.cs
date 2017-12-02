using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CaptchaImplementation
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BundleTable.EnableOptimizations = true;
        }
        protected void Application_Error()
        {
            Exception exception = Server.GetLastError();
            // Todo: Log it
        }
        protected void Application_EndRequest()
        {
            int errorCode = HttpContext.Current.Response.StatusCode;
            switch (errorCode)
            {
                case 400:
                    Response.Redirect("/Error");
                    break;
                case 500:
                    Response.Redirect("/Error");
                    break;
                case 404:
                    Response.Redirect("Error");
                    break;
                default:
                    break;
            }
        }
    }
}
