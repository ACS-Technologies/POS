using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Security
{
    public class APICredentialDAL : Database
    {
        private SqlCommand cmd;
        public DataSet Validate_APIUser(string username, string password)
        {

            cmd = new SqlCommand();
            cmd.CommandText = "D_ValidateAPIUser";
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            return ExDataBase_returnDataSet(cmd);
        }
    }
}
