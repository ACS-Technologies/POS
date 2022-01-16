using DBL;
using Newtonsoft.Json;
using POCO;
using POS.Models;
using POS.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
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
            SettingsDBL oSettingsDBL = new SettingsDBL();
            //API 
            APIAuthorization authorization = APICall.GetAuthorization(string.Format("{0}/token", (object)ConfigurationManager.AppSettings["APIURL"]), ConfigurationManager.AppSettings["APIUser"], ConfigurationManager.AppSettings["APIPassword"]);
            APIAuthorization vehicleAuthorization = APICall.GetAuthorization(string.Format("{0}/token", (object)ConfigurationManager.AppSettings["VehicleAPIURL"]), ConfigurationManager.AppSettings["VehicleAPIUser"], ConfigurationManager.AppSettings["VehicleAPIPassword"]);

            Response responseGroup = APICall.Get<Response>(string.Format("{0}/Groups/Get_Groups?CompanyId={1}&BranchId={2}&Language={3}", (object)ConfigurationManager.AppSettings["APIURL"], CompanyId, BranchId, LanguageController.GetCurrentLanguage()), authorization.TokenType, authorization.AccessToken);
            if (responseGroup.IsScusses)
            {
                main.Group = JsonConvert.DeserializeObject<List<POCO.Group>>(JsonConvert.SerializeObject(responseGroup.ResponseDetails));
            }
            Response responseCategory = APICall.Get<Response>(string.Format("{0}/Categories/Get_Categories?CompanyId={1}&BranchId={2}&Language={3}", (object)ConfigurationManager.AppSettings["APIURL"], CompanyId, BranchId, LanguageController.GetCurrentLanguage()), authorization.TokenType, authorization.AccessToken);
            if (responseCategory.IsScusses)
            {
                main.Category = JsonConvert.DeserializeObject<List<Category>>(JsonConvert.SerializeObject(responseCategory.ResponseDetails));
            }
            Response responseUsers = APICall.Get<Response>(string.Format("{0}/Workshop/GetWorkshops?CompanyId={1}&BranchId={2}", (object)ConfigurationManager.AppSettings["VehicleAPIURL"],CompanyId, BranchId), vehicleAuthorization.TokenType, vehicleAuthorization.AccessToken);
            if (responseUsers.IsScusses)
            {
                main.Workshops = JsonConvert.DeserializeObject<List<WorkshopLevels>>(JsonConvert.SerializeObject(responseUsers.ResponseDetails));
            }
            Response responseExpensesType = APICall.Get<Response>(string.Format("{0}/ExpensesType/ExpensesType_Get?CompanyId={1}&BranchId={2}", (object)ConfigurationManager.AppSettings["VehicleAPIURL"], CompanyId, BranchId), vehicleAuthorization.TokenType, vehicleAuthorization.AccessToken);
            if (responseUsers.IsScusses)
            {
                main.ExpensesType = JsonConvert.DeserializeObject<List<ExpensesType>>(JsonConvert.SerializeObject(responseExpensesType.ResponseDetails));
            }
            Response responsePaymentMethod = APICall.Get<Response>(string.Format("{0}/PaymentMethod/Get_PaymentMethod?Id={1}&CompanyId={2}&BranchId={3}&Language={4}", (object)ConfigurationManager.AppSettings["APIURL"],0, CompanyId, BranchId, LanguageController.GetCurrentLanguage()), authorization.TokenType, authorization.AccessToken);
            if (responsePaymentMethod.IsScusses)
            {
                main.PaymentMethod = JsonConvert.DeserializeObject<List<PaymentMethod>>(JsonConvert.SerializeObject(responsePaymentMethod.ResponseDetails));
            }
            main.IsWorkShop = true;
            ViewBag.IsWorkShop = main.IsWorkShop;
            Response response = APICall.Get<Response>(string.Format("{0}/Transaction/TransType?CompanyId={1}&BranchId={2}&lang={3}", (object)ConfigurationManager.AppSettings["APIURL"], CompanyId, BranchId, LanguageController.GetCurrentLanguage()), authorization.TokenType, authorization.AccessToken);
            if (response.IsScusses)
            {
                var trans = JsonConvert.DeserializeObject<List<TransTypeTable>>(JsonConvert.SerializeObject(response.ResponseDetails));

                main.TransTypeTable = main.IsWorkShop == true ? trans.Where(x => x.IsAutoCreated == true && x.VoucherType == 2).ToList() : trans.Where(x => x.IsAutoCreated == true && x.VoucherType == 1).ToList();
            }
            Response responseaccount = APICall.Get<Response>(string.Format("{0}/ChartOfAccount/ChartOfAccountAcceptTrans?CompanyId={1}&BranchId={2}&language={3}", (object)ConfigurationManager.AppSettings["APIURL"], CompanyId, BranchId,  LanguageController.GetCurrentLanguage()), authorization.TokenType, authorization.AccessToken);
            if (responseaccount.IsScusses)
            {
                main.AccountTable  = JsonConvert.DeserializeObject<List<AccountTable>>(JsonConvert.SerializeObject(responseaccount.ResponseDetails));
            }
            Response responsetax = APICall.Get<Response>(string.Format("{0}/TaxClassification/TaxClassificationGet?CompanyId={1}&BranchId={2}&lang={3}", (object)ConfigurationManager.AppSettings["APIURL"], CompanyId, BranchId, LanguageController.GetCurrentLanguage()), authorization.TokenType, authorization.AccessToken);
            if (responsetax.IsScusses)
            {
                main.TaxClassificationTable = JsonConvert.DeserializeObject<List<TaxClassificationTable>>(JsonConvert.SerializeObject(responsetax.ResponseDetails));
            }
            //if (1==1)
            //{
            //    Response responseCustomerInformation = APICall.Get<Response>(string.Format("{0}/CustomerInformation/Get_CustomerInformation?CompanyId={1}&BranchId={2}&Language={3}", (object)ConfigurationManager.AppSettings["APIURL"], main.CompanyId, main.BranchId, "en"), authorization.TokenType, authorization.AccessToken);
            //    if (responseCustomerInformation.IsScusses)
            //    {
            //        main.CustomerInformation = JsonConvert.DeserializeObject<List<CustomerInformation>>(JsonConvert.SerializeObject(responseCustomerInformation.ResponseDetails));
            //    }
            //}
            //else
            //{
            
                Response responseVehicleNams = APICall.Get<Response>(string.Format("{0}/VehicleDefinition/M_VehicleDefinitionsDDLGet_POS?CompanyId={1}&language={2}", (object)ConfigurationManager.AppSettings["VehicleAPIURL"], CompanyId, LanguageController.GetCurrentLanguage()), vehicleAuthorization.TokenType, vehicleAuthorization.AccessToken);
                if (responseVehicleNams.IsScusses)
                {
                    main.VehicleNams = JsonConvert.DeserializeObject<List<VehicleNams>>(JsonConvert.SerializeObject(responseVehicleNams.ResponseDetails));
                }
            Response responseCustomerInformation = APICall.Get<Response>(string.Format("{0}/CustomerInformation/GetInsuranceCompanies?CompanyId={1}&Language={2}", (object)ConfigurationManager.AppSettings["VehicleAPIURL"], CompanyId, LanguageController.GetCurrentLanguage()), vehicleAuthorization.TokenType, vehicleAuthorization.AccessToken);
            if (responseCustomerInformation.IsScusses)
            {
                main.InsuranceCompanies = JsonConvert.DeserializeObject<List<CustomerInformation>>(JsonConvert.SerializeObject(responseCustomerInformation.ResponseDetails));
            }
            Response responseInsuranceDiscountCalculation = APICall.Get<Response>(string.Format("{0}/InsuranceCalculation/GetInsuranceCalculation?CompanyId={1}&Language={2}", (object)ConfigurationManager.AppSettings["VehicleAPIURL"], CompanyId, LanguageController.GetCurrentLanguage()), vehicleAuthorization.TokenType, vehicleAuthorization.AccessToken);
            if (responseInsuranceDiscountCalculation.IsScusses)
            {
                main.InsuranceDiscountCalculation = JsonConvert.DeserializeObject<List<InsuranceDiscountCalculation>>(JsonConvert.SerializeObject(responseInsuranceDiscountCalculation.ResponseDetails));
            }
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
            if (main.IsWorkShop)
            {
                main.SuspendedSale = oSuspendedSaleDBL.M_SuspendedSale_GetAll(null, BranchId);
            }
            else
            {
                main.SuspendedSale = oSuspendedSaleDBL.M_SuspendedSale_GetAll(userId, null);
            }
            main.store = new Store();
            main.ImageUrl = (string)ConfigurationManager.AppSettings["ImageUrl"];
            if (Id !=null)
            {
                main.SalesId = (int)Id;
            }
            main.Registers = oRegistersDBL.M_RegisterByUserIdAndStoreId_Get(main.BranchId, userId);
            main.SettingAccounts= oSettingsDBL.GetSettingAccountsByBranchId(BranchId);
            return View(main);
        }
        public JsonResult GetItemsByCategoryId(int Id)
        {
            List<Item> LItem = new List<Item>();
            APIAuthorization authorization = APICall.GetAuthorization(string.Format("{0}/token", (object)ConfigurationManager.AppSettings["APIURL"]), ConfigurationManager.AppSettings["APIUser"], ConfigurationManager.AppSettings["APIPassword"]);
            Response responseGroup = APICall.Get<Response>(string.Format("{0}/Items/Get_Items_ByCategoryId?Id={1}&Language={2}", (object)ConfigurationManager.AppSettings["APIURL"], Id, LanguageController.GetCurrentLanguage()), authorization.TokenType, authorization.AccessToken);
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
            Response responseGroup = APICall.Get<Response>(string.Format("{0}/Items/Get_ItemsById?Id={1}&CompanyId={2}&BranchId={3}&Language={4}", (object)ConfigurationManager.AppSettings["APIURL"], Id,CompanyId,BranchId, LanguageController.GetCurrentLanguage()), authorization.TokenType, authorization.AccessToken);
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
            Response responseGroup = APICall.Get<Response>(string.Format("{0}/Items/Get_Items?CompanyId={1}&BranchId={2}&Language={3}", (object)ConfigurationManager.AppSettings["APIURL"], CompanyId, BranchId, LanguageController.GetCurrentLanguage()), authorization.TokenType, authorization.AccessToken);
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

            Response responsePaymentMethod = APICall.Get<Response>(string.Format("{0}/PaymentMethod/Get_PaymentMethod?Id={1}&CompanyId={2}&BranchId={3}&Language={4}", (object)ConfigurationManager.AppSettings["APIURL"], MethodId, CompanyId, BranchId, LanguageController.GetCurrentLanguage()), authorization.TokenType, authorization.AccessToken);
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
        public ActionResult PrintOrder(int Id,bool IsWorkShop)
        {
            SalesDBL salesDBL = new SalesDBL();
            Sales sales = new Sales();
            sales= salesDBL.M_Sales_GetById(Id, IsWorkShop);
            if (IsWorkShop==true)
            {
                return View("JobOrder", sales);
            }
            else
            {
                return View("PrintOrder", sales);
            }
          
        }
        public ActionResult TablePage()
        {

            int CompanyId = ((CompanyInfo)Session["CompanyInfo"]).Id;
            int BranchId = ((CompanyBranch)Session["BranchInfo"]).BranchID;
            var oSuspendedSaleDBL = new SuspendedSaleDBL();
            Main main = new Main();
            Session["user_name"] = SessionManager.GetSessionUserInfo.Username;
            Session["first_name"] = SessionManager.GetSessionUserInfo.FirstName;
            Session["last_name"] = SessionManager.GetSessionUserInfo.LastName;
            Session["Avatar"] = "male.png";
            Session["rmspos"] = true;
            Session["logo"] = "logo.png";
            main.CompanyId = CompanyId;
            main.BranchId = BranchId;
            RegistersDBL oRegistersDBL = new RegistersDBL();
            SettingsDBL oSettingsDBL = new SettingsDBL();
            //API 
            APIAuthorization authorization = APICall.GetAuthorization(string.Format("{0}/token", (object)ConfigurationManager.AppSettings["APIURL"]), ConfigurationManager.AppSettings["APIUser"], ConfigurationManager.AppSettings["APIPassword"]);
            APIAuthorization vehicleAuthorization = APICall.GetAuthorization(string.Format("{0}/token", (object)ConfigurationManager.AppSettings["VehicleAPIURL"]), ConfigurationManager.AppSettings["VehicleAPIUser"], ConfigurationManager.AppSettings["VehicleAPIPassword"]);

            Response responseGroup = APICall.Get<Response>(string.Format("{0}/Groups/Get_Groups?CompanyId={1}&BranchId={2}&Language={3}", (object)ConfigurationManager.AppSettings["APIURL"], CompanyId, BranchId, LanguageController.GetCurrentLanguage()), authorization.TokenType, authorization.AccessToken);
            if (responseGroup.IsScusses)
            {
                main.Group = JsonConvert.DeserializeObject<List<POCO.Group>>(JsonConvert.SerializeObject(responseGroup.ResponseDetails));
            }
            Response responseCategory = APICall.Get<Response>(string.Format("{0}/Categories/Get_Categories?CompanyId={1}&BranchId={2}&Language={3}", (object)ConfigurationManager.AppSettings["APIURL"], main.CompanyId, main.BranchId, LanguageController.GetCurrentLanguage()), authorization.TokenType, authorization.AccessToken);
            if (responseCategory.IsScusses)
            {
                main.Category = JsonConvert.DeserializeObject<List<Category>>(JsonConvert.SerializeObject(responseCategory.ResponseDetails));
            }
            Response responseUsers = APICall.Get<Response>(string.Format("{0}/Workshop/GetWorkshops?CompanyId={1}&BranchId={2}", (object)ConfigurationManager.AppSettings["VehicleAPIURL"], CompanyId, BranchId), vehicleAuthorization.TokenType, vehicleAuthorization.AccessToken);
            if (responseUsers.IsScusses)
            {
                main.Workshops = JsonConvert.DeserializeObject<List<WorkshopLevels>>(JsonConvert.SerializeObject(responseUsers.ResponseDetails));
            }
            Response responseExpensesType = APICall.Get<Response>(string.Format("{0}/ExpensesType/ExpensesType_Get?CompanyId={1}&BranchId={2}", (object)ConfigurationManager.AppSettings["VehicleAPIURL"], CompanyId, BranchId), vehicleAuthorization.TokenType, vehicleAuthorization.AccessToken);
            if (responseUsers.IsScusses)
            {
                main.ExpensesType = JsonConvert.DeserializeObject<List<ExpensesType>>(JsonConvert.SerializeObject(responseExpensesType.ResponseDetails));
            }
            Response responsePaymentMethod = APICall.Get<Response>(string.Format("{0}/PaymentMethod/Get_PaymentMethod?Id={1}&CompanyId={2}&BranchId={3}&Language={4}", (object)ConfigurationManager.AppSettings["APIURL"], 0, main.CompanyId, main.BranchId, LanguageController.GetCurrentLanguage()), authorization.TokenType, authorization.AccessToken);
            if (responsePaymentMethod.IsScusses)
            {
                main.PaymentMethod = JsonConvert.DeserializeObject<List<PaymentMethod>>(JsonConvert.SerializeObject(responsePaymentMethod.ResponseDetails));
            }


            main.IsWorkShop = true;
            ViewBag.IsWorkShop = main.IsWorkShop;

            Response response = APICall.Get<Response>(string.Format("{0}/Transaction/TransType?CompanyId={1}&BranchId={2}&lang={3}", (object)ConfigurationManager.AppSettings["APIURL"], CompanyId, BranchId, LanguageController.GetCurrentLanguage()), authorization.TokenType, authorization.AccessToken);
            if (response.IsScusses)
            {
                var trans = JsonConvert.DeserializeObject<List<TransTypeTable>>(JsonConvert.SerializeObject(response.ResponseDetails));
                main.TransTypeTable = main.IsWorkShop == true ? trans.Where(x => x.IsAutoCreated == true && x.VoucherType == 2).ToList() : trans.Where(x => x.IsAutoCreated == true && x.VoucherType == 1).ToList();
            }
            Response responseaccount = APICall.Get<Response>(string.Format("{0}/ChartOfAccount/ChartOfAccountAcceptTrans?CompanyId={1}&BranchId={2}&language={3}", (object)ConfigurationManager.AppSettings["APIURL"], CompanyId, BranchId, LanguageController.GetCurrentLanguage()), authorization.TokenType, authorization.AccessToken);
            if (responseaccount.IsScusses)
            {
                main.AccountTable = JsonConvert.DeserializeObject<List<AccountTable>>(JsonConvert.SerializeObject(responseaccount.ResponseDetails));
            }
            Response responsetax = APICall.Get<Response>(string.Format("{0}/TaxClassification/TaxClassificationGet?CompanyId={1}&BranchId={2}&lang={3}", (object)ConfigurationManager.AppSettings["APIURL"], CompanyId, BranchId, LanguageController.GetCurrentLanguage()), authorization.TokenType, authorization.AccessToken);
            if (responsetax.IsScusses)
            {
                main.TaxClassificationTable = JsonConvert.DeserializeObject<List<TaxClassificationTable>>(JsonConvert.SerializeObject(responsetax.ResponseDetails));
            }
            //if (1 == 1)
            //{
            //    Response responseCustomerInformation = APICall.Get<Response>(string.Format("{0}/CustomerInformation/Get_CustomerInformation?CompanyId={1}&BranchId={2}&Language={3}", (object)ConfigurationManager.AppSettings["APIURL"], main.CompanyId, main.BranchId, "en"), authorization.TokenType, authorization.AccessToken);
            //    if (responseCustomerInformation.IsScusses)
            //    {
            //        main.CustomerInformation = JsonConvert.DeserializeObject<List<CustomerInformation>>(JsonConvert.SerializeObject(responseCustomerInformation.ResponseDetails));
            //    }
            //}
            //else
            //{
                Response responseVehicleNams = APICall.Get<Response>(string.Format("{0}/VehicleDefinition/M_VehicleDefinitionsDDLGet_POS?CompanyId={1}&language={2}", (object)ConfigurationManager.AppSettings["VehicleAPIURL"], CompanyId, LanguageController.GetCurrentLanguage()), vehicleAuthorization.TokenType, vehicleAuthorization.AccessToken);
                if (responseVehicleNams.IsScusses)
                {
                    main.VehicleNams = JsonConvert.DeserializeObject<List<VehicleNams>>(JsonConvert.SerializeObject(responseVehicleNams.ResponseDetails));
                }
            Response responseCustomerInformation = APICall.Get<Response>(string.Format("{0}/CustomerInformation/GetInsuranceCompanies?CompanyId={1}&Language={2}", (object)ConfigurationManager.AppSettings["VehicleAPIURL"], CompanyId, LanguageController.GetCurrentLanguage()), vehicleAuthorization.TokenType, vehicleAuthorization.AccessToken);
            if (responseCustomerInformation.IsScusses)
            {
                main.InsuranceCompanies = JsonConvert.DeserializeObject<List<CustomerInformation>>(JsonConvert.SerializeObject(responseCustomerInformation.ResponseDetails));
            }
            Response responseInsuranceDiscountCalculation = APICall.Get<Response>(string.Format("{0}/InsuranceCalculation/GetInsuranceCalculation?CompanyId={1}&Language={2}", (object)ConfigurationManager.AppSettings["VehicleAPIURL"], CompanyId, LanguageController.GetCurrentLanguage()), vehicleAuthorization.TokenType, vehicleAuthorization.AccessToken);
            if (responseInsuranceDiscountCalculation.IsScusses)
            {
                main.InsuranceDiscountCalculation = JsonConvert.DeserializeObject<List<InsuranceDiscountCalculation>>(JsonConvert.SerializeObject(responseInsuranceDiscountCalculation.ResponseDetails));
            }
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

            main.store = new Store();
            main.ImageUrl = (string)ConfigurationManager.AppSettings["ImageUrl"];
            var oSalesDBL = new SalesDBL();
            if (main.IsWorkShop)
            {
                main.SuspendedSale = oSuspendedSaleDBL.M_SuspendedSale_GetAll(null, BranchId);
                main.Sales = oSalesDBL.M_Sales_GetAll(null, BranchId);
            }
            else
            {
                main.SuspendedSale = oSuspendedSaleDBL.M_SuspendedSale_GetAll(userId, null);
                main.Sales = oSalesDBL.M_Sales_GetAll(userId, null);
            }
            main.Registers = oRegistersDBL.M_RegisterByUserIdAndStoreId_Get(main.BranchId, userId);
            main.SettingAccounts = oSettingsDBL.GetSettingAccountsByBranchId(BranchId);
            return View(main);
        }
        public JsonResult Get_PaymentMethod_Paid()
        {
            int userId = SessionManager.GetSessionUserInfo.UserID; 
            int CompanyId = ((CompanyInfo)Session["CompanyInfo"]).Id;
            int BranchId = ((CompanyBranch)Session["BranchInfo"]).BranchID;
            var oSalesDBL = new SalesDBL();
         List<Sales> oLSales =   oSalesDBL.M_Salse_PaymentMethod_Payment(userId, BranchId);
            return Json(oLSales, JsonRequestBehavior.AllowGet);


        }
        public JsonResult Get_TodaySales()
        {
            int CompanyId = ((CompanyInfo)Session["CompanyInfo"]).Id;
            int BranchId = ((CompanyBranch)Session["BranchInfo"]).BranchID;
            var oSalesDBL = new SalesDBL();
            List<Sales> oLSales = oSalesDBL.M_Salse_Get_TodaySales(BranchId);
            return Json(oLSales, JsonRequestBehavior.AllowGet);


        }
        public JsonResult AccidentInfo_Get(int Id)
        {
            AgreementInfo agreementInfo = new AgreementInfo();
            APIAuthorization vehicleAuthorization = APICall.GetAuthorization(string.Format("{0}/token", (object)ConfigurationManager.AppSettings["VehicleAPIURL"]), ConfigurationManager.AppSettings["VehicleAPIUser"], ConfigurationManager.AppSettings["VehicleAPIPassword"]);
            Response responseAgreement = APICall.Get<Response>(string.Format("{0}/Agreement/M_Agreement_GetByAccidentId?AccidentId={1}", (object)ConfigurationManager.AppSettings["VehicleAPIURL"], Id), vehicleAuthorization.TokenType, vehicleAuthorization.AccessToken);
            if (responseAgreement.IsScusses)
            {
                agreementInfo = JsonConvert.DeserializeObject<AgreementInfo>(JsonConvert.SerializeObject(responseAgreement.ResponseDetails));
            }
            return Json(agreementInfo, JsonRequestBehavior.AllowGet);


        }
        public ActionResult PrintInvoice(int Id, int EnduranceRatio,int Type)
        {
            DataSet ds = new DataSet();
            SalesDBL salesDBL = new SalesDBL();
            Sales sales = new Sales();
            ds = salesDBL.M_POS_Sales_GetInvoice(Id);

    
            var Customer = new CustomerInformation();
            int CompanyId = ((CompanyInfo)Session["CompanyInfo"]).Id;
            int BranchId = int.Parse(Session["branch"].ToString());
            CompanyInfo companyInfo = SessionManager.GetSessionCompanyInfo;
            List<CompanyInfo> companyInfos = new List<CompanyInfo>();
            CompanyBranch branches = new CompanyBranch();
            Invoice invoice = new Invoice();
            List<Invoice> OLinvoice = new List<Invoice>();
            companyInfos.Add(companyInfo);

            APIAuthorization authorization = APICall.GetAuthorization(string.Format("{0}/token", (object)ConfigurationManager.AppSettings["APIURL"]), ConfigurationManager.AppSettings["APIUser"], ConfigurationManager.AppSettings["APIPassword"]);
            APIAuthorization vehicleAuthorization = APICall.GetAuthorization(string.Format("{0}/token", (object)ConfigurationManager.AppSettings["VehicleAPIURL"]), ConfigurationManager.AppSettings["VehicleAPIUser"], ConfigurationManager.AppSettings["VehicleAPIPassword"]);
            Response responsebranch = APICall.Get<Response>(string.Format("{0}/Authentication/D_CompanyBranches_Get_ByID?CompanyId={1}", (object)ConfigurationManager.AppSettings["APIURL"], BranchId), authorization.TokenType, authorization.AccessToken);
            if (responsebranch.IsScusses)
            {
                branches = JsonConvert.DeserializeObject<CompanyBranch>(JsonConvert.SerializeObject(responsebranch.ResponseDetails));
            }

            var oGeneralDefinitions = new GeneralDefinitions();
            var TaxClassification = new TaxClassification();
            Response responseGeneralDefinitions = APICall.Get<Response>(string.Format("{0}/GeneralDefinition/GetDefinitionByBranchId?BranchId={1}", (object)ConfigurationManager.AppSettings["VehicleAPIURL"], BranchId), vehicleAuthorization.TokenType, vehicleAuthorization.AccessToken);
            if (responseGeneralDefinitions.IsScusses)
            {
                oGeneralDefinitions = JsonConvert.DeserializeObject<GeneralDefinitions>(JsonConvert.SerializeObject(responseGeneralDefinitions.ResponseDetails));
            }
            Response responsetax = APICall.Get<Response>(string.Format("{0}/TaxClassification/M_TaxClassificationTable_Find?Id={1}", (object)ConfigurationManager.AppSettings["APIURL"], oGeneralDefinitions.TaxClassificationId), authorization.TokenType, authorization.AccessToken);
            if (responsetax.IsScusses)
            {
                TaxClassification = JsonConvert.DeserializeObject<TaxClassification>(JsonConvert.SerializeObject(responsetax.ResponseDetails));

            }
            if (Type !=3)
            {
                Response responseCustomer = APICall.Get<Response>(string.Format("{0}/CustomerInformation/FindById?Id={1}&language={2}", (object)ConfigurationManager.AppSettings["VehicleAPIURL"], Type==1? int.Parse(ds.Tables[0].Rows[0]["CustomerId"].ToString()): int.Parse(ds.Tables[0].Rows[0]["InsuranceCompanies"].ToString()), LanguageController.GetCurrentLanguage()), vehicleAuthorization.TokenType, vehicleAuthorization.AccessToken);
                if (responseCustomer.IsScusses)
                {
                    Customer = JsonConvert.DeserializeObject<CustomerInformation>(JsonConvert.SerializeObject(responseCustomer.ResponseDetails));
                }
            }
            decimal taxvalue = 0;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                invoice = new Invoice();
                invoice.InvoiceNo = int.Parse(ds.Tables[0].Rows[i]["InvoiceNo"].ToString());
                invoice.InvoiceDate = DateTime.Parse(ds.Tables[0].Rows[i]["InvoiceDate"].ToString());
                invoice.Qty = Convert.ToInt32(ds.Tables[0].Rows[i]["Qty"].ToString());
                invoice.Price = decimal.Parse(ds.Tables[0].Rows[i]["Price"].ToString());
                invoice.Total = decimal.Parse(ds.Tables[0].Rows[i]["Total"].ToString());
                invoice.TotalDetails = decimal.Parse(ds.Tables[0].Rows[i]["TotalDetails"].ToString());
                invoice.Discount = decimal.Parse(ds.Tables[0].Rows[i]["Discount"].ToString());
                if (EnduranceRatio == 1)
                {
                    invoice.NetTotal = decimal.Parse(ds.Tables[0].Rows[i]["NetTotal"].ToString());
                    invoice.Tax = decimal.Parse(ds.Tables[0].Rows[i]["Tax"].ToString());
                }
                else if (EnduranceRatio==2)
                {
                    invoice.NetTotal = decimal.Parse(ds.Tables[0].Rows[i]["InsuranceValue"].ToString());
                    taxvalue = invoice.NetTotal / (1 + (TaxClassification.TaxRate / 100));
                    invoice.Tax = invoice.NetTotal - taxvalue;
                    taxvalue = 0;
                }
                else
                {
                    if (Type==1)
                    {
                        invoice.NetTotal = decimal.Parse(ds.Tables[0].Rows[i]["CustomerValue"].ToString());
                        taxvalue = invoice.NetTotal / (1 + (TaxClassification.TaxRate / 100));
                        invoice.Tax = invoice.NetTotal - taxvalue;
                        taxvalue = 0;
                    }
                    else
                    {
                        invoice.NetTotal = decimal.Parse(ds.Tables[0].Rows[i]["InsuranceValue"].ToString());
                        taxvalue = invoice.NetTotal / (1 + (TaxClassification.TaxRate / 100));
                        invoice.Tax = invoice.NetTotal - taxvalue;
                        taxvalue = 0;
                    }
                }
                invoice.Description =ds.Tables[0].Rows[i]["Description"].ToString();
            
                invoice.VATNO = Convert.ToInt32(TaxClassification.TaxRate);
                invoice.CustomerPrimaryName = Customer.CustomerName;
                invoice.CustomerSecondaryname = Customer.CustomerName;
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[i]["EnduranceRatio"].ToString()))
                    invoice.EnduranceRatio = int.Parse(ds.Tables[0].Rows[i]["EnduranceRatio"].ToString());
                invoice.CompanyPrimaryName = companyInfos.FirstOrDefault().CompanyPrimaryName;
                invoice.CompanySecondaryName = companyInfos.FirstOrDefault().CompanySecondaryName;
                invoice.Fax = companyInfos.FirstOrDefault().Fax;
                invoice.Email = companyInfos.FirstOrDefault().Email;
                invoice.Img = companyInfos.FirstOrDefault().Img;
                invoice.Phone = companyInfos.FirstOrDefault().Phone;
                invoice.Address = companyInfos.FirstOrDefault().Address;
                OLinvoice.Add(invoice);
                }
          
            ReportDocument cryRpt = new ReportDocument();

            string Title;
            if (LanguageController.GetCurrentLanguage() == "ar")
            {
                Title = "فاتورة ذمم";
                cryRpt.Load(Path.Combine(Server.MapPath("~/Report"), "CryInvoiceAr.rpt"));
            }
            else
            {
                Title = "Credit INVOICE";
                cryRpt.Load(Path.Combine(Server.MapPath("~/Report"), "CryInvoice.rpt"));
            }
            cryRpt.Database.Tables[0].SetDataSource(OLinvoice);
            cryRpt.SetParameterValue("Title", Title);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = new System.IO.MemoryStream();
            /****************Buttons Handler******************/
            cryRpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "");
            return RedirectToAction("Index");


        }
    }
}