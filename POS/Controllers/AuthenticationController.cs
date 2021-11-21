using System;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Configuration;
using POCO;
using POS.CORS;
using POS.Models;
using POS.Utilities;

namespace POS.Controllers
{
    [AllowCrossSite]
    public class AuthenticationController : Controller
    {

        #region Actions
        // GET: Authentication
        public ActionResult Index()
        {
            if (Request.Cookies["Remember"] == null || Request.Cookies["Remember"].Value == "")
            {
                return View();
            }
            else
            {
                string language;
                if (Request.Cookies["Language"] != null)
                {
                    language = Request.Cookies["Language"].Value;
                }
                else
                {
                    language = "en";
                }

                APIAuthorization authorization = APICall.GetAuthorization(string.Format("{0}/token", (object)ConfigurationManager.AppSettings["APIURL"]), ConfigurationManager.AppSettings["APIUser"], ConfigurationManager.AppSettings["APIPassword"]);
                Response responseGroup = APICall.Get<Response>(string.Format("{0}/Authentication/User_GetById?Id={1}", (object)ConfigurationManager.AppSettings["APIURL"], SessionManager.GetSessionUserInfo.UserID), authorization.TokenType, authorization.AccessToken);
                if (responseGroup.IsScusses)
                {
                    Session["UserInfo"] = JsonConvert.DeserializeObject<User>(JsonConvert.SerializeObject(responseGroup.ResponseDetails));
                }
                return RedirectToAction("Index", "POS");
            }


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User PoUser)
        {
            User oUser = new User();
            string language;
            try
            {
                if (Request.Cookies["Language"] != null)
                {
                    language = Request.Cookies["Language"].Value;
                }
                else
                {
                    language = "en";
                }
                //API 
                APIAuthorization authorization = APICall.GetAuthorization(string.Format("{0}/token", (object)ConfigurationManager.AppSettings["APIURL"]), ConfigurationManager.AppSettings["APIUser"], ConfigurationManager.AppSettings["APIPassword"]);
                Response response = APICall.Post<Response>(string.Format("{0}/Authentication/LogIn?UserName={1}&Password={2}", (object)ConfigurationManager.AppSettings["APIURL"], PoUser.Username, PoUser.OldPassword), authorization.TokenType, authorization.AccessToken);
                if (response.IsScusses)
                {
                    oUser = JsonConvert.DeserializeObject<User>(JsonConvert.SerializeObject(response.ResponseDetails));
                }

                if (oUser.UserID == 0)
                {
                    ModelState.AddModelError(string.Empty, "Invalid username or password");
                    return View("index");
                }
                else
                {
                    Session["UserInfo"] = oUser;
                    var userId = SessionManager.GetSessionUserInfo.UserID;
                    HttpCookie cookie = new HttpCookie("Remember");
                    cookie.Value = oUser.UserID.ToString();
                    Response.Cookies.Add(cookie);

                    return RedirectToAction("Index", "POS");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public ActionResult Logout()
        {
            try
            {
                Response.Cookies["Remember"].Value = "";
                Response.Cookies["Remember"].Expires = DateTime.Now.AddDays(-1);

                Session.Clear();

                Session.Abandon();
                Session.RemoveAll();

                return RedirectToAction("Index", "Authentication");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}