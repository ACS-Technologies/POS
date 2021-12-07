using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace POS.Controllers
{
    public class LanguageController : Controller
    {
        // GET: Language
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult SetLanguage(string lang)
        {
            return View();
        }

        public ActionResult Change(string languageAbbreviation)
        {
            if (languageAbbreviation != null)
            {

                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(languageAbbreviation);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(languageAbbreviation);

            }

            HttpCookie cookie = new HttpCookie("Language");

            cookie.Value = languageAbbreviation;

            Response.Cookies.Add(cookie);

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }


        [NonAction]
        public static bool IsRighToLeft()
        {
            return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.IsRightToLeft;
        }
        [NonAction]
        public static string GetCurrentLanguage()
        {
            return System.Threading.Thread.CurrentThread.CurrentCulture.Name;
        }
    }
}