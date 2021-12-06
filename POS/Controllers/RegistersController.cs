using DBL;
using POCO;
using POS.Models;
using System;
using System.Collections.Generic;
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