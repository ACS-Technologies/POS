using DAL.Security;
using POCO.Security;
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace DBL.Security
{
  public class APICredentialDBL
    {
        private APICredentialDAL oAPICredentialDAL;
        private DataSet ds;
        public bool ValidateUser(string username, string password)
        {
            oAPICredentialDAL = new APICredentialDAL();

            try
            {
                ds = new DataSet();
                POCO.Security.APICredential oAPICredential = new POCO.Security.APICredential();
                ds = oAPICredentialDAL.Validate_APIUser(username, password);
                bool result = false;
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        result = Int32.Parse(ds.Tables[0].Rows[0]["IsValidate"].ToString()) == 1 ? true:false;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
         
  }
}
