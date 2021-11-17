﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RegistersDAL : Database
    {
        /// <summary>
        /// M_Register_OpenRegister
        /// </summary>
        /// <param name="Date"></param>
        /// <param name="Cash_in_hand"></param>
        /// <param name="UserId"></param>
        /// <param name="Store_id"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public DataSet M_Register_OpenRegister(DateTime Date, decimal Cash_in_hand,int UserId, int Store_id, string Status)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "M_POS_Register_OpenRegister";
            cmd.Parameters.AddWithValue("@Date", Date);
            cmd.Parameters.AddWithValue("@Cash_in_hand", Cash_in_hand);
            cmd.Parameters.AddWithValue("@UserId", UserId);
            cmd.Parameters.AddWithValue("@Store_id", Store_id);
            cmd.Parameters.AddWithValue("@Status", Status);

            return ExDataBase_returnDataSet(cmd);
        }

    }
}
