﻿using DBL;
using Newtonsoft.Json;
using POCO;
using POS.Models;
using POS.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace POS.Controllers
{
    public class SalesController : BaseController
    {

        SalesDBL oSalesDBL;
        ResultJson result;

        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult GetById(int Id,bool IsWorkShop)
        {
            result = new ResultJson();

            try
            {
                oSalesDBL = new SalesDBL();
                result.IsSuccess = true;
                result.Data = oSalesDBL.M_Sales_GetById(Id, IsWorkShop);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                result.IsSuccess = false;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAll()
        {
            result = new ResultJson();

            try
            {
                int userId =SessionManager.GetSessionUserInfo.UserID;
                oSalesDBL = new SalesDBL();
                result.IsSuccess = true;
                result.Data = oSalesDBL.M_Sales_GetAll(userId);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                result.IsSuccess = false;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int Id)
        {
            result = new ResultJson();

            try
            {
                oSalesDBL = new SalesDBL();
                oSalesDBL.M_Sales_Delete(Id);
                result.IsSuccess = true;
                return Json(result);
            }
            catch
            {
                result.IsSuccess = false;
                return Json(result);
            }
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="PoSales"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Insert(Sales PoSales)
        {
            List<PaymentMethod> olPaymentMethod = new List<PaymentMethod>();
            List<ExpensesType> olExpensesType = new List<ExpensesType>();
            AccountingDefinitions oAccountingDefinitions = new AccountingDefinitions();
            GeneralDefinitions oGeneralDefinitions = new GeneralDefinitions();
            Transactions Transactions = new Transactions();
            List <TaxClassificationTable> OLtaxClassificationTable = new List<TaxClassificationTable>();
            TaxClassificationTable OtaxClassificationTable = new TaxClassificationTable();
            SettingsDBL oSettingsDBL = new SettingsDBL();
            var oLTransTypeUD = new List<TransTypeUD>();
            var AccountTable = new List<AccountTable>();
            var oTransTypeUD = new TransTypeUD();
            result = new ResultJson();
            var oSuspendedSaleDBL = new SuspendedSaleDBL();
            var Car = new VehicleDefinitions();
            int CompanyId = ((POCO.CompanyInfo)Session["CompanyInfo"]).Id;
            int BranchId = ((POCO.CompanyBranch)Session["BranchInfo"]).BranchID;
            try
            {
                oSalesDBL = new SalesDBL();
                result.IsSuccess = true; 
                PoSales.Created_by = SessionManager.GetSessionUserInfo.UserID;
                PoSales.Date = DateTime.Now;
        
                PoSales.Product_discount = PoSales.SaleItems.Sum(x => x.Item_discount) ;
                PoSales.Total_discount = PoSales.Product_discount;
                PoSales.Product_tax = PoSales.SaleItems.Sum(x => x.Item_tax) ;
                PoSales.Total = PoSales.SaleItems.Sum(x => x.Subtotal) ;
                PoSales.Grand_total = PoSales.Total- (decimal)PoSales.Total_discount + (decimal)PoSales.SaleItems.Sum(x => x.Item_tax);
                PoSales.Order_tax = 0;
                PoSales.Total_tax = PoSales.Product_tax + PoSales.Order_tax;
                PoSales.Total_items = PoSales.SaleItems.Count;
                PoSales.Store_id = BranchId;
                Branches oBranch = new Branches();
                if (PoSales.Payments.DateTemp !=null)
                {
                    PoSales.Payments.DateCheque = Convert.ToDateTime(PoSales.Payments.DateTemp);
                }
                if (PoSales.Vehicle_id != 0)
                {

                    APIAuthorization authorization = APICall.GetAuthorization(string.Format("{0}/token", (object)ConfigurationManager.AppSettings["APIURL"]), ConfigurationManager.AppSettings["APIUser"], ConfigurationManager.AppSettings["APIPassword"]);
                    APIAuthorization vehicleAuthorization = APICall.GetAuthorization(string.Format("{0}/token", (object)ConfigurationManager.AppSettings["VehicleAPIURL"]), ConfigurationManager.AppSettings["VehicleAPIUser"], ConfigurationManager.AppSettings["VehicleAPIPassword"]);
                    Response responseExpensesType = APICall.Get<Response>(string.Format("{0}/ExpensesType/ExpensesType_Get?CompanyId={1}&BranchId={2}", (object)ConfigurationManager.AppSettings["VehicleAPIURL"], CompanyId, BranchId), vehicleAuthorization.TokenType, vehicleAuthorization.AccessToken);
                    if (responseExpensesType.IsScusses)
                    {
                        olExpensesType = JsonConvert.DeserializeObject<List<ExpensesType>>(JsonConvert.SerializeObject(responseExpensesType.ResponseDetails));
                    }
                    Response responseAccountingDefinitions = APICall.Get<Response>(string.Format("{0}/AccountingDefinitions/AccountingDefinitions_Get?BranchId={1}", (object)ConfigurationManager.AppSettings["VehicleAPIURL"], BranchId), vehicleAuthorization.TokenType, vehicleAuthorization.AccessToken);
                    if (responseAccountingDefinitions.IsScusses)
                    {
                        oAccountingDefinitions = JsonConvert.DeserializeObject<AccountingDefinitions>(JsonConvert.SerializeObject(responseAccountingDefinitions.ResponseDetails));
                    }
                    Response responseVehicleDefinitions = APICall.Get<Response>(string.Format("{0}/VehicleDefinition/M_VehicleDefinitions_Details_Get?Id={1}", (object)ConfigurationManager.AppSettings["VehicleAPIURL"], PoSales.Vehicle_id), vehicleAuthorization.TokenType, vehicleAuthorization.AccessToken);
                    if (responseVehicleDefinitions.IsScusses)
                    {
                        Car = JsonConvert.DeserializeObject<VehicleDefinitions>(JsonConvert.SerializeObject(responseVehicleDefinitions.ResponseDetails));
                    }
                    Response responseGeneralDefinitions = APICall.Get<Response>(string.Format("{0}/GeneralDefinition/GetDefinitionByBranchId?BranchId={1}", (object)ConfigurationManager.AppSettings["VehicleAPIURL"], BranchId), vehicleAuthorization.TokenType, vehicleAuthorization.AccessToken);
                    if (responseGeneralDefinitions.IsScusses)
                    {
                        oGeneralDefinitions = JsonConvert.DeserializeObject<GeneralDefinitions>(JsonConvert.SerializeObject(responseGeneralDefinitions.ResponseDetails));
                    }
                    Response responsePaymentMethod = APICall.Get<Response>(string.Format("{0}/PaymentMethod/Get_PaymentMethod?Id={1}&CompanyId={2}&BranchId={3}&Language={4}", (object)ConfigurationManager.AppSettings["APIURL"], 0, 1202, 369, LanguageController.GetCurrentLanguage()), authorization.TokenType, authorization.AccessToken);
                    if (responsePaymentMethod.IsScusses)
                    {
                        olPaymentMethod = JsonConvert.DeserializeObject<List<PaymentMethod>>(JsonConvert.SerializeObject(responsePaymentMethod.ResponseDetails));
                    }
                    Response responseB = APICall.Get<Response>(string.Format("{0}/Authentication/BranchesLink?BranchId={1}", (object)ConfigurationManager.AppSettings["APIURL"], BranchId), authorization.TokenType, authorization.AccessToken);
                    if (responseB.IsScusses)
                    {
                        oBranch = JsonConvert.DeserializeObject<Branches>(JsonConvert.SerializeObject(responseB.ResponseDetails));
                    }
                    Response response = APICall.Get<Response>(string.Format("{0}/ChartOfAccount/ChartOfAccountAcceptTrans?CompanyId={1}&BranchId={2}&language={3}", (object)ConfigurationManager.AppSettings["APIURL"], CompanyId, BranchId, LanguageController.GetCurrentLanguage()), authorization.TokenType, authorization.AccessToken);
                    if (response.IsScusses)
                    {
                        AccountTable = JsonConvert.DeserializeObject<List<AccountTable>>(JsonConvert.SerializeObject(response.ResponseDetails));
                    }
                    Response responsetax = APICall.Get<Response>(string.Format("{0}/TaxClassification/TaxClassificationGet?CompanyId={1}&BranchId={2}&lang={3}", (object)ConfigurationManager.AppSettings["APIURL"], 1158, 307, LanguageController.GetCurrentLanguage()), authorization.TokenType, authorization.AccessToken);
                    if (responsetax.IsScusses)
                    {
                        OLtaxClassificationTable = JsonConvert.DeserializeObject<List<TaxClassificationTable>>(JsonConvert.SerializeObject(responsetax.ResponseDetails));
                    }
                    var SettingAccounts = oSettingsDBL.GetSettingAccountsByBranchId(BranchId);
                    Int64 ExpensesNo = olExpensesType.Where(x => x.Id == SettingAccounts.ExpensesTypeId).FirstOrDefault().AccountingNo;
                    Int64 PaymentAccountNo = olPaymentMethod.Where(x => x.MethodId == int.Parse(PoSales.Status)).FirstOrDefault().AccountNo;
                    OtaxClassificationTable = OLtaxClassificationTable.Where(x => x.TaxClassificationNo == oGeneralDefinitions.TaxClassificationId).FirstOrDefault();
                    var opaymentmethod = olPaymentMethod.Where(x => x.MethodId == int.Parse(PoSales.Status)).FirstOrDefault();
                    //Debit  من حساب المصروف

                    oTransTypeUD = new TransTypeUD();
                    oTransTypeUD.AccountNo = (AccountTable.Where(x => x.ID == ExpensesNo).FirstOrDefault().AccountNo).ToString();
                    oTransTypeUD.TranTypeNo = Convert.ToInt64(SettingAccounts.PaymentVoucherId);
                    oTransTypeUD.CurrencyID = oBranch.CurrencyIDH;
                    oTransTypeUD.DAmount = PoSales.Grand_total;
                    oTransTypeUD.HeaderNotes = PoSales.Payments.Note;
                    oTransTypeUD.TranDate = DateTime.Now;
                    oTransTypeUD.CreateDate = DateTime.Now;
                    oTransTypeUD.UserName = SessionManager.GetSessionUserInfo.UserID.ToString();
                    oTransTypeUD.CostsCentersNo = (Int64)(Car.CostCenter);
                    oTransTypeUD.Notes = PoSales.Payments.Note;
                    oLTransTypeUD.Add(oTransTypeUD);

                    // Credit إلى حساب اسلوب الدفع

                    oTransTypeUD = new TransTypeUD();
                    oTransTypeUD.AccountNo = (AccountTable.Where(x => x.ID == PaymentAccountNo).FirstOrDefault().AccountNo).ToString();
                    oTransTypeUD.TranTypeNo = Convert.ToInt64(SettingAccounts.PaymentVoucherId);
                    oTransTypeUD.CurrencyID = oBranch.CurrencyIDH;
                    oTransTypeUD.CAmount = PoSales.Grand_total;
                    oTransTypeUD.HeaderNotes = PoSales.Payments.Note;
                    oTransTypeUD.TranDate = DateTime.Now;
                    oTransTypeUD.CreateDate = DateTime.Now;
                    oTransTypeUD.UserName = SessionManager.GetSessionUserInfo.UserID.ToString();
                    oTransTypeUD.CostsCentersNo = 0;
                    oTransTypeUD.Notes = PoSales.Payments.Note;
                    oLTransTypeUD.Add(oTransTypeUD);

                    if (opaymentmethod.BankPercentage != 0)
                    {
                        decimal tax = 0;
                        decimal BankCommission = 0;
                        BankCommission = ((decimal)opaymentmethod.BankPercentage / 100) * PoSales.Grand_total;
                        tax = BankCommission * OtaxClassificationTable.TaxRate;
                        oTransTypeUD = new TransTypeUD();
                        oTransTypeUD.AccountNo = (AccountTable.Where(x => x.ID == PaymentAccountNo).FirstOrDefault().AccountNo).ToString();
                        oTransTypeUD.TranTypeNo = Convert.ToInt64(SettingAccounts.PaymentVoucherId);
                        oTransTypeUD.CurrencyID = oBranch.CurrencyIDH;
                        oTransTypeUD.DAmount = BankCommission;
                        oTransTypeUD.HeaderNotes = PoSales.Payments.Note;
                        oTransTypeUD.TranDate = DateTime.Now;
                        oTransTypeUD.CreateDate = DateTime.Now;
                        oTransTypeUD.UserName = SessionManager.GetSessionUserInfo.UserID.ToString();
                        oTransTypeUD.CostsCentersNo = 0;
                        oTransTypeUD.Notes = PoSales.Payments.Note;
                        oLTransTypeUD.Add(oTransTypeUD);

                        oTransTypeUD = new TransTypeUD();
                        oTransTypeUD.AccountNo = (AccountTable.Where(x => x.ID == oAccountingDefinitions.BankExpenseAccount).FirstOrDefault().AccountNo).ToString();
                        oTransTypeUD.TranTypeNo = Convert.ToInt64(SettingAccounts.PaymentVoucherId);
                        oTransTypeUD.CurrencyID = oBranch.CurrencyIDH;
                        oTransTypeUD.CAmount = BankCommission;
                        oTransTypeUD.HeaderNotes = PoSales.Payments.Note;
                        oTransTypeUD.TranDate = DateTime.Now;
                        oTransTypeUD.CreateDate = DateTime.Now;
                        oTransTypeUD.UserName = SessionManager.GetSessionUserInfo.UserID.ToString();
                        oTransTypeUD.CostsCentersNo = 0;
                        oTransTypeUD.Notes = PoSales.Payments.Note;
                        oLTransTypeUD.Add(oTransTypeUD);

                        oTransTypeUD = new TransTypeUD();
                        oTransTypeUD.AccountNo = (AccountTable.Where(x => x.ID == PaymentAccountNo).FirstOrDefault().AccountNo).ToString();
                        oTransTypeUD.TranTypeNo = Convert.ToInt64(SettingAccounts.PaymentVoucherId);
                        oTransTypeUD.CurrencyID = oBranch.CurrencyIDH;
                        oTransTypeUD.DAmount = tax;
                        oTransTypeUD.HeaderNotes = PoSales.Payments.Note;
                        oTransTypeUD.TranDate = DateTime.Now;
                        oTransTypeUD.CreateDate = DateTime.Now;
                        oTransTypeUD.UserName = SessionManager.GetSessionUserInfo.UserID.ToString();
                        oTransTypeUD.CostsCentersNo = 0;
                        oTransTypeUD.Notes = PoSales.Payments.Note;
                        oLTransTypeUD.Add(oTransTypeUD);

                        oTransTypeUD = new TransTypeUD();
                        oTransTypeUD.AccountNo = (AccountTable.Where(x => x.ID == oAccountingDefinitions.TaxAccount).FirstOrDefault().AccountNo).ToString();
                        oTransTypeUD.TranTypeNo = Convert.ToInt64(SettingAccounts.PaymentVoucherId);
                        oTransTypeUD.CurrencyID = oBranch.CurrencyIDH;
                        oTransTypeUD.CAmount = tax;
                        oTransTypeUD.HeaderNotes = PoSales.Payments.Note;
                        oTransTypeUD.TranDate = DateTime.Now;
                        oTransTypeUD.CreateDate = DateTime.Now;
                        oTransTypeUD.UserName = SessionManager.GetSessionUserInfo.UserID.ToString();
                        oTransTypeUD.CostsCentersNo = 0;
                        oTransTypeUD.Notes = PoSales.Payments.Note;
                        oLTransTypeUD.Add(oTransTypeUD);

                    }

                    Transactions = new Transactions();
                    Transactions.oLTransTypeUD = oLTransTypeUD;
                    Transactions.CompanyId = CompanyId;
                    Transactions.BranchId = BranchId;
                    Transactions.UserID = Models.SessionManager.GetSessionUserInfo.UserID;
                    Transactions.VoucherType = 2;
                    Transactions.oLReceiptChequeUD = new List<ReceiptChequeUD>();
                    Transactions.oLReceiptChequeUD.Add(new ReceiptChequeUD
                    {
                        TranNo = 0,
                        TranTypeNo = 0,
                        TranDate =DateTime.Now,
                        Branch = BranchId,
                        ReceivedFrom = "",
                        DelegateID = 0,
                        Date = DateTime.Now,
                        Indicator ="",
                        Total = PoSales.Grand_total,
                        IsChash = !string.IsNullOrEmpty(PoSales.Payments.Cheque_no) ? 0 : 1,
                        ChequeNumber = PoSales.Payments.Cheque_no,
                        ChequeDate = Convert.ToDateTime(PoSales.Payments.DateCheque) != DateTime.MinValue ? Convert.ToDateTime(PoSales.Payments.DateCheque) : DateTime.Now,
                        ChequeBank = PoSales.Payments.ChequeBanks.ToString(),
                        DescriptionCode = ""
                    });

                    Response response1 = APICall.Post<Response>(string.Format("{0}/Transaction/PostTransaction", (object)ConfigurationManager.AppSettings["APIURL"]), authorization.TokenType, authorization.AccessToken, Transactions);
                    if (response1.IsScusses)
                    {
                        var oTransTable1 = JsonConvert.DeserializeObject<List<TransTable>>(JsonConvert.SerializeObject(response1.ResponseDetails));
                        TransTable transTable = new TransTable()
                        {
                            TranNo = oTransTable1.FirstOrDefault().TranNo,
                            TranTypeNo = Convert.ToInt64(SettingAccounts.PaymentVoucherId),
                            Notes = "",
                            CreateDate = DateTime.Now,
                            CostsCentersNo = 0,
                            CurrencyID = oBranch.CurrencyIDH,
                            ExpensesType = SettingAccounts.ExpensesTypeId,
                            PaymentMethod = int.Parse(PoSales.Status),
                            Branch = BranchId,
                            GregorianTransDate = DateTime.Now,
                            ishijriTran = false,
                            Payfor = "",
                            Indicator = "",
                            DescriptionCode = "",
                            ChequeNumber = PoSales.Payments.Cheque_no,
                            ChequeBank = PoSales.Payments.ChequeBanks == null ? 0 : Convert.ToInt32(PoSales.Payments.ChequeBanks),
                            GregorianChequebankDate = PoSales.Payments.DateCheque,
                            ishijriChequebank = false,
                            Total = PoSales.Grand_total,
                            CreatedBy = SessionManager.GetSessionUserInfo.UserID,
                            CompanyId = CompanyId,
                            PlateNumber = PoSales.Vehicle_id,
                            PaymentType = 2,
                            VoucherType = 2,
                            IsWorkShop = true
                        };
                        Response responsePaymentVoucher = APICall.Post<Response>(string.Format("{0}/Voucher/PaymentVoucher_Insert", (object)ConfigurationManager.AppSettings["VehicleAPIURL"]), vehicleAuthorization.TokenType, vehicleAuthorization.AccessToken, transTable);
                        if (responsePaymentVoucher.IsScusses)
                        {
                            result.Data = oSalesDBL.M_Store_Insert(PoSales);
                            var userId = SessionManager.GetSessionUserInfo.UserID;
                            foreach (var item in PoSales.Tasks)
                            {
                                item.FromUserId = userId;
                                item.Status = 1;
                                item.CompanyId = CompanyId;
                                item.BranchId = BranchId;
                                item.Type = 2;
                                item.RelatedId = ((Sales)result.Data).Id;
                                //item.ToUserId = item;
                                oSalesDBL.D_Task_Insert(item);
                            }
                            oSuspendedSaleDBL.M_SuspendedSale_Delete(PoSales.Hold_Id);
                        }
                    }
                }
                else
                {
                    result.Data = oSalesDBL.M_Store_Insert(PoSales);
                    oSuspendedSaleDBL.M_SuspendedSale_Delete(PoSales.Hold_Id);
                }
                return Json(result);
            }
            catch(Exception ex)
            {
                result.IsSuccess = false;
                return Json(result);
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="PoSales"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update(Sales PoSales)
        {
            result = new ResultJson();
            int CompanyId = ((POCO.CompanyInfo)Session["CompanyInfo"]).Id;
            int BranchId = ((POCO.CompanyBranch)Session["BranchInfo"]).BranchID;
            try
            {
                oSalesDBL = new SalesDBL();
                result.IsSuccess = true;
                PoSales.Updated_by = SessionManager.GetSessionUserInfo.UserID;
                PoSales.Updated_at = DateTime.Now;
                PoSales.Store_id = BranchId;
                result.Data = oSalesDBL.M_Store_Update(PoSales);
                return Json(result);

            }
            catch
            {
                result.IsSuccess = false;
                return Json(result);
            }
        }

        [HttpPost]
        public ActionResult AddPayment(Payments PoPayment)
        {
            result = new ResultJson();
            int CompanyId = ((POCO.CompanyInfo)Session["CompanyInfo"]).Id;
            int BranchId = ((POCO.CompanyBranch)Session["BranchInfo"]).BranchID;
            try
            {
                oSalesDBL = new SalesDBL();
                result.IsSuccess = true;
                PoPayment.Created_by = SessionManager.GetSessionUserInfo.UserID;
                PoPayment.Date = DateTime.Now;
                PoPayment.Store_id = BranchId;
                result.Data = oSalesDBL.M_Payment_Insert(PoPayment);
                return Json(result);

            }
            catch
            {
                result.IsSuccess = false;
                return Json(result);
            }
        }
    }
}