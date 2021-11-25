using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class GiftCardDAL : Database
    {
        /// <summary>
        /// M_GiftCards_GetAll
        /// </summary>
        /// <returns></returns>
        public DataSet M_GiftCards_GetAll()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "M_POS_GiftCards_GetAll";

            return ExDataBase_returnDataSet(cmd);
        }

        /// <summary>
        /// M_GiftCards_GetById
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public DataSet M_GiftCards_GetById(int Id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "M_POS_GiftCards_GetById";
            cmd.Parameters.AddWithValue("@Id", Id);
            return ExDataBase_returnDataSet(cmd);
        }

        /// <summary>
        /// M_GiftCards_Update
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Card_no"></param>
        /// <param name="Value"></param>
        /// <param name="Customer_id"></param>
        /// <param name="Balance"></param>
        /// <param name="Expiry"></param>
        /// <param name="Store_id"></param>
        /// <returns></returns>
        public DataSet M_GiftCards_Update(int Id, string Card_no, decimal Value, int? Customer_id, decimal Balance, DateTime? Expiry,
            int Store_id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "M_POS_GiftCards_Update";
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@Card_no", Card_no);
            cmd.Parameters.AddWithValue("@Value", Value);
            cmd.Parameters.AddWithValue("@Customer_id", Customer_id);
            cmd.Parameters.AddWithValue("@Balance", Balance);
            cmd.Parameters.AddWithValue("@Expiry", Expiry);
            cmd.Parameters.AddWithValue("@Store_id", Store_id);

            return ExDataBase_returnDataSet(cmd);
        }


        /// <summary>
        /// M_GiftCards_Insert
        /// </summary>
        /// <param name="Card_no"></param>
        /// <param name="Value"></param>
        /// <param name="Customer_id"></param>
        /// <param name="Balance"></param>
        /// <param name="Expiry"></param>
        /// <param name="Created_by"></param>
        /// <param name="Store_id"></param>
        /// <returns></returns>
        public DataSet M_GiftCards_Insert(string Card_no, decimal Value, int? Customer_id, decimal Balance, DateTime? Expiry, int Created_by,
            int Store_id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "M_POS_GiftCards_Insert";
            cmd.Parameters.AddWithValue("@Card_no", Card_no);
            cmd.Parameters.AddWithValue("@Value", Value);
            cmd.Parameters.AddWithValue("@Customer_id", Customer_id);
            cmd.Parameters.AddWithValue("@Balance", Balance);
            cmd.Parameters.AddWithValue("@Expiry", Expiry);
            cmd.Parameters.AddWithValue("@Created_by", Created_by);
            cmd.Parameters.AddWithValue("@Store_id", Store_id);

            return ExDataBase_returnDataSet(cmd);
        }

        /// <summary>
        /// M_GiftCards_Delete
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public DataSet M_GiftCards_Delete(int Id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "M_POS_GiftCards_Delete";
            cmd.Parameters.AddWithValue("@Id", Id);
            return ExDataBase_returnDataSet(cmd);
        }


        /// <summary>
        /// M_GiftCards_GetByCardNo
        /// </summary>
        /// <param name="CardNo"></param>
        /// <returns></returns>
        public DataSet M_GiftCards_GetByCardNo(string CardNo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "M_POS_GiftCards_GetByCardNo";
            cmd.Parameters.AddWithValue("@CardNo" , CardNo);
            return ExDataBase_returnDataSet(cmd);
        }
    }
}
