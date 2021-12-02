using DBL;
using POCO;
using POS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace POS.Controllers
{
    public class SettingsController : BaseController
    {
        SettingsDBL oSettingsDBL;
        ResultJson result;
        public ActionResult Index()
        {
            result = new ResultJson();

            try
            {
                int BranchId = SessionManager.GetSessionUserInfo.CompanyBranchId;
                oSettingsDBL = new SettingsDBL();
                result.IsSuccess = true;
                result.Data = oSettingsDBL.M_Settings_GetByBranchId(BranchId);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                result.IsSuccess = false;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// GetByBranchId
        /// </summary>
        /// <returns></returns>
        public ActionResult GetByBranchId()
        {
            result = new ResultJson();

            try
            {
                int BranchId = SessionManager.GetSessionUserInfo.CompanyBranchId;
                oSettingsDBL = new SettingsDBL();
                result.IsSuccess = true;
                result.Data = oSettingsDBL.M_Settings_GetByBranchId(BranchId);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                result.IsSuccess = false;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }


        /// <summary>
        /// InsertOrUpdate
        /// </summary>
        /// <param name="PoSettings"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult InsertOrUpdate(Settings PoSettings)
        {
            result = new ResultJson();

            try
            {
                oSettingsDBL = new SettingsDBL();
                result.IsSuccess = true;
                result.Data = oSettingsDBL.M_Settings_InsertOrUpdate(PoSettings);
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