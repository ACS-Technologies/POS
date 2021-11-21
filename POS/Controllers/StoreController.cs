using DBL;
using POCO;
using POS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace POS.Controllers
{
    public class StoreController : BaseController
    {
        StoreDBL oStoreDBL;
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
                oStoreDBL = new StoreDBL();
                result.IsSuccess = true;
                result.Data = oStoreDBL.M_Store_GetById(Id);
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
                oStoreDBL = new StoreDBL();
                result.IsSuccess = true;
                List<Store> stores = oStoreDBL.M_Store_GetAll();
                result.DataList = stores.Select(item => (object)item).ToList();
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
                oStoreDBL = new StoreDBL();
                oStoreDBL.M_Store_Delete(Id);
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
        /// <param name="PoStore"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Insert(Store PoStore)
        {
            result = new ResultJson();

            try
            {
                oStoreDBL = new StoreDBL();
                result.IsSuccess = true;
                result.Data = oStoreDBL.M_Store_Insert(PoStore);
                return Json(result);

            }
            catch
            {
                result.IsSuccess = false;
                return Json(result);
            }
        }

        /// <summary>
        /// Update 
        /// </summary>
        /// <param name="PoStore"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update(Store PoStore)
        {
            result = new ResultJson();

            try
            {
                oStoreDBL = new StoreDBL();
                result.IsSuccess = true;
                result.Data = oStoreDBL.M_Store_Update(PoStore);
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