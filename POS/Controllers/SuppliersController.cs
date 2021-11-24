using DBL;
using POCO;
using POS.Models;
using System;
using System.Web.Mvc;

namespace POS.Controllers
{
    public class SuppliersController : BaseController
    {
        SupplierDBL oSupplierDBL;
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
                oSupplierDBL = new SupplierDBL();
                result.IsSuccess = true;
                result.Data = oSupplierDBL.M_Suppliers_GetById(Id);
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
                oSupplierDBL = new SupplierDBL();
                result.IsSuccess = true;
                result.Data = oSupplierDBL.M_Suppliers_GetAll();
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
                oSupplierDBL = new SupplierDBL();
                oSupplierDBL.M_Suppliers_Delete(Id);
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
        /// <param name="PoSuppliers"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Insert(Supplier PoSuppliers)
        {
            result = new ResultJson();

            try
            {
                oSupplierDBL = new SupplierDBL();
                result.IsSuccess = true;
                result.Data = oSupplierDBL.M_Store_Insert(PoSuppliers);
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
        /// <param name="PoSuppliers"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update(Supplier PoSuppliers)
        {
            result = new ResultJson();

            try
            {
                oSupplierDBL = new SupplierDBL();
                result.IsSuccess = true;
                result.Data = oSupplierDBL.M_Store_Update(PoSuppliers);
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