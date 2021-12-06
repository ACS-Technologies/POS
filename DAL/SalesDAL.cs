using System;
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
        public DataSet M_Sales_GetAll(int? UserId,DateTime Date)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "M_POS_Sales_GetAll";
            cmd.Parameters.AddWithValue("@UserId", UserId);
            cmd.Parameters.AddWithValue("@Date", Date);
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
            decimal? Paid, int? Updated_by, string Note, string Status, decimal? Rounding, int Store_id, string Hold_ref, DataTable SaleItems,
            decimal Amount, int paid_by, string cheque_no, string cc_no, string gc_no, string cc_holder, string cc_month, string cc_year, string cc_type,
            string paymentNote, decimal? pos_paid, decimal? pos_balance, int ?ChequeBanks,DateTime? DateCheque)
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
            cmd.Parameters.AddWithValue("@Amount", Amount);
            cmd.Parameters.AddWithValue("@Paid_by", paid_by);
            cmd.Parameters.AddWithValue("@Cheque_no", cheque_no);
            cmd.Parameters.AddWithValue("@Cc_no", cc_no);
            cmd.Parameters.AddWithValue("@Gc_no", gc_no);
            cmd.Parameters.AddWithValue("@Cc_holder", cc_holder);
            cmd.Parameters.AddWithValue("@Cc_month", cc_month);
            cmd.Parameters.AddWithValue("@Cc_year", cc_year);
            cmd.Parameters.AddWithValue("@Cc_type", cc_type);
            cmd.Parameters.AddWithValue("@PaymentNote", paymentNote);
            cmd.Parameters.AddWithValue("@Pos_paid", pos_paid);
            cmd.Parameters.AddWithValue("@Pos_balance", pos_balance);
            cmd.Parameters.AddWithValue("@ChequeBanks", ChequeBanks);
            cmd.Parameters.AddWithValue("@DateCheque", DateCheque);
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
        /// <param name="SaleItems"></param>
        /// <param name="Amount"></param>
        /// <param name="paid_by"></param>
        /// <param name="cheque_no"></param>
        /// <param name="cc_no"></param>
        /// <param name="gc_no"></param>
        /// <param name="cc_holder"></param>
        /// <param name="cc_month"></param>
        /// <param name="cc_year"></param>
        /// <param name="cc_type"></param>
        /// <param name="cc_cvv2"></param>
        /// <param name="paymentNote"></param>
        /// <param name="pos_paid"></param>
        /// <param name="pos_balance"></param>
        /// <returns></returns>
        public DataSet M_Sales_Insert(DateTime Date, int Customer_id, string Customer_name, decimal Total, decimal? Product_discount, string Order_discount_id, decimal? Order_discount,
            decimal? Total_discount, decimal? Product_tax, string Order_tax_id, decimal Order_tax, decimal? Total_tax, decimal Grand_total, int? Total_items, decimal? Total_quantity,
            decimal? Paid, int? Created_by, string Note, string Status, decimal? Rounding, int Store_id, string Hold_ref, DataTable SaleItems,
            decimal Amount, int paid_by, string cheque_no, string cc_no, string gc_no, string cc_holder, string cc_month, string cc_year, string cc_type,
            string paymentNote, decimal? pos_paid, decimal? pos_balance, int? ChequeBanks, DateTime? DateCheque)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "M_POS_Sales_Insert";
            cmd.Parameters.AddWithValue("@Date", Date);
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
            cmd.Parameters.AddWithValue("@Amount", Amount);
            cmd.Parameters.AddWithValue("@Paid_by", paid_by);
            cmd.Parameters.AddWithValue("@Cheque_no", cheque_no);
            cmd.Parameters.AddWithValue("@Cc_no", cc_no);
            cmd.Parameters.AddWithValue("@Gc_no", gc_no);
            cmd.Parameters.AddWithValue("@Cc_holder", cc_holder);
            cmd.Parameters.AddWithValue("@Cc_month", cc_month);
            cmd.Parameters.AddWithValue("@Cc_year", cc_year);
            cmd.Parameters.AddWithValue("@Cc_type", cc_type);
            cmd.Parameters.AddWithValue("@PaymentNote", paymentNote);
            cmd.Parameters.AddWithValue("@Pos_paid", pos_paid);
            cmd.Parameters.AddWithValue("@Pos_balance", pos_balance);
            cmd.Parameters.AddWithValue("@ChequeBanks", ChequeBanks);
            cmd.Parameters.AddWithValue("@DateCheque", DateCheque);
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

        #region Payments

        /// <summary>
        /// M_Payments_Insert
        /// </summary>
        /// <param name="Date"></param>
        /// <param name="Sale_id"></param>
        /// <param name="Customer_id"></param>
        /// <param name="Reference"></param>
        /// <param name="Amount"></param>
        /// <param name="paid_by"></param>
        /// <param name="cheque_no"></param>
        /// <param name="cc_no"></param>
        /// <param name="gc_no"></param>
        /// <param name="cc_holder"></param>
        /// <param name="cc_month"></param>
        /// <param name="cc_year"></param>
        /// <param name="cc_type"></param>
        /// <param name="Note"></param>
        /// <param name="Created_by"></param>
        /// <param name="Store_id"></param>
        /// <returns></returns>
        public DataSet M_Payments_Insert(DateTime Date, int? Sale_id, int? Customer_id, string Reference,
            decimal Amount, int paid_by, string cheque_no, string cc_no, string gc_no, string cc_holder, string cc_month, string cc_year, string cc_type,
            string Note, int? Created_by, int Store_id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "M_POS_Payments_Insert";
            cmd.Parameters.AddWithValue("@Date", Date);
            cmd.Parameters.AddWithValue("@Customer_id", Customer_id);
            cmd.Parameters.AddWithValue("@Sale_id", Sale_id);
            cmd.Parameters.AddWithValue("@Store_id", Store_id);
            cmd.Parameters.AddWithValue("@Amount", Amount);
            cmd.Parameters.AddWithValue("@Paid_by", paid_by);
            cmd.Parameters.AddWithValue("@Cheque_no", cheque_no);
            cmd.Parameters.AddWithValue("@Cc_no", cc_no);
            cmd.Parameters.AddWithValue("@Gc_no", gc_no);
            cmd.Parameters.AddWithValue("@Cc_holder", cc_holder);
            cmd.Parameters.AddWithValue("@Cc_month", cc_month);
            cmd.Parameters.AddWithValue("@Cc_year", cc_year);
            cmd.Parameters.AddWithValue("@Cc_type", cc_type);
            cmd.Parameters.AddWithValue("@Note", Note);
            cmd.Parameters.AddWithValue("@Created_by", Created_by);
            cmd.Parameters.AddWithValue("@Reference", Reference);

            return ExDataBase_returnDataSet(cmd);
        }
        #endregion
    }
}
