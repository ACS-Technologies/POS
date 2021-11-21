using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class StoreDAL : Database
    {
        /// <summary>
        /// M_Store_GetAll
        /// </summary>
        /// <returns></returns>
        public DataSet M_Store_GetAll()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "M_POS_Store_GetAll";
            return ExDataBase_returnDataSet(cmd);
        }

        /// <summary>
        /// M_Store_GetById
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public DataSet M_Store_GetById(int Id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "M_POS_Store_GetById";
            cmd.Parameters.AddWithValue("@Id", Id);
            return ExDataBase_returnDataSet(cmd);
        }

        /// <summary>
        /// M_Store_Update
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Name"></param>
        /// <param name="Code"></param>
        /// <param name="Logo"></param>
        /// <param name="Email"></param>
        /// <param name="Phone"></param>
        /// <param name="Address1"></param>
        /// <param name="Address2"></param>
        /// <param name="City"></param>
        /// <param name="State"></param>
        /// <param name="Postal_code"></param>
        /// <param name="Country"></param>
        /// <param name="Currency_code"></param>
        /// <param name="Receipt_header"></param>
        /// <param name="Receipt_footer"></param>
        /// <returns></returns>
        public DataSet M_Store_Update(int Id, string Name, string Code, string Logo, string Email, string Phone, string Address1, string Address2, string City,
                string State, string Postal_code, string Country, string Currency_code, string Receipt_header, string Receipt_footer)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "M_POS_Store_Update";
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Code", Code);
            cmd.Parameters.AddWithValue("@Logo", Logo);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Phone", Phone);
            cmd.Parameters.AddWithValue("@Address1", Address1);
            cmd.Parameters.AddWithValue("@Address2", Address2);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@State", State);
            cmd.Parameters.AddWithValue("@Postal_code", Postal_code);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@Currency_code", Currency_code);
            cmd.Parameters.AddWithValue("@Receipt_header", Receipt_header);
            cmd.Parameters.AddWithValue("@Receipt_footer", Receipt_footer);
            return ExDataBase_returnDataSet(cmd);
        }

        /// <summary>
        /// M_Store_Insert
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Code"></param>
        /// <param name="Logo"></param>
        /// <param name="Email"></param>
        /// <param name="Phone"></param>
        /// <param name="Address1"></param>
        /// <param name="Address2"></param>
        /// <param name="City"></param>
        /// <param name="State"></param>
        /// <param name="Postal_code"></param>
        /// <param name="Country"></param>
        /// <param name="Currency_code"></param>
        /// <param name="Receipt_header"></param>
        /// <param name="Receipt_footer"></param>
        /// <returns></returns>
        public DataSet M_Store_Insert(string Name, string Code, string Logo, string Email, string Phone, string Address1, string Address2, string City,
                string State, string Postal_code, string Country, string Currency_code, string Receipt_header, string Receipt_footer)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "M_POS_Store_Insert";
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Code", Code);
            cmd.Parameters.AddWithValue("@Logo", Logo);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Phone", Phone);
            cmd.Parameters.AddWithValue("@Address1", Address1);
            cmd.Parameters.AddWithValue("@Address2", Address2);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@State", State);
            cmd.Parameters.AddWithValue("@Postal_code", Postal_code);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@Currency_code", Currency_code);
            cmd.Parameters.AddWithValue("@Receipt_header", Receipt_header);
            cmd.Parameters.AddWithValue("@Receipt_footer", Receipt_footer);


            return ExDataBase_returnDataSet(cmd);
        }

        /// <summary>
        /// M_Store_Delete
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public DataSet M_Store_Delete(int Id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "M_POS_Store_Delete";
            cmd.Parameters.AddWithValue("@Id", Id);
            return ExDataBase_returnDataSet(cmd);
        }
    }
}
