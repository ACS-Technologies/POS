﻿using DBL;
using POCO;
using POS.Models;
using System;
using System.Web.Mvc;

namespace POS.Controllers
{
    public class SuspendedSuspendedSaleController : BaseController
    {
        SuspendedSaleDBL oSuspendedSaleDBL;
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
                oSuspendedSaleDBL = new SuspendedSaleDBL();
                result.IsSuccess = true;
                result.Data = oSuspendedSaleDBL.M_SuspendedSale_GetById(Id);
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
                int userId = SessionManager.GetSessionUserInfo.UserID;
                oSuspendedSaleDBL = new SuspendedSaleDBL();
                result.IsSuccess = true;
                result.Data = oSuspendedSaleDBL.M_SuspendedSale_GetAll(userId);
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
                oSuspendedSaleDBL = new SuspendedSaleDBL();
                oSuspendedSaleDBL.M_SuspendedSale_Delete(Id);
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
        /// <param name="PoSuspendedSale"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Insert(SuspendedSale PoSuspendedSale)
        {
            result = new ResultJson();

            try
            {
                oSuspendedSaleDBL = new SuspendedSaleDBL();
                result.IsSuccess = true;
                PoSuspendedSale.Created_by = SessionManager.GetSessionUserInfo.UserID;
                PoSuspendedSale.Date = DateTime.Now;
                result.Data = oSuspendedSaleDBL.M_Store_Insert(PoSuspendedSale);
                return Json(result);

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                return Json(result);
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="PoSuspendedSale"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update(SuspendedSale PoSuspendedSale)
        {
            result = new ResultJson();

            try
            {
                oSuspendedSaleDBL = new SuspendedSaleDBL();
                result.IsSuccess = true;
                PoSuspendedSale.Updated_by = SessionManager.GetSessionUserInfo.UserID;
                PoSuspendedSale.Updated_at = DateTime.Now;
                result.Data = oSuspendedSaleDBL.M_Store_Update(PoSuspendedSale);
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