using System;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Configuration;
using POCO;
using POS.CORS;
using POS.Models;
using POS.Utilities;
using System.Collections.Generic;

namespace POS.Controllers
{
    [AllowCrossSite]
    public class AuthenticationController : Controller
    {

        #region Actions
        // GET: Authentication
        public ActionResult Index()
        {
            //if (Request.Cookies["Remember"] == null || Request.Cookies["Remember"].Value == "")
            //{
             return View();
            //}
            //else
            //{
            //    string language;
            //    if (Request.Cookies["Language"] != null)
            //    {
            //        language = Request.Cookies["Language"].Value;
            //    }
            //    else
            //    {
            //        language = "en";
            //    }

                
            //    return RedirectToAction("Index", "POS");
            //}


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
                APIAuthorization authorization = APICall.GetAuthorization(string.Format("{0}/token", (object)ConfigurationManager.AppSettings["APIAuthenticationURL"]), ConfigurationManager.AppSettings["APIUser"], ConfigurationManager.AppSettings["APIPassword"]);
                Response response = APICall.Post<Response>(string.Format("{0}/Users/LogIn", (object)ConfigurationManager.AppSettings["APIAuthenticationURL"]), authorization.TokenType, authorization.AccessToken, PoUser);
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
                    return RedirectToAction("SelectCompany");
                   
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
        public ActionResult SelectCompany()
        {
            List<POCO.CompanyInfo> oLCompanyInfo = new List<POCO.CompanyInfo>();
            //API 
            APIAuthorization authorization = APICall.GetAuthorization(string.Format("{0}/token", (object)ConfigurationManager.AppSettings["APIURL"]), ConfigurationManager.AppSettings["APIUser"], ConfigurationManager.AppSettings["APIPassword"]);
            Response response = APICall.Get<Response>(string.Format("{0}/Authentication/Companies?UserId={1}", (object)ConfigurationManager.AppSettings["APIURL"], SessionManager.GetSessionUserInfo.UserID), authorization.TokenType, authorization.AccessToken);
            if (response.IsScusses)
            {
                oLCompanyInfo = JsonConvert.DeserializeObject<List<POCO.CompanyInfo>>(JsonConvert.SerializeObject(response.ResponseDetails));
            }

            //UsersCompaniesDBL oUsersCompaniesDBL = new UsersCompaniesDBL();
            //    int UserId = Models.SessionManager.GetSessionUserInfo.UserID;
            //    List<POCO.CompanyInfo> oLCompanyInfo = oUsersCompaniesDBL.UsersCompanies_GetUserCompany(UserId);
            return View(oLCompanyInfo);

        }
        public ActionResult SelectCompanyLink(int Company)
        {
            //CompanyInfoDBL ocompanyInfoDBL  = new CompanyInfoDBL();
            //  Session["CompanyInfo"] = ocompanyInfoDBL.D_CompanyInfo_Check(Company);



            //API 
            APIAuthorization authorization = APICall.GetAuthorization(string.Format("{0}/token", (object)ConfigurationManager.AppSettings["APIURL"]), ConfigurationManager.AppSettings["APIUser"], ConfigurationManager.AppSettings["APIPassword"]);
            Response response = APICall.Get<Response>(string.Format("{0}/Authentication/CompaniesLink?CompanyId={1}", (object)ConfigurationManager.AppSettings["APIURL"], Company), authorization.TokenType, authorization.AccessToken);
            if (response.IsScusses)
            {
                Session["CompanyInfo"] = JsonConvert.DeserializeObject<POCO.CompanyInfo>(JsonConvert.SerializeObject(response.ResponseDetails));
            }
            Session["Company"] = Company;
            //var s = Session["CompanyInfo"];
            return RedirectToAction("SelectBranch");
        }


        public ActionResult SelectBranch()
        {
            if (Session["Company"] != null)
            {

                //UsersCompaniesDBL oUsersCompaniesDBL = new UsersCompaniesDBL();
                //List<POCO.Branches> oLbranches = oUsersCompaniesDBL.CompaniesBranches_GetUserBranchesOfCompany(comapnyId);

                int comapnyId = int.Parse(Session["Company"].ToString());

                List<POCO.Branches> oLbranches = new List<POCO.Branches>();

                //API 
                APIAuthorization authorization = APICall.GetAuthorization(string.Format("{0}/token", (object)ConfigurationManager.AppSettings["APIURL"]), ConfigurationManager.AppSettings["APIUser"], ConfigurationManager.AppSettings["APIPassword"]);
                Response response = APICall.Get<Response>(string.Format("{0}/Authentication/Branches?CompanyId={1}", (object)ConfigurationManager.AppSettings["APIURL"], comapnyId), authorization.TokenType, authorization.AccessToken);
                if (response.IsScusses)
                {
                    oLbranches = JsonConvert.DeserializeObject<List<POCO.Branches>>(JsonConvert.SerializeObject(response.ResponseDetails));
                }
                return View(oLbranches);
            }
            else
            {
                return RedirectToAction("Index", "Authentication");


            }
        }

        public ActionResult SelectBranchLink(int branch)
        {

            // CompanyBranchDBL ocompanyInfoDBL = new CompanyBranchDBL();

            // Session["branchInfo"] = ocompanyInfoDBL.D_CompanyBranches_Get_ByID(branch);

            //API 
            APIAuthorization authorization = APICall.GetAuthorization(string.Format("{0}/token", (object)ConfigurationManager.AppSettings["APIURL"]), ConfigurationManager.AppSettings["APIUser"], ConfigurationManager.AppSettings["APIPassword"]);
            Response response = APICall.Get<Response>(string.Format("{0}/Authentication/BranchesLink?BranchId={1}", (object)ConfigurationManager.AppSettings["APIURL"], branch), authorization.TokenType, authorization.AccessToken);
            if (response.IsScusses)
            {
                Session["BranchInfo"] = JsonConvert.DeserializeObject<POCO.CompanyBranch>(JsonConvert.SerializeObject(response.ResponseDetails));
            }
            Session["branch"] = branch;
            var s = Session["BranchInfo"];
            return RedirectToAction("Index", "POS");
        }
        #endregion
    }
}