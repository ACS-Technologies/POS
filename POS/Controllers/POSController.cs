using Newtonsoft.Json;
using POCO;
using POS.Models;
using POS.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POS.Controllers
{
    public class POSController : BaseController
    {
        // GET: POS
        public ActionResult Index()
        {
            Main main = new Main();
            Session["user_name"] = "Abdallah Labib";
            Session["first_name"] = "Haya";
            Session["last_name"] = "Ali";
            Session["Avatar"] = "male.png";
            Session["rmspos"] = true;
            Session["logo"] = "logo.png";

            //API 
            APIAuthorization authorization = APICall.GetAuthorization(string.Format("{0}/token", (object)ConfigurationManager.AppSettings["APIURL"]), ConfigurationManager.AppSettings["APIUser"], ConfigurationManager.AppSettings["APIPassword"]);
            Response responseGroup = APICall.Get<Response>(string.Format("{0}/Groups/Get_Groups?CompanyId={1}&BranchId={2}&Language={3}", (object)ConfigurationManager.AppSettings["APIURL"], 1158, 307, "en"), authorization.TokenType, authorization.AccessToken);
            if (responseGroup.IsScusses)
            {
                main.Group = JsonConvert.DeserializeObject<List<Group>>(JsonConvert.SerializeObject(responseGroup.ResponseDetails));
            }
            Response responseCategory = APICall.Get<Response>(string.Format("{0}/Categories/Get_Categories?CompanyId={1}&BranchId={2}&Language={3}", (object)ConfigurationManager.AppSettings["APIURL"], 1158, 307, "en"), authorization.TokenType, authorization.AccessToken);
            if (responseCategory.IsScusses)
            {
                main.Category = JsonConvert.DeserializeObject<List<Category>>(JsonConvert.SerializeObject(responseCategory.ResponseDetails));
            }
            Response responseItem = APICall.Get<Response>(string.Format("{0}/Items/Get_Items?CompanyId={1}&BranchId={2}&Language={3}", (object)ConfigurationManager.AppSettings["APIURL"], 1158, 307, "en"), authorization.TokenType, authorization.AccessToken);
            if (responseItem.IsScusses)
            {
                main.Item = JsonConvert.DeserializeObject<List<Item>>(JsonConvert.SerializeObject(responseItem.ResponseDetails));
            }
            main.store = new Store();
            return View(main);
        }
    
  
    }
}