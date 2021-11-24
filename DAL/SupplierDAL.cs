using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class SupplierDAL : Database
    {
        /// <summary>
        /// M_Suppliers_GetAll
        /// </summary>
        /// <returns></returns>
        public DataSet M_Suppliers_GetAll()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "M_POS_Suppliers_GetAll";

            return ExDataBase_returnDataSet(cmd);
        }

        /// <summary>
        /// M_Suppliers_GetById
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public DataSet M_Suppliers_GetById(int Id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "M_POS_Suppliers_GetById";
            cmd.Parameters.AddWithValue("@Id", Id);
            return ExDataBase_returnDataSet(cmd);
        }

        /// <summary>
        /// M_Suppliers_Update
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Name"></param>
        /// <param name="Cf1"></param>
        /// <param name="Cf2"></param>
        /// <param name="Phone"></param>
        /// <param name="Email"></param>
        /// <returns></returns>
        public DataSet M_Suppliers_Update(int Id, string Name, string Cf1, string Cf2, string Phone, string Email)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "M_POS_Suppliers_Update";
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Cf1", Cf1);
            cmd.Parameters.AddWithValue("@Cf2", Cf2);
            cmd.Parameters.AddWithValue("@Phone", Phone);
            cmd.Parameters.AddWithValue("@Email", Email);

            return ExDataBase_returnDataSet(cmd);
        }


        /// <summary>
        /// M_Suppliers_Insert
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Cf1"></param>
        /// <param name="Cf2"></param>
        /// <param name="Phone"></param>
        /// <param name="Email"></param>
        /// <returns></returns>
        public DataSet M_Suppliers_Insert(string Name, string Cf1, string Cf2, string Phone, string Email)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "M_POS_Suppliers_Insert";
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Cf1", Cf1);
            cmd.Parameters.AddWithValue("@Cf2", Cf2);
            cmd.Parameters.AddWithValue("@Phone", Phone);
            cmd.Parameters.AddWithValue("@Email", Email);

            return ExDataBase_returnDataSet(cmd);
        }

        /// <summary>
        /// M_Suppliers_Delete
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public DataSet M_Suppliers_Delete(int Id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "M_POS_Suppliers_Delete";
            cmd.Parameters.AddWithValue("@Id", Id);
            return ExDataBase_returnDataSet(cmd);
        }

    }
}
