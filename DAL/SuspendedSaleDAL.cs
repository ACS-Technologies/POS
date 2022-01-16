using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class SuspendedSaleDAL : Database
    {
        /// <summary>
        /// M_SuspendedSale_GetAll
        /// </summary>
        /// <returns></returns>
        public DataSet M_SuspendedSale_GetAll(int? UserId, int? BranchId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "M_POS_SuspendedSale_GetAll";
            cmd.Parameters.AddWithValue("@UserId", UserId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            return ExDataBase_returnDataSet(cmd);
        }

        /// <summary>
        /// M_SuspendedSale_GetById
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public DataSet M_SuspendedSale_GetById(int Id,bool IsWorkShop)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "M_POS_SuspendedSale_GetById";
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@IsWorkShop", IsWorkShop);
            return ExDataBase_returnDataSet(cmd);
        }

        /// <summary>
        /// M_SuspendedSale_Update
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
        public DataSet M_SuspendedSale_Update(int Id, DateTime? Updated_at, int Customer_id, string Customer_name, decimal Total, decimal? Product_discount, string Order_discount_id, decimal? Order_discount,
            decimal? Total_discount, decimal? Product_tax, string Order_tax_id, decimal Order_tax, decimal? Total_tax, decimal Grand_total, int? Total_items, decimal? Total_quantity,
            decimal? Paid, int? Updated_by, string Note, int Store_id, string Hold_ref, DataTable SaleItems)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "M_POS_SuspendedSale_Update";
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
            cmd.Parameters.AddWithValue("@Store_id", Store_id);
            cmd.Parameters.AddWithValue("@Hold_ref", Hold_ref);
            cmd.Parameters.AddWithValue("@SuspendedSaleItemsType", SaleItems);

            return ExDataBase_returnDataSet(cmd);
        }

        /// <summary>
        /// M_SuspendedSale_Insert
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
        public DataSet M_SuspendedSale_Insert(DateTime Date, int Customer_id, string Customer_name, decimal Total, decimal? Product_discount, string Order_discount_id, decimal? Order_discount,
            decimal? Total_discount, decimal? Product_tax, string Order_tax_id, decimal Order_tax, decimal? Total_tax, decimal Grand_total, int? Total_items, decimal? Total_quantity,
            decimal? Paid, int? Created_by, string Note, int Store_id, string Hold_ref, DataTable SaleItems,int Vehicle_id,string Vehicle_name)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "M_POS_SuspendedSale_Insert";
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
            cmd.Parameters.AddWithValue("@Store_id", Store_id);
            cmd.Parameters.AddWithValue("@Hold_ref", Hold_ref);
            cmd.Parameters.AddWithValue("@SuspendedSaleItemsType", SaleItems);
            cmd.Parameters.AddWithValue("@Vehicle_id", Vehicle_id);
            cmd.Parameters.AddWithValue("@Vehicle_name", Vehicle_name);
            return ExDataBase_returnDataSet(cmd);
        }

        /// <summary>
        /// M_SuspendedSale_Delete
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public DataSet M_SuspendedSale_Delete(int Id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "M_POS_SuspendedSale_Delete";
            cmd.Parameters.AddWithValue("@Id", Id);
            return ExDataBase_returnDataSet(cmd);
        }
        public DataSet M_POS_Accident_Insert(int? AccidentId, int? CustomerId, int? InsuranceCompanies,decimal? CustomerRatio, decimal? InsuranceRatio, decimal? CustomerValue, decimal? InsuranceValue, decimal? DiscountInsurance, int? EnduranceRatio, int? RelatedId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "M_POS_Accident_Insert";
            cmd.Parameters.AddWithValue("@AccidentId", AccidentId);
            cmd.Parameters.AddWithValue("@CustomerId", CustomerId);
            cmd.Parameters.AddWithValue("@InsuranceCompanies", InsuranceCompanies);
            cmd.Parameters.AddWithValue("@CustomerRatio", CustomerRatio);
            cmd.Parameters.AddWithValue("@InsuranceRatio", InsuranceRatio);
            cmd.Parameters.AddWithValue("@CustomerValue", CustomerValue);
            cmd.Parameters.AddWithValue("@InsuranceValue", InsuranceValue);
            cmd.Parameters.AddWithValue("@DiscountInsurance", DiscountInsurance);
            cmd.Parameters.AddWithValue("@EnduranceRatio", EnduranceRatio);
            cmd.Parameters.AddWithValue("@RelatedId", RelatedId);
            return ExDataBase_returnDataSet(cmd);
        }
    }
}
