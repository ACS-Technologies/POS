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
    public class RegistersController : BaseController
    {
        RegistersDBL oRegistersDBL;
        ResultJson result;

        /// <summary>
        /// OpenRegister
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult OpenRegister(Registers model)
        {
            result = new ResultJson();
            oRegistersDBL = new RegistersDBL();
            int CompanyId = ((POCO.CompanyInfo)Session["CompanyInfo"]).Id;
            int BranchId = ((POCO.CompanyBranch)Session["BranchInfo"]).BranchID;
            try
            {


                if (model.Cash_in_hand <= 0)
                {
                    result.IsSuccess = false;
                    result.Errors.Add("Cash in hand more than 0");
                    return Json(result);
                }

                model.UserId = SessionManager.GetSessionUserInfo.UserID;
                model.Store_id = BranchId;
                model.Status = "open";
                model.Date = DateTime.Now;

                var data = oRegistersDBL.OpenRegister(model);

                if (data.Id > 0)
                {
                    result.IsSuccess = true;
                    result.Url = Url.Action("Index", "POS");
                    return Json(result);
                }
                else
                {
                    result.IsSuccess = false;
                    return Json(result);
                }


            }
            catch
            {
                result.IsSuccess = false;
                return Json(result);
            }
        }
        [HttpPost]
        public ActionResult CloseRegister(Registers model)
        {
            result = new ResultJson();
            oRegistersDBL = new RegistersDBL();
            int CompanyId = ((POCO.CompanyInfo)Session["CompanyInfo"]).Id;
            int BranchId = ((POCO.CompanyBranch)Session["BranchInfo"]).BranchID;
            var AccountTable = new List<AccountTable>();
            var oLTransTypeUD = new List<TransTypeUD>();
            var Branch = new Branches();
            var oTransTypeUD = new TransTypeUD();
            SettingsDBL oSettingsDBL = new SettingsDBL();
            var SettingAccounts = oSettingsDBL.GetSettingAccountsByBranchId(BranchId);
            try
            {


                if (model.Cash_in_hand <= 0)
                {
                    result.IsSuccess = false;
                    result.Errors.Add("Cash in hand more than 0");
                    return Json(result);
                }

                model.Store_id = BranchId;
                model.Closed_by= SessionManager.GetSessionUserInfo.UserID;
                var data = oRegistersDBL.CloseRegister(model);

                if (data.Id > 0)
                {
                    List<POCO.SalesInvoiceSettings> oGetSalesInvoiceSettings = new List<SalesInvoiceSettings>();
                    var oSalesDBL = new SalesDBL();
                    var Sales  = oSalesDBL.M_Salse_GrandTotal_Get((int)model.Closed_by, BranchId);
                    var oSaleItems= oSalesDBL.M_Sales_GetAllRegister((int)model.Closed_by, BranchId);
                    APIAuthorization authorization = APICall.GetAuthorization(string.Format("{0}/token", (object)ConfigurationManager.AppSettings["APIURL"]), ConfigurationManager.AppSettings["APIUser"], ConfigurationManager.AppSettings["APIPassword"]);
                    Response response = APICall.Get<Response>(string.Format("{0}/ChartOfAccount/ChartOfAccountAcceptTrans?CompanyId={1}&BranchId={2}&language={3}", (object)ConfigurationManager.AppSettings["APIURL"], CompanyId, BranchId, LanguageController.GetCurrentLanguage()), authorization.TokenType, authorization.AccessToken);
                    if (response.IsScusses)
                    {
                        AccountTable = JsonConvert.DeserializeObject<List<AccountTable>>(JsonConvert.SerializeObject(response.ResponseDetails));
                    }
                    Response response1 = APICall.Get<Response>(string.Format("{0}/Authentication/BranchesLink?BranchId={1}", (object)ConfigurationManager.AppSettings["APIURL"], BranchId), authorization.TokenType, authorization.AccessToken);
                    if (response1.IsScusses)
                    {
                        Branch = JsonConvert.DeserializeObject<Branches>(JsonConvert.SerializeObject(response1.ResponseDetails));
                    }
                    Response responseSettings = APICall.Get<Response>(string.Format("{0}/Settings/D_SalesInvoiceSettings_Get?CompanyId={1}&BranchId={2}&Language={3}", (object)ConfigurationManager.AppSettings["APIURL"],CompanyId, BranchId, LanguageController.GetCurrentLanguage()), authorization.TokenType, authorization.AccessToken);
                    if (responseSettings.IsScusses)
                    {
                        oGetSalesInvoiceSettings = JsonConvert.DeserializeObject<List<POCO.SalesInvoiceSettings>>(JsonConvert.SerializeObject(responseSettings.ResponseDetails));
                    }
                    //Debit  من حساب الصندوق
                    oTransTypeUD = new TransTypeUD();
                    oTransTypeUD.AccountNo = (AccountTable.Where(x => x.ID == SettingAccounts.CachAccountId).FirstOrDefault().AccountNo).ToString();
                    oTransTypeUD.TranTypeNo = (Int64)SettingAccounts.TransTypeNo;
                    oTransTypeUD.CurrencyID = Branch.CurrencyIDH;
                    oTransTypeUD.DAmount = Sales.Grand_total;
                    oTransTypeUD.HeaderNotes ="";
                    oTransTypeUD.TranDate = DateTime.Now;
                    oTransTypeUD.CreateDate = DateTime.Now;
                    oTransTypeUD.UserName = model.Closed_by.ToString();
                    oTransTypeUD.CostsCentersNo = 0;
                    oTransTypeUD.Notes ="";
                    oLTransTypeUD.Add(oTransTypeUD);

                    oTransTypeUD = new TransTypeUD();
                    oTransTypeUD.AccountNo = (AccountTable.Where(x => x.ID == SettingAccounts.SalesAccountId).FirstOrDefault().AccountNo).ToString();
                    oTransTypeUD.TranTypeNo = (Int64)SettingAccounts.TransTypeNo;
                    oTransTypeUD.CurrencyID = Branch.CurrencyIDH;
                    oTransTypeUD.CAmount = Sales.Total- (decimal)Sales.Total_discount;
                    oTransTypeUD.HeaderNotes = "";
                    oTransTypeUD.TranDate = DateTime.Now;
                    oTransTypeUD.CreateDate = DateTime.Now;
                    oTransTypeUD.UserName = model.Closed_by.ToString();
                    oTransTypeUD.CostsCentersNo = 0;
                    oTransTypeUD.Notes = "";
                    oLTransTypeUD.Add(oTransTypeUD);

                    oTransTypeUD = new TransTypeUD();
                    oTransTypeUD.AccountNo = (AccountTable.Where(x => x.ID == SettingAccounts.TaxAccountId).FirstOrDefault().AccountNo).ToString();
                    oTransTypeUD.TranTypeNo = (Int64)SettingAccounts.TransTypeNo;
                    oTransTypeUD.CurrencyID = Branch.CurrencyIDH;
                    oTransTypeUD.CAmount = (decimal)Sales.Total_tax;
                    oTransTypeUD.HeaderNotes = "";
                    oTransTypeUD.TranDate = DateTime.Now;
                    oTransTypeUD.CreateDate = DateTime.Now;
                    oTransTypeUD.UserName = model.Closed_by.ToString();
                    oTransTypeUD.CostsCentersNo = 0;
                    oTransTypeUD.Notes = "";
                    oLTransTypeUD.Add(oTransTypeUD);
                    Transactions Transactions = new Transactions();
                    Transactions.oLTransTypeUD = oLTransTypeUD;
                    Transactions.CompanyId = CompanyId;
                    Transactions.BranchId = Branch.BranchID;
                    Transactions.UserID = (int)model.Closed_by;
                    Transactions.VoucherType = 1;
                    Transactions.oLReceiptChequeUD = new List<ReceiptChequeUD>();
                    Response response2 = APICall.Post<Response>(string.Format("{0}/Transaction/PostTransaction", (object)ConfigurationManager.AppSettings["APIURL"]), authorization.TokenType, authorization.AccessToken, Transactions);
                    if (response2.IsScusses)
                    {
                        List<AccountSalesDetails> accountSalesDetails = new List<AccountSalesDetails>();
                        AccountSalesDetails accountSales = new AccountSalesDetails(); 
                           var oTransTable1 = JsonConvert.DeserializeObject<List<TransTable>>(JsonConvert.SerializeObject(response2.ResponseDetails));
                        AccountSalesMaster AccountSalesMaster = new AccountSalesMaster() { AccSalesTypeNo = SettingAccounts.TransTypeNo, AccSalesNo = (decimal)oTransTable1.FirstOrDefault().TranNo, AccSalesBranch = BranchId, AccSalesDate = DateTime.Now.Date, Total = Sales.Total, CAccountNo = oGetSalesInvoiceSettings.FirstOrDefault().POSCustomer, DAccountNo = oGetSalesInvoiceSettings.FirstOrDefault().POSCustomer, Discount = (decimal)Sales.Total_discount, Net = (decimal)Sales.Grand_total+ (decimal)Sales.Total_tax, Tax = (decimal)Sales.Total_tax, Final = (decimal)Sales.Grand_total, CurrencyID = Branch.CurrencyIDH, Currency = Branch.CurrencyIDH, UserId = model.Closed_by.ToString(), PaymentTerms = 45,InvoiceType=1 };
                        foreach (var item in oSaleItems)
                        {
                            accountSales = new AccountSalesDetails();
                            accountSales.ItemNumber = item.Product_id;
                            accountSales.UnitId = item.UnitId;
                            accountSales.Quantity = item.Quantity;
                            accountSales.UnitQuantity = item.Quantity;
                            accountSales.Discount =(decimal)item.Item_discount;
                            accountSales.TaxValue = (decimal)item.Item_tax;
                            accountSales.Total = (decimal)item.Subtotal;
                            accountSales.Final = (accountSales.Total - accountSales.Discount) ;
                            accountSales.Price = (decimal)item.Real_unit_price;
                            accountSales.KeyId = Guid.NewGuid().ToString();
                            accountSales.TaxClassificationId = item.TaxClassificationNo;
                            accountSales.AccSalesTypeNo = SettingAccounts.TransTypeNo;
                            accountSales.AccSalesNo = (decimal)oTransTable1.FirstOrDefault().TranNo;
                            accountSalesDetails.Add(accountSales);
                        }
                        AccountSales sales = new AccountSales();
                        sales.AccountSalesMaster = AccountSalesMaster;
                        sales.AccountSalesDetails = accountSalesDetails;
                        sales.CompanyId = CompanyId;
                        sales.BranchId = BranchId;
                        Response responseSales = APICall.Post<Response>(string.Format("{0}/SalesInvoice/AccountSalesMaster_Insert", (object)ConfigurationManager.AppSettings["APIURL"]), authorization.TokenType, authorization.AccessToken, sales);
                        if (responseSales.IsScusses)
                        {
                        }
                        }
                    result.IsSuccess = true;
                    result.Url = Url.Action("Index", "POS");
                    return Json(result);
                }
                else
                {
                    result.IsSuccess = false;
                    return Json(result);
                }


            }
            catch
            {
                result.IsSuccess = false;
                return Json(result);
            }
        }
    }
}