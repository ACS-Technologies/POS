using POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace POS.Models
{
    public static class SessionManager
    {
        public static User GetSessionUserInfo
        {
            get
            {
                //store the object in session if not already stored
                if (HttpContext.Current.Session["UserInfo"] == null)
                    HttpContext.Current.Session["UserInfo"] = new User();

                //return the object from session
                return (User)HttpContext.Current.Session["UserInfo"];
            }
        }


        public static User SetSessionUserInfo
        {
            set
            {
                HttpContext.Current.Session["UserInfo"] = value;
            }
        }
        public static CompanyInfo GetSessionCompanyInfo
        {
            get
            {
                //store the object in session if not already stored
                if (HttpContext.Current.Session["CompanyInfo"] == null)
                    HttpContext.Current.Session["CompanyInfo"] = new CompanyInfo();

                //return the object from session
                return (CompanyInfo)HttpContext.Current.Session["CompanyInfo"];
            }
        }

    }
}