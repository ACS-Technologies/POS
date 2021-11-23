using System;
using System.Collections.Generic;
using System.Linq;
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