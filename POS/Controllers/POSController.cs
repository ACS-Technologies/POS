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
        public ActionResult Index(int? Id)
        {

            int CompanyId = ((CompanyInfo)Session["CompanyInfo"]).Id; 
            int BranchId = ((CompanyBranch)Session["BranchInfo"]).BranchID;
            var   oSuspendedSaleDBL = new SuspendedSaleDBL();
            Main main = new Main();
            Session["user_name"] = SessionManager.GetSessionUserInfo.Username;
            Session["first_name"] =SessionManager.GetSessionUserInfo.FirstName;
            Session["last_name"] = SessionManager.GetSessionUserInfo.LastName;
            Session["Avatar"] = "male.png";
            Session["rmspos"] = true;
            Session["logo"] = "logo.png";
            main.CompanyId = CompanyId;
            main.BranchId = BranchId;
            RegistersDBL oRegistersDBL = new RegistersDBL();
            //API 
            APIAuthorization authorization = APICall.GetAuthorization(string.Format("{0}/token", (object)ConfigurationManager.AppSettings["APIURL"]), ConfigurationManager.AppSettings["APIUser"], ConfigurationManager.AppSettings["APIPassword"]);
            APIAuthorization vehicleAuthorization = APICall.GetAuthorization(string.Format("{0}/token", (object)ConfigurationManager.AppSettings["VehicleAPIURL"]), ConfigurationManager.AppSettings["VehicleAPIUser"], ConfigurationManager.AppSettings["VehicleAPIPassword"]);

            Response responseGroup = APICall.Get<Response>(string.Format("{0}/Groups/Get_Groups?CompanyId={1}&BranchId={2}&Language={3}", (object)ConfigurationManager.AppSettings["APIURL"], 1158, 307, "en"), authorization.TokenType, authorization.AccessToken);
            if (responseGroup.IsScusses)
            {
                main.Group = JsonConvert.DeserializeObject<List<Group>>(JsonConvert.SerializeObject(responseGroup.ResponseDetails));
            }
            Response responseCategory = APICall.Get<Response>(string.Format("{0}/Categories/Get_Categories?CompanyId={1}&BranchId={2}&Language={3}", (object)ConfigurationManager.AppSettings["APIURL"], main.CompanyId, main.BranchId, "en"), authorization.TokenType, authorization.AccessToken);
            if (responseCategory.IsScusses)
            {
                main.Category = JsonConvert.DeserializeObject<List<Category>>(JsonConvert.SerializeObject(responseCategory.ResponseDetails));
            }
            Response responseUsers = APICall.Get<Response>(string.Format("{0}/Workshop/GetWorkshops?CompanyId={1}&BranchId={2}", (object)ConfigurationManager.AppSettings["VehicleAPIURL"],CompanyId,BranchId), vehicleAuthorization.TokenType, vehicleAuthorization.AccessToken);
            if (responseUsers.IsScusses)
            {
                main.Workshops = JsonConvert.DeserializeObject<List<WorkshopLevels>>(JsonConvert.SerializeObject(responseUsers.ResponseDetails));
            }
            Response responsePaymentMethod = APICall.Get<Response>(string.Format("{0}/PaymentMethod/Get_PaymentMethod?Id={1}&CompanyId={2}&BranchId={3}&Language={4}", (object)ConfigurationManager.AppSettings["APIURL"],0, main.CompanyId, main.BranchId, "en"), authorization.TokenType, authorization.AccessToken);
            if (responsePaymentMethod.IsScusses)
            {
                main.PaymentMethod = JsonConvert.DeserializeObject<List<PaymentMethod>>(JsonConvert.SerializeObject(responsePaymentMethod.ResponseDetails));
            }
            if (1==1)
            {
                Response responseCustomerInformation = APICall.Get<Response>(string.Format("{0}/CustomerInformation/Get_CustomerInformation?CompanyId={1}&BranchId={2}&Language={3}", (object)ConfigurationManager.AppSettings["APIURL"], main.CompanyId, main.BranchId, "en"), authorization.TokenType, authorization.AccessToken);
                if (responseCustomerInformation.IsScusses)
                {
                    main.CustomerInformation = JsonConvert.DeserializeObject<List<CustomerInformation>>(JsonConvert.SerializeObject(responseCustomerInformation.ResponseDetails));
                }
            }
            //else
            //{
            //    APIAuthorization authorization1 = APICall.GetAuthorization(string.Format("{0}/token", (object)ConfigurationManager.AppSettings["VehicleIURL"]), ConfigurationManager.AppSettings["VehicleUser"], ConfigurationManager.AppSettings["VehiclePassword"]);
            //    Response responseCustomerInformation = APICall.Get<Response>(string.Format("{0}/CustomerInformation/Get_CustomerInformation?BranchId={1}&Language={2}", (object)ConfigurationManager.AppSettings["VehicleIURL"], BranchId, "en"), authorization.TokenType, authorization.AccessToken);
            //    if (responseCustomerInformation.IsScusses)
            //    {
            //        main.CustomerInformation = JsonConvert.DeserializeObject<List<CustomerInformation>>(JsonConvert.SerializeObject(responseCustomerInformation.ResponseDetails));
            //    }
            //}
            main.oBankBranch = new BankBranch();
            Response response3 = APICall.Get<Response>(string.Format("{0}/Banks/Banks_Active", (object)ConfigurationManager.AppSettings["APIURL"]), authorization.TokenType, authorization.AccessToken);
            if (response3.IsScusses)
            {
                main.oBankBranch.oLBank = JsonConvert.DeserializeObject<List<Bank>>(JsonConvert.SerializeObject(response3.ResponseDetails));

            }
            Response response4 = APICall.Get<Response>(string.Format("{0}/Banks/Banks_Branch", (object)ConfigurationManager.AppSettings["APIURL"]), authorization.TokenType, authorization.AccessToken);
            if (response4.IsScusses)
            {
                main.oLBankBranch = JsonConvert.DeserializeObject<List<BankBranch>>(JsonConvert.SerializeObject(response4.ResponseDetails));

            }
            main.Item = new List<Item>();
            int userId = SessionManager.GetSessionUserInfo.UserID;
            main.SuspendedSale = oSuspendedSaleDBL.M_SuspendedSale_GetAll(userId);
            main.store = new Store();
            main.ImageUrl = (string)ConfigurationManager.AppSettings["ImageUrl"];
            if (Id !=null)
            {
                main.SalesId = (int)Id;
            }
            main.Registers = oRegistersDBL.M_RegisterByUserIdAndStoreId_Get(main.BranchId, userId);
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
            int CompanyId = ((CompanyInfo)Session["CompanyInfo"]).Id;
            int BranchId = ((CompanyBranch)Session["BranchInfo"]).BranchID;
            Item oItem = new Item();
            APIAuthorization authorization = APICall.GetAuthorization(string.Format("{0}/token", (object)ConfigurationManager.AppSettings["APIURL"]), ConfigurationManager.AppSettings["APIUser"], ConfigurationManager.AppSettings["APIPassword"]);
            Response responseGroup = APICall.Get<Response>(string.Format("{0}/Items/Get_ItemsById?Id={1}&CompanyId={2}&BranchId={3}&Language={4}", (object)ConfigurationManager.AppSettings["APIURL"], Id,CompanyId,BranchId, "en"), authorization.TokenType, authorization.AccessToken);
            if (responseGroup.IsScusses)
            {
                oItem = JsonConvert.DeserializeObject<Item>(JsonConvert.SerializeObject(responseGroup.ResponseDetails));
            }
            return Json(oItem, JsonRequestBehavior.AllowGet);


        }
        public JsonResult Get_Items()
        {
            int CompanyId = ((CompanyInfo)Session["CompanyInfo"]).Id;
            int BranchId = ((CompanyBranch)Session["BranchInfo"]).BranchID;
            List <Item> oItem = new List<Item>();
            APIAuthorization authorization = APICall.GetAuthorization(string.Format("{0}/token", (object)ConfigurationManager.AppSettings["APIURL"]), ConfigurationManager.AppSettings["APIUser"], ConfigurationManager.AppSettings["APIPassword"]);
            Response responseGroup = APICall.Get<Response>(string.Format("{0}/Items/Get_Items?CompanyId={1}&BranchId={2}&Language={3}", (object)ConfigurationManager.AppSettings["APIURL"], CompanyId, BranchId, "en"), authorization.TokenType, authorization.AccessToken);
            if (responseGroup.IsScusses)
            {
                oItem = JsonConvert.DeserializeObject<List<Item>>(JsonConvert.SerializeObject(responseGroup.ResponseDetails));
            }
            return Json(oItem, JsonRequestBehavior.AllowGet);


        }
        public JsonResult PaymentMethod_Get(int? MethodId,int BranchId)
        {
            int CompanyId = ((CompanyInfo)Session["CompanyInfo"]).Id;
            int _BranchId = ((CompanyBranch)Session["BranchInfo"]).BranchID;
            List<PaymentMethod> PaymentMethod = new List<PaymentMethod>();
            APIAuthorization authorization = APICall.GetAuthorization(string.Format("{0}/token", (object)ConfigurationManager.AppSettings["APIURL"]), ConfigurationManager.AppSettings["APIUser"], ConfigurationManager.AppSettings["APIPassword"]);

            Response responsePaymentMethod = APICall.Get<Response>(string.Format("{0}/PaymentMethod/Get_PaymentMethod?Id={1}&CompanyId={2}&BranchId={3}&Language={4}", (object)ConfigurationManager.AppSettings["APIURL"], MethodId, CompanyId, _BranchId, "en"), authorization.TokenType, authorization.AccessToken);
            if (responsePaymentMethod.IsScusses)
            {
                PaymentMethod = JsonConvert.DeserializeObject<List<PaymentMethod>>(JsonConvert.SerializeObject(responsePaymentMethod.ResponseDetails));
            }
            return Json(PaymentMethod, JsonRequestBehavior.AllowGet);


        }
        public ActionResult ViewBill()
        {
            return View("view_bill");
        }
        public ActionResult PrintOrder(int Id)
        {
            SalesDBL salesDBL = new SalesDBL();
            Sales sales = new Sales();
            sales= salesDBL.M_Sales_GetById(Id);
            return View(sales);
        }
        public ActionResult TablePage()
        {
            var oSuspendedSaleDBL = new SuspendedSaleDBL();
            var oSalesDBL = new SalesDBL();
            Main main = new Main();
            Session["user_name"] = SessionManager.GetSessionUserInfo.Username;
            Session["first_name"] = SessionManager.GetSessionUserInfo.FirstName;
            Session["last_name"] = SessionManager.GetSessionUserInfo.LastName;
            Session["Avatar"] = "male.png";
            Session["rmspos"] = true;
            Session["logo"] = "logo.png";
            int CompanyId = ((CompanyInfo)Session["CompanyInfo"]).Id;
            int BranchId = ((CompanyBranch)Session["BranchInfo"]).BranchID;
            RegistersDBL oRegistersDBL = new RegistersDBL();
            //API 
            APIAuthorization vehicleAuthorization = APICall.GetAuthorization(string.Format("{0}/token", (object)ConfigurationManager.AppSettings["VehicleAPIURL"]), ConfigurationManager.AppSettings["VehicleAPIUser"], ConfigurationManager.AppSettings["VehicleAPIPassword"]);
            APIAuthorization authorization = APICall.GetAuthorization(string.Format("{0}/token", (object)ConfigurationManager.AppSettings["APIURL"]), ConfigurationManager.AppSettings["APIUser"], ConfigurationManager.AppSettings["APIPassword"]);
            Response responseGroup = APICall.Get<Response>(string.Format("{0}/Groups/Get_Groups?CompanyId={1}&BranchId={2}&Language={3}", (object)ConfigurationManager.AppSettings["APIURL"], CompanyId, BranchId, "en"), authorization.TokenType, authorization.AccessToken);
            if (responseGroup.IsScusses)
            {
                main.Group = JsonConvert.DeserializeObject<List<Group>>(JsonConvert.SerializeObject(responseGroup.ResponseDetails));
            }
            Response responseCategory = APICall.Get<Response>(string.Format("{0}/Categories/Get_Categories?CompanyId={1}&BranchId={2}&Language={3}", (object)ConfigurationManager.AppSettings["APIURL"], CompanyId, BranchId, "en"), authorization.TokenType, authorization.AccessToken);
            if (responseCategory.IsScusses)
            {
                main.Category = JsonConvert.DeserializeObject<List<Category>>(JsonConvert.SerializeObject(responseCategory.ResponseDetails));
            }

            Response responseUsers = APICall.Get<Response>(string.Format("{0}/Workshop/GetWorkshops?CompanyId={1}&BranchId={2}", (object)ConfigurationManager.AppSettings["VehicleAPIURL"], CompanyId, BranchId), vehicleAuthorization.TokenType, vehicleAuthorization.AccessToken);
            if (responseUsers.IsScusses)
            {
                main.Workshops = JsonConvert.DeserializeObject<List<WorkshopLevels>>(JsonConvert.SerializeObject(responseUsers.ResponseDetails));
            }
            Response responsePaymentMethod = APICall.Get<Response>(string.Format("{0}/PaymentMethod/Get_PaymentMethod?Id={1}&CompanyId={2}&BranchId={3}&Language={4}", (object)ConfigurationManager.AppSettings["APIURL"], 0, CompanyId, BranchId, "en"), authorization.TokenType, authorization.AccessToken);
            if (responsePaymentMethod.IsScusses)
            {
                main.PaymentMethod = JsonConvert.DeserializeObject<List<PaymentMethod>>(JsonConvert.SerializeObject(responsePaymentMethod.ResponseDetails));
            }
            if (1 == 1)
            {
                Response responseCustomerInformation = APICall.Get<Response>(string.Format("{0}/CustomerInformation/Get_CustomerInformation?CompanyId={1}&BranchId={2}&Language={3}", (object)ConfigurationManager.AppSettings["APIURL"], CompanyId, BranchId, "en"), authorization.TokenType, authorization.AccessToken);
                if (responseCustomerInformation.IsScusses)
                {
                    main.CustomerInformation = JsonConvert.DeserializeObject<List<CustomerInformation>>(JsonConvert.SerializeObject(responseCustomerInformation.ResponseDetails));
                }
            }
            //else
            //{
            //    APIAuthorization authorization1 = APICall.GetAuthorization(string.Format("{0}/token", (object)ConfigurationManager.AppSettings["VehicleIURL"]), ConfigurationManager.AppSettings["VehicleUser"], ConfigurationManager.AppSettings["VehiclePassword"]);
            //    Response responseCustomerInformation = APICall.Get<Response>(string.Format("{0}/CustomerInformation/Get_CustomerInformation?BranchId={1}&Language={2}", (object)ConfigurationManager.AppSettings["VehicleIURL"], BranchId, "en"), authorization.TokenType, authorization.AccessToken);
            //    if (responseCustomerInformation.IsScusses)
            //    {
            //        main.CustomerInformation = JsonConvert.DeserializeObject<List<CustomerInformation>>(JsonConvert.SerializeObject(responseCustomerInformation.ResponseDetails));
            //    }
            //}
            main.Item = new List<Item>();
            int userId = SessionManager.GetSessionUserInfo.UserID;
            main.SuspendedSale = oSuspendedSaleDBL.M_SuspendedSale_GetAll(userId);
            main.Sales = oSalesDBL.M_Sales_GetAll(userId);
            main.store = new Store();
            main.ImageUrl = (string)ConfigurationManager.AppSettings["ImageUrl"];

            main.Registers = oRegistersDBL.M_RegisterByUserIdAndStoreId_Get(main.BranchId, userId);
            return View(main);
        }
        public JsonResult GetGrandTotal()
        {
            int userId = SessionManager.GetSessionUserInfo.UserID; 
            int CompanyId = ((CompanyInfo)Session["CompanyInfo"]).Id;
            int BranchId = ((CompanyBranch)Session["BranchInfo"]).BranchID;
            var oSalesDBL = new SalesDBL();
           decimal GrandTotal=   oSalesDBL.M_Salse_GrandTotal_Get(userId, BranchId);
            return Json(GrandTotal.ToString("0.00"), JsonRequestBehavior.AllowGet);


        }
    }
}