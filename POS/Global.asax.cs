using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace POS
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
        protected void Application_BeginRequest(object sender, EventArgs e)

        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies.Get("Language");

            if (cookie != null && cookie.Value != null)
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo(cookie.Value);
                System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.Calendar = new GregorianCalendar();
                System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";
                System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.DateSeparator = "-";

                System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(cookie.Value);
                System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat.Calendar = new GregorianCalendar();
                System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";
                System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat.DateSeparator = "-";
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en");
                System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.Calendar = new GregorianCalendar();
                System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";
                System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.DateSeparator = "-";

                System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
                System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat.Calendar = new GregorianCalendar();
                System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";
                System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat.DateSeparator = "-";
            }
        }
    }
}
