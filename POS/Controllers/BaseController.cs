using System;
using System.Web.Mvc;
using POS.Models;

namespace POS.Controllers
{
    public class BaseController : Controller
    {
        #region Actions       
        //protected override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    try
        //    {

        //        var userId = SessionManager.GetSessionUserInfo.UserID;

        //        // If session exists
        //        if (filterContext.HttpContext.Session["UserInfo"] == null || userId == 0)
        //        {
        //            //redirect to desired session
        //            //expiration action and controller
        //            filterContext.Result = this.Redirect("~/Authentication/Index?BURL=" + HttpContext.Request.Path);
        //            return;
        //        }

        //        if(filterContext.HttpContext.Session["UserInfo"] != null )
        //        {
        //            if(SessionManager.GetSessionUserInfo.StoreId == 0)
        //            {
        //                filterContext.Result = this.Redirect("~/Authentication/Index?BURL=" + HttpContext.Request.Path);
        //                return;
        //            }
        //        }
        //        //otherwise continue with action
        //        base.OnActionExecuting(filterContext);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        #endregion
    }
}
