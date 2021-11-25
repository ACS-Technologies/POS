﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class SalesDAL : Database
    {
        /// <summary>
        /// M_Sales_GetAll
        /// </summary>
        /// <returns></returns>
        public DataSet M_Sales_GetAll(int? UserId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "M_POS_Sales_GetAll";
            cmd.Parameters.AddWithValue("@UserId", UserId);

            return ExDataBase_returnDataSet(cmd);
        }

        /// <summary>
        /// M_Sales_GetById
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public DataSet M_Sales_GetById(int Id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "M_POS_Sales_GetById";
            cmd.Parameters.AddWithValue("@Id", Id);
            return ExDataBase_returnDataSet(cmd);
        }

        /// <summary>
        /// M_Sales_Update
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Updated_at"></param>
        /// <param name="Customer_id"></param>
        /// <param name="Customer_name"></param>
        /// <param name="Total"></param>
        /// <param name="Product_discount"></param>
        /// <param name="Order_discount_id"></param>
        /// <param name="Order_discount"></param>
        /// <param name="Total_discount"></param>
        /// <param name="Product_tax"></param>
        /// <param name="Order_tax_id"></param>
        /// <param name="Order_tax"></param>
        /// <param name="Total_tax"></param>
        /// <param name="Grand_total"></param>
        /// <param name="Total_items"></param>
        /// <param name="Total_quantity"></param>
        /// <param name="Paid"></param>
        /// <param name="Updated_by"></param>
        /// <param name="Note"></param>
        /// <param name="Status"></param>
        /// <param name="Rounding"></param>
        /// <param name="Store_id"></param>
        /// <param name="Hold_ref"></param>
        /// <returns></returns>
        public DataSet M_Sales_Update(int Id, DateTime? Updated_at, int Customer_id, string Customer_name, decimal Total, decimal? Product_discount, string Order_discount_id, decimal? Order_discount,
            decimal? Total_discount, decimal? Product_tax, string Order_tax_id, decimal Order_tax, decimal? Total_tax, decimal Grand_total, int? Total_items, decimal? Total_quantity,
            decimal? Paid, int? Updated_by, string Note, string Status, decimal? Rounding, int Store_id, string Hold_ref, DataTable SaleItems)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "M_POS_Sales_Update";
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@Updated_at", Updated_at);
            cmd.Parameters.AddWithValue("@Customer_id", Customer_id);
            cmd.Parameters.AddWithValue("@Customer_name", Customer_name);
            cmd.Parameters.AddWithValue("@Total", Total);
            cmd.Parameters.AddWithValue("@Product_discount", Product_discount);
            cmd.Parameters.AddWithValue("@Order_discount_id", Order_discount_id);
            cmd.Parameters.AddWithValue("@Order_discount", Order_discount);
            cmd.Parameters.AddWithValue("@Total_discount", Total_discount);
            cmd.Parameters.AddWithValue("@Product_tax", Product_tax);
            cmd.Parameters.AddWithValue("@Order_tax_id", Order_tax_id);
            cmd.Parameters.AddWithValue("@Order_tax", Order_tax);
            cmd.Parameters.AddWithValue("@Total_tax", Total_tax);
            cmd.Parameters.AddWithValue("@Grand_total", Grand_total);
            cmd.Parameters.AddWithValue("@Total_items", Total_items);
            cmd.Parameters.AddWithValue("@Total_quantity", Total_quantity);
            cmd.Parameters.AddWithValue("@Paid", Paid);
            cmd.Parameters.AddWithValue("@Updated_by", Updated_by);
            cmd.Parameters.AddWithValue("@Note", Note);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@Rounding", Rounding);
            cmd.Parameters.AddWithValue("@Store_id", Store_id);
            cmd.Parameters.AddWithValue("@Hold_ref", Hold_ref);
            cmd.Parameters.AddWithValue("@SaleItemsType", SaleItems);

            return ExDataBase_returnDataSet(cmd);
        }

        /// <summary>
        /// M_Sales_Insert
        /// </summary>
        /// <param name="Date"></param>
        /// <param name="Customer_id"></param>
        /// <param name="Customer_name"></param>
        /// <param name="Total"></param>
        /// <param name="Product_discount"></param>
        /// <param name="Order_discount_id"></param>
        /// <param name="Order_discount"></param>
        /// <param name="Total_discount"></param>
        /// <param name="Product_tax"></param>
        /// <param name="Order_tax_id"></param>
        /// <param name="Order_tax"></param>
        /// <param name="Total_tax"></param>
        /// <param name="Grand_total"></param>
        /// <param name="Total_items"></param>
        /// <param name="Total_quantity"></param>
        /// <param name="Paid"></param>
        /// <param name="Created_by"></param>
        /// <param name="Note"></param>
        /// <param name="Status"></param>
        /// <param name="Rounding"></param>
        /// <param name="Store_id"></param>
        /// <param name="Hold_ref"></param>
        /// <returns></returns>
        public DataSet M_Sales_Insert(DateTime Date, int Customer_id, string Customer_name, decimal Total, decimal? Product_discount, string Order_discount_id, decimal? Order_discount,
            decimal? Total_discount, decimal? Product_tax, string Order_tax_id, decimal Order_tax, decimal? Total_tax, decimal Grand_total, int? Total_items, decimal? Total_quantity,
            decimal? Paid, int? Created_by, string Note, string Status, decimal? Rounding, int Store_id, string Hold_ref, DataTable SaleItems)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "M_POS_Sales_Insert";
            cmd.Parameters.AddWithValue("@Date", DateTime.Now/*Date*/);
            cmd.Parameters.AddWithValue("@Customer_id", Customer_id);
            cmd.Parameters.AddWithValue("@Customer_name", Customer_name);
            cmd.Parameters.AddWithValue("@Total", Total);
            cmd.Parameters.AddWithValue("@Product_discount", Product_discount);
            cmd.Parameters.AddWithValue("@Order_discount_id", Order_discount_id);
            cmd.Parameters.AddWithValue("@Order_discount", Order_discount);
            cmd.Parameters.AddWithValue("@Total_discount", Total_discount);
            cmd.Parameters.AddWithValue("@Product_tax", Product_tax);
            cmd.Parameters.AddWithValue("@Order_tax_id", Order_tax_id);
            cmd.Parameters.AddWithValue("@Order_tax", Order_tax);
            cmd.Parameters.AddWithValue("@Total_tax", Total_tax);
            cmd.Parameters.AddWithValue("@Grand_total", Grand_total);
            cmd.Parameters.AddWithValue("@Total_items", Total_items);
            cmd.Parameters.AddWithValue("@Total_quantity", Total_quantity);
            cmd.Parameters.AddWithValue("@Paid", Paid);
            cmd.Parameters.AddWithValue("@Created_by", Created_by);
            cmd.Parameters.AddWithValue("@Note", Note);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@Rounding", Rounding);
            cmd.Parameters.AddWithValue("@Store_id", Store_id);
            cmd.Parameters.AddWithValue("@Hold_ref", Hold_ref);
            cmd.Parameters.AddWithValue("@SaleItemsType", SaleItems);

            return ExDataBase_returnDataSet(cmd);
        }

        /// <summary>
        /// M_Sales_Delete
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public DataSet M_Sales_Delete(int Id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "M_POS_Sales_Delete";
            cmd.Parameters.AddWithValue("@Id", Id);
            return ExDataBase_returnDataSet(cmd);
        }
    }
}
