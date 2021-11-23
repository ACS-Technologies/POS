using DAL;
using POCO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL
{
    public class SalesDBL : BaseDBL
    {
        SalesDAL oSalesDAL = new SalesDAL();

        /// <summary>
        /// M_Sales_GetAll
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public List<Sales> M_Sales_GetAll(int? UserId)
        {
            DataSet ds = new DataSet();
            Sales oSales;
            List<Sales> oLSales = new List<Sales>();
            ds = oSalesDAL.M_Sales_GetAll(UserId);
            if (ds.Tables.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    oSales = new Sales();
                    oSales.Id = int.Parse(ds.Tables[0].Rows[i]["Id"].ToString());
                    oSales.Date = DateTime.Parse(ds.Tables[0].Rows[i]["Date"].ToString());
                    oSales.Customer_id = int.Parse(ds.Tables[0].Rows[i]["Customer_id"].ToString());
                    oSales.Customer_name = ds.Tables[0].Rows[i]["Customer_name"].ToString();
                    oSales.Total = decimal.Parse(ds.Tables[0].Rows[i]["Total"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[i]["Product_discount"].ToString()))
                        oSales.Product_discount = decimal.Parse(ds.Tables[0].Rows[i]["Product_discount"].ToString());

                    oSales.Order_discount_id = ds.Tables[0].Rows[i]["Order_discount_id"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[i]["Order_discount"].ToString()))
                        oSales.Order_discount = decimal.Parse(ds.Tables[0].Rows[i]["Order_discount"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[i]["Total_discount"].ToString()))
                        oSales.Total_discount = decimal.Parse(ds.Tables[0].Rows[i]["Total_discount"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[i]["Product_tax"].ToString()))
                        oSales.Product_tax = decimal.Parse(ds.Tables[0].Rows[i]["Product_tax"].ToString());

                    oSales.Order_tax_id = ds.Tables[0].Rows[i]["Order_tax_id"].ToString();
                    oSales.Order_tax = decimal.Parse(ds.Tables[0].Rows[i]["Order_tax"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[i]["Total_tax"].ToString()))
                        oSales.Total_tax = decimal.Parse(ds.Tables[0].Rows[i]["Total_tax"].ToString());

                    oSales.Grand_total = decimal.Parse(ds.Tables[0].Rows[i]["Grand_total"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[i]["Total_items"].ToString()))
                        oSales.Total_items = int.Parse(ds.Tables[0].Rows[i]["Total_items"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[i]["Total_quantity"].ToString()))
                        oSales.Total_quantity = decimal.Parse(ds.Tables[0].Rows[i]["Total_quantity"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[i]["Paid"].ToString()))
                        oSales.Paid = decimal.Parse(ds.Tables[0].Rows[i]["Paid"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[i]["Created_by"].ToString()))
                        oSales.Created_by = int.Parse(ds.Tables[0].Rows[i]["Created_by"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[i]["Updated_by"].ToString()))
                        oSales.Updated_by = int.Parse(ds.Tables[0].Rows[i]["Updated_by"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[i]["Updated_at"].ToString()))
                        oSales.Updated_at = DateTime.Parse(ds.Tables[0].Rows[i]["Updated_at"].ToString());
                    oSales.Note = ds.Tables[0].Rows[i]["Note"].ToString();
                    oSales.Status = ds.Tables[0].Rows[i]["Status"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[i]["Rounding"].ToString()))
                        oSales.Rounding = decimal.Parse(ds.Tables[0].Rows[i]["Rounding"].ToString());

                    oSales.Store_id = int.Parse(ds.Tables[0].Rows[i]["Store_id"].ToString());
                    oSales.Hold_ref = ds.Tables[0].Rows[i]["Hold_ref"].ToString();

                    oLSales.Add(oSales);
                }
            }
            return oLSales;
        }

        /// <summary>
        /// M_Sales_GetById
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Sales M_Sales_GetById(int Id)
        {
            DataSet ds = new DataSet();
            Sales oSales = new Sales();
            SaleItems oSaleItems;

            ds = oSalesDAL.M_Sales_GetById(Id);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    oSales.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                    oSales.Date = DateTime.Parse(ds.Tables[0].Rows[0]["Date"].ToString());
                    oSales.Customer_id = int.Parse(ds.Tables[0].Rows[0]["Customer_id"].ToString());
                    oSales.Customer_name = ds.Tables[0].Rows[0]["Customer_name"].ToString();
                    oSales.Total = decimal.Parse(ds.Tables[0].Rows[0]["Total"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Product_discount"].ToString()))
                        oSales.Product_discount = decimal.Parse(ds.Tables[0].Rows[0]["Product_discount"].ToString());

                    oSales.Order_discount_id = ds.Tables[0].Rows[0]["Order_discount_id"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Order_discount"].ToString()))
                        oSales.Order_discount = decimal.Parse(ds.Tables[0].Rows[0]["Order_discount"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Total_discount"].ToString()))
                        oSales.Total_discount = decimal.Parse(ds.Tables[0].Rows[0]["Total_discount"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Product_tax"].ToString()))
                        oSales.Product_tax = decimal.Parse(ds.Tables[0].Rows[0]["Product_tax"].ToString());

                    oSales.Order_tax_id = ds.Tables[0].Rows[0]["Order_tax_id"].ToString();
                    oSales.Order_tax = decimal.Parse(ds.Tables[0].Rows[0]["Order_tax"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Total_tax"].ToString()))
                        oSales.Total_tax = decimal.Parse(ds.Tables[0].Rows[0]["Total_tax"].ToString());

                    oSales.Grand_total = decimal.Parse(ds.Tables[0].Rows[0]["Grand_total"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Total_items"].ToString()))
                        oSales.Total_items = int.Parse(ds.Tables[0].Rows[0]["Total_items"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Total_quantity"].ToString()))
                        oSales.Total_quantity = decimal.Parse(ds.Tables[0].Rows[0]["Total_quantity"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Paid"].ToString()))
                        oSales.Paid = decimal.Parse(ds.Tables[0].Rows[0]["Paid"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Created_by"].ToString()))
                        oSales.Created_by = int.Parse(ds.Tables[0].Rows[0]["Created_by"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Updated_by"].ToString()))
                        oSales.Updated_by = int.Parse(ds.Tables[0].Rows[0]["Updated_by"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Updated_at"].ToString()))
                        oSales.Updated_at = DateTime.Parse(ds.Tables[0].Rows[0]["Updated_at"].ToString());
                    oSales.Note = ds.Tables[0].Rows[0]["Note"].ToString();
                    oSales.Status = ds.Tables[0].Rows[0]["Status"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Rounding"].ToString()))
                        oSales.Rounding = decimal.Parse(ds.Tables[0].Rows[0]["Rounding"].ToString());

                    oSales.Store_id = int.Parse(ds.Tables[0].Rows[0]["Store_id"].ToString());
                    oSales.Hold_ref = ds.Tables[0].Rows[0]["Hold_ref"].ToString();

                    if (ds.Tables.Count > 1)
                    {
                        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                        {
                            oSaleItems = new SaleItems();
                            oSaleItems.Id = int.Parse(ds.Tables[1].Rows[i]["Id"].ToString());
                            oSaleItems.Sale_id = int.Parse(ds.Tables[1].Rows[i]["Sale_id"].ToString());
                            oSaleItems.Product_id = int.Parse(ds.Tables[1].Rows[i]["Product_id"].ToString());
                            oSaleItems.Quantity = decimal.Parse(ds.Tables[1].Rows[i]["Quantity"].ToString());
                            oSaleItems.Unit_price = decimal.Parse(ds.Tables[1].Rows[i]["Unit_price"].ToString());
                            oSaleItems.Net_unit_price = decimal.Parse(ds.Tables[1].Rows[i]["Net_unit_price"].ToString());
                            if (!string.IsNullOrEmpty(ds.Tables[1].Rows[i]["Tax"].ToString()))
                                oSaleItems.Tax = int.Parse(ds.Tables[1].Rows[i]["Tax"].ToString());
                            if (!string.IsNullOrEmpty(ds.Tables[1].Rows[i]["Item_tax"].ToString()))
                                oSaleItems.Item_tax = decimal.Parse(ds.Tables[1].Rows[i]["Item_tax"].ToString());
                            if (!string.IsNullOrEmpty(ds.Tables[1].Rows[i]["Item_discount"].ToString()))
                                oSaleItems.Item_discount = decimal.Parse(ds.Tables[1].Rows[i]["Item_discount"].ToString());
                            oSaleItems.Discount = ds.Tables[1].Rows[i]["Discount"].ToString();
                            oSaleItems.Product_code = ds.Tables[1].Rows[i]["Product_code"].ToString();
                            oSaleItems.Product_name = ds.Tables[1].Rows[i]["Product_name"].ToString();
                            oSaleItems.Comment = ds.Tables[1].Rows[i]["Comment"].ToString();
                            oSaleItems.Subtotal = decimal.Parse(ds.Tables[1].Rows[i]["Subtotal"].ToString());


                            if (!string.IsNullOrEmpty(ds.Tables[1].Rows[i]["Real_unit_price"].ToString()))
                                oSaleItems.Real_unit_price = decimal.Parse(ds.Tables[1].Rows[i]["Real_unit_price"].ToString());

                            if (!string.IsNullOrEmpty(ds.Tables[1].Rows[i]["Cost"].ToString()))
                                oSaleItems.Cost = decimal.Parse(ds.Tables[1].Rows[i]["Cost"].ToString());

                            oSales.SaleItems.Add(oSaleItems);

                        }
                    }

                }

            }
            return oSales;
        }

        /// <summary>
        /// M_Sales_GetById
        /// </summary>
        /// <param name="Id"></param>
        public void M_Sales_Delete(int Id)
        {
            DataSet ds = new DataSet();
            Sales oSales = new Sales();
            ds = oSalesDAL.M_Sales_Delete(Id);
        }

        public Sales M_Store_Insert(Sales PoSales)
        {
            DataSet ds = new DataSet();
            Sales oSales = new Sales();
            ds = oSalesDAL.M_Sales_Insert(PoSales.Date, PoSales.Customer_id, PoSales.Customer_name, PoSales.Total, PoSales.Product_discount, PoSales.Order_discount_id, PoSales.Order_discount,
            PoSales.Total_discount, PoSales.Product_tax, PoSales.Order_tax_id, PoSales.Order_tax, PoSales.Total_tax, PoSales.Grand_total, PoSales.Total_items, PoSales.Total_quantity,
            PoSales.Paid, PoSales. Created_by, PoSales.Note, PoSales.Status, PoSales.Rounding, PoSales.Store_id, PoSales.Hold_ref, ToDataTable(PoSales.SaleItems));

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    oSales.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                    oSales.Date = DateTime.Parse(ds.Tables[0].Rows[0]["Date"].ToString());
                    oSales.Customer_id = int.Parse(ds.Tables[0].Rows[0]["Customer_id"].ToString());
                    oSales.Customer_name = ds.Tables[0].Rows[0]["Customer_name"].ToString();
                    oSales.Total = decimal.Parse(ds.Tables[0].Rows[0]["Total"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Product_discount"].ToString()))
                        oSales.Product_discount = decimal.Parse(ds.Tables[0].Rows[0]["Product_discount"].ToString());

                    oSales.Order_discount_id = ds.Tables[0].Rows[0]["Order_discount_id"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Order_discount"].ToString()))
                        oSales.Order_discount = decimal.Parse(ds.Tables[0].Rows[0]["Order_discount"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Total_discount"].ToString()))
                        oSales.Total_discount = decimal.Parse(ds.Tables[0].Rows[0]["Total_discount"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Product_tax"].ToString()))
                        oSales.Product_tax = decimal.Parse(ds.Tables[0].Rows[0]["Product_tax"].ToString());

                    oSales.Order_tax_id = ds.Tables[0].Rows[0]["Order_tax_id"].ToString();
                    oSales.Order_tax = decimal.Parse(ds.Tables[0].Rows[0]["Order_tax"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Total_tax"].ToString()))
                        oSales.Total_tax = decimal.Parse(ds.Tables[0].Rows[0]["Total_tax"].ToString());

                    oSales.Grand_total = decimal.Parse(ds.Tables[0].Rows[0]["Grand_total"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Total_items"].ToString()))
                        oSales.Total_items = int.Parse(ds.Tables[0].Rows[0]["Total_items"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Total_quantity"].ToString()))
                        oSales.Total_quantity = decimal.Parse(ds.Tables[0].Rows[0]["Total_quantity"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Paid"].ToString()))
                        oSales.Paid = decimal.Parse(ds.Tables[0].Rows[0]["Paid"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Created_by"].ToString()))
                        oSales.Created_by = int.Parse(ds.Tables[0].Rows[0]["Created_by"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Updated_by"].ToString()))
                        oSales.Updated_by = int.Parse(ds.Tables[0].Rows[0]["Updated_by"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Updated_at"].ToString()))
                        oSales.Updated_at = DateTime.Parse(ds.Tables[0].Rows[0]["Updated_at"].ToString());
                    oSales.Note = ds.Tables[0].Rows[0]["Note"].ToString();
                    oSales.Status = ds.Tables[0].Rows[0]["Status"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Rounding"].ToString()))
                        oSales.Rounding = decimal.Parse(ds.Tables[0].Rows[0]["Rounding"].ToString());

                    oSales.Store_id = int.Parse(ds.Tables[0].Rows[0]["Store_id"].ToString());
                    oSales.Hold_ref = ds.Tables[0].Rows[0]["Hold_ref"].ToString();
                }

            }
            return oSales;
        }

        public Sales M_Store_Update(Sales PoSales)
        {
            DataSet ds = new DataSet();
            Sales oSales = new Sales();
            ds = oSalesDAL.M_Sales_Update(PoSales.Id,PoSales.Updated_at, PoSales.Customer_id, PoSales.Customer_name, PoSales.Total, PoSales.Product_discount, PoSales.Order_discount_id, PoSales.Order_discount,
            PoSales.Total_discount, PoSales.Product_tax, PoSales.Order_tax_id, PoSales.Order_tax, PoSales.Total_tax, PoSales.Grand_total, PoSales.Total_items, PoSales.Total_quantity,
            PoSales.Paid, PoSales.Updated_by, PoSales.Note, PoSales.Status, PoSales.Rounding, PoSales.Store_id, PoSales.Hold_ref, ToDataTable(PoSales.SaleItems));

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    oSales.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                    oSales.Date = DateTime.Parse(ds.Tables[0].Rows[0]["Date"].ToString());
                    oSales.Customer_id = int.Parse(ds.Tables[0].Rows[0]["Customer_id"].ToString());
                    oSales.Customer_name = ds.Tables[0].Rows[0]["Customer_name"].ToString();
                    oSales.Total = decimal.Parse(ds.Tables[0].Rows[0]["Total"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Product_discount"].ToString()))
                        oSales.Product_discount = decimal.Parse(ds.Tables[0].Rows[0]["Product_discount"].ToString());

                    oSales.Order_discount_id = ds.Tables[0].Rows[0]["Order_discount_id"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Order_discount"].ToString()))
                        oSales.Order_discount = decimal.Parse(ds.Tables[0].Rows[0]["Order_discount"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Total_discount"].ToString()))
                        oSales.Total_discount = decimal.Parse(ds.Tables[0].Rows[0]["Total_discount"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Product_tax"].ToString()))
                        oSales.Product_tax = decimal.Parse(ds.Tables[0].Rows[0]["Product_tax"].ToString());

                    oSales.Order_tax_id = ds.Tables[0].Rows[0]["Order_tax_id"].ToString();
                    oSales.Order_tax = decimal.Parse(ds.Tables[0].Rows[0]["Order_tax"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Total_tax"].ToString()))
                        oSales.Total_tax = decimal.Parse(ds.Tables[0].Rows[0]["Total_tax"].ToString());

                    oSales.Grand_total = decimal.Parse(ds.Tables[0].Rows[0]["Grand_total"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Total_items"].ToString()))
                        oSales.Total_items = int.Parse(ds.Tables[0].Rows[0]["Total_items"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Total_quantity"].ToString()))
                        oSales.Total_quantity = decimal.Parse(ds.Tables[0].Rows[0]["Total_quantity"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Paid"].ToString()))
                        oSales.Paid = decimal.Parse(ds.Tables[0].Rows[0]["Paid"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Created_by"].ToString()))
                        oSales.Created_by = int.Parse(ds.Tables[0].Rows[0]["Created_by"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Updated_by"].ToString()))
                        oSales.Updated_by = int.Parse(ds.Tables[0].Rows[0]["Updated_by"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Updated_at"].ToString()))
                        oSales.Updated_at = DateTime.Parse(ds.Tables[0].Rows[0]["Updated_at"].ToString());
                    oSales.Note = ds.Tables[0].Rows[0]["Note"].ToString();
                    oSales.Status = ds.Tables[0].Rows[0]["Status"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Rounding"].ToString()))
                        oSales.Rounding = decimal.Parse(ds.Tables[0].Rows[0]["Rounding"].ToString());

                    oSales.Store_id = int.Parse(ds.Tables[0].Rows[0]["Store_id"].ToString());
                    oSales.Hold_ref = ds.Tables[0].Rows[0]["Hold_ref"].ToString();
                }

            }
            return oSales;
        }
    }
}
