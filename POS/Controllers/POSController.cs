using DBL;
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
         var   oSuspendedSaleDBL = new SuspendedSaleDBL();
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
            Response responseUsers = APICall.Get<Response>(string.Format("{0}/Users/Get_POSUsers", (object)ConfigurationManager.AppSettings["APIURL"]), authorization.TokenType, authorization.AccessToken);
            if (responseUsers.IsScusses)
            {
                main.User = JsonConvert.DeserializeObject<List<User>>(JsonConvert.SerializeObject(responseUsers.ResponseDetails));
            }
            Response responsePaymentMethod = APICall.Get<Response>(string.Format("{0}/PaymentMethod/Get_PaymentMethod?CompanyId={1}&BranchId={2}&Language={3}", (object)ConfigurationManager.AppSettings["APIURL"], 1158, 307, "en"), authorization.TokenType, authorization.AccessToken);
            if (responsePaymentMethod.IsScusses)
            {
                main.PaymentMethod = JsonConvert.DeserializeObject<List<PaymentMethod>>(JsonConvert.SerializeObject(responsePaymentMethod.ResponseDetails));
            }
            if (1==1)
            {
                Response responseCustomerInformation = APICall.Get<Response>(string.Format("{0}/CustomerInformation/Get_CustomerInformation?CompanyId={1}&BranchId={2}&Language={3}", (object)ConfigurationManager.AppSettings["APIURL"], 1158, 307, "en"), authorization.TokenType, authorization.AccessToken);
                if (responseCustomerInformation.IsScusses)
                {
                    main.CustomerInformation = JsonConvert.DeserializeObject<List<CustomerInformation>>(JsonConvert.SerializeObject(responseCustomerInformation.ResponseDetails));
                }
            }
            //else
            //{
            //    APIAuthorization authorization1 = APICall.GetAuthorization(string.Format("{0}/token", (object)ConfigurationManager.AppSettings["VehicleIURL"]), ConfigurationManager.AppSettings["VehicleUser"], ConfigurationManager.AppSettings["VehiclePassword"]);
            //    Response responseCustomerInformation = APICall.Get<Response>(string.Format("{0}/CustomerInformation/Get_CustomerInformation?BranchId={1}&Language={2}", (object)ConfigurationManager.AppSettings["VehicleIURL"], 307, "en"), authorization.TokenType, authorization.AccessToken);
            //    if (responseCustomerInformation.IsScusses)
            //    {
            //        main.CustomerInformation = JsonConvert.DeserializeObject<List<CustomerInformation>>(JsonConvert.SerializeObject(responseCustomerInformation.ResponseDetails));
            //    }
            //}
            main.Item = new List<Item>();
            int userId = SessionManager.GetSessionUserInfo.UserID;
            main.SuspendedSale = oSuspendedSaleDBL.M_SuspendedSale_GetAll(userId);
            main.store = new Store();
            main.ImageUrl = (string)ConfigurationManager.AppSettings["ImageUrl"];
            return View(main);
        }
        public JsonResult GetItemsByCategoryId(int Id)
        {
            List<Item> LItem = new List<Item>();
            APIAuthorization authorization = APICall.GetAuthorization(string.Format("{0}/token", (object)ConfigurationManager.AppSettings["APIURL"]), ConfigurationManager.AppSettings["APIUser"], ConfigurationManager.AppSettings["APIPassword"]);
            Response responseGroup = APICall.Get<Response>(string.Format("{0}/Items/Get_Items_ByCategoryId?Id={1}&Language={2}", (object)ConfigurationManager.AppSettings["APIURL"], Id, "en"), authorization.TokenType, authorization.AccessToken);
            if (responseGroup.IsScusses)
            {
               LItem = JsonConvert.DeserializeObject<List<Item>>(JsonConvert.SerializeObject(responseGroup.ResponseDetails));
            }
            return Json(LItem, JsonRequestBehavior.AllowGet);


        }
        public JsonResult GetItemsById(int Id)
        {
            Item oItem = new Item();
            APIAuthorization authorization = APICall.GetAuthorization(string.Format("{0}/token", (object)ConfigurationManager.AppSettings["APIURL"]), ConfigurationManager.AppSettings["APIUser"], ConfigurationManager.AppSettings["APIPassword"]);
            Response responseGroup = APICall.Get<Response>(string.Format("{0}/Items/Get_ItemsById?Id={1}&CompanyId={2}&BranchId={3}&Language={4}", (object)ConfigurationManager.AppSettings["APIURL"], Id,1158,307, "en"), authorization.TokenType, authorization.AccessToken);
            if (responseGroup.IsScusses)
            {
                oItem = JsonConvert.DeserializeObject<Item>(JsonConvert.SerializeObject(responseGroup.ResponseDetails));
            }
            return Json(oItem, JsonRequestBehavior.AllowGet);


        } 
        public ActionResult ViewBill()
        {
            return View("view_bill");
        }
        public ActionResult PrintOrder()
        {
            return View();
        }

    }
}