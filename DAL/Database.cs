using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Database
    {
        private string connetionString = null;
        private SqlConnection connection;
        private SqlCommand command;
        public DataSet ExDataBase_returnDataSet(SqlCommand cmd)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();

            connetionString = ConfigurationManager.AppSettings["con"].ToString();


            connection = new SqlConnection(connetionString);

            try
            {
                connection.Open();
                command = new SqlCommand();
                command = cmd;
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand = command;
                adapter.Fill(ds);
                adapter.Dispose();
                command.Dispose();
                connection.Close();


                return ds;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return ds;
        }

        public void ExDataBase_nonQuery(SqlCommand cmd)
        {
            connetionString = ConfigurationManager.AppSettings["con"].ToString();


            connection = new SqlConnection(connetionString);

            try
            {
                connection.Open();
                command = new SqlCommand();
                command = cmd;
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

    }
}
