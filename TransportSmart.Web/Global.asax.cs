using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Threading;
using System.Globalization;

namespace TransportSmart.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest()
        {
            try
            {
                HttpCookie cookie = Request.Cookies["Languageone"];
                if (cookie != null && null != cookie.Value)
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(cookie.Value);
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(cookie.Value);
                }
                else
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
                }
            }
            catch (Exception)
            {

                throw;
            }
         
        }

        protected void Application_EndRequest()
        {   //here breakpoint
            //this.Context.AllErrors;
            // under debug mode you can find the exceptions at code: this.Context.AllErrors
        }

        void Application_Error(Object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            if (exception == null)
            {
                return;
            }

            // Handle an exception here...

            // Redirect to an error page
           // Response.Redirect("Errors/PageNotFound");
        }
    }
}
