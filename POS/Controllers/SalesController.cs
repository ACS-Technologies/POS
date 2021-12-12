using DBL;
using POCO;
using POS.Models;
using System;
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
        public ActionResult GetById(int Id)
        {
            result = new ResultJson();

            try
            {
                oSalesDBL = new SalesDBL();
                result.IsSuccess = true;
                result.Data = oSalesDBL.M_Sales_GetById(Id);
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
            result = new ResultJson();
            var oSuspendedSaleDBL = new SuspendedSaleDBL();
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
                if (PoSales.Payments.DateTemp !=null)
                {
                    PoSales.Payments.DateCheque = Convert.ToDateTime(PoSales.Payments.DateTemp);
                }

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