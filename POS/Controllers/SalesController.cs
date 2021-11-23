using DBL;
using POCO;
using POS.Models;
using System;
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

            try
            {
                oSalesDBL = new SalesDBL();
                result.IsSuccess = true;
                PoSales.Created_by = SessionManager.GetSessionUserInfo.UserID;
                PoSales.Date = DateTime.Now;
                result.Data = oSalesDBL.M_Store_Insert(PoSales);
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

            try
            {
                oSalesDBL = new SalesDBL();
                result.IsSuccess = true;
                PoSales.Updated_by = SessionManager.GetSessionUserInfo.UserID;
                PoSales.Updated_at = DateTime.Now;
                result.Data = oSalesDBL.M_Store_Update(PoSales);
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