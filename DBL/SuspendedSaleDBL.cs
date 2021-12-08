using DAL;
using POCO;
using System;
using System.Collections.Generic;
using System.Data;

namespace DBL
{
    public class SuspendedSaleDBL : BaseDBL
    {
        SuspendedSaleDAL oSuspendedSaleDAL = new SuspendedSaleDAL();

        /// <summary>
        /// M_SuspendedSale_GetAll
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public List<SuspendedSale> M_SuspendedSale_GetAll(int? UserId)
        {
            DataSet ds = new DataSet();
            SuspendedSale oSuspendedSale;
            List<SuspendedSale> oLSuspendedSale = new List<SuspendedSale>();
            ds = oSuspendedSaleDAL.M_SuspendedSale_GetAll(UserId);
            if (ds.Tables.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    oSuspendedSale = new SuspendedSale();
                    oSuspendedSale.Id = int.Parse(ds.Tables[0].Rows[i]["Id"].ToString());
                    oSuspendedSale.Date = DateTime.Parse(ds.Tables[0].Rows[i]["Date"].ToString());
                    oSuspendedSale.Customer_id = int.Parse(ds.Tables[0].Rows[i]["Customer_id"].ToString());
                    oSuspendedSale.Customer_name = ds.Tables[0].Rows[i]["Customer_name"].ToString();
                    oSuspendedSale.Total = decimal.Parse(ds.Tables[0].Rows[i]["Total"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[i]["Product_discount"].ToString()))
                        oSuspendedSale.Product_discount = decimal.Parse(ds.Tables[0].Rows[i]["Product_discount"].ToString());

                    oSuspendedSale.Order_discount_id = ds.Tables[0].Rows[i]["Order_discount_id"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[i]["Order_discount"].ToString()))
                        oSuspendedSale.Order_discount = decimal.Parse(ds.Tables[0].Rows[i]["Order_discount"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[i]["Total_discount"].ToString()))
                        oSuspendedSale.Total_discount = decimal.Parse(ds.Tables[0].Rows[i]["Total_discount"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[i]["Product_tax"].ToString()))
                        oSuspendedSale.Product_tax = decimal.Parse(ds.Tables[0].Rows[i]["Product_tax"].ToString());

                    oSuspendedSale.Order_tax_id = ds.Tables[0].Rows[i]["Order_tax_id"].ToString();
                    oSuspendedSale.Order_tax = decimal.Parse(ds.Tables[0].Rows[i]["Order_tax"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[i]["Total_tax"].ToString()))
                        oSuspendedSale.Total_tax = decimal.Parse(ds.Tables[0].Rows[i]["Total_tax"].ToString());

                    oSuspendedSale.Grand_total = decimal.Parse(ds.Tables[0].Rows[i]["Grand_total"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[i]["Total_items"].ToString()))
                        oSuspendedSale.Total_items = int.Parse(ds.Tables[0].Rows[i]["Total_items"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[i]["Total_quantity"].ToString()))
                        oSuspendedSale.Total_quantity = decimal.Parse(ds.Tables[0].Rows[i]["Total_quantity"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[i]["Paid"].ToString()))
                        oSuspendedSale.Paid = decimal.Parse(ds.Tables[0].Rows[i]["Paid"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[i]["Created_by"].ToString()))
                        oSuspendedSale.Created_by = int.Parse(ds.Tables[0].Rows[i]["Created_by"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[i]["Updated_by"].ToString()))
                        oSuspendedSale.Updated_by = int.Parse(ds.Tables[0].Rows[i]["Updated_by"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[i]["Updated_at"].ToString()))
                        oSuspendedSale.Updated_at = DateTime.Parse(ds.Tables[0].Rows[i]["Updated_at"].ToString());
                    oSuspendedSale.Note = ds.Tables[0].Rows[i]["Note"].ToString();

                    oSuspendedSale.Store_id = int.Parse(ds.Tables[0].Rows[i]["Store_id"].ToString());
                    oSuspendedSale.Hold_ref = ds.Tables[0].Rows[i]["Hold_ref"].ToString();

                    oLSuspendedSale.Add(oSuspendedSale);
                }
            }
            return oLSuspendedSale;
        }

        /// <summary>
        /// M_SuspendedSale_GetById
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public SuspendedSale M_SuspendedSale_GetById(int Id)
        {
            DataSet ds = new DataSet();
            SuspendedSale oSuspendedSale = new SuspendedSale();
            SuspendedItem oSuspendedItem;

            ds = oSuspendedSaleDAL.M_SuspendedSale_GetById(Id);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    oSuspendedSale.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                    oSuspendedSale.Date = DateTime.Parse(ds.Tables[0].Rows[0]["Date"].ToString());
                    oSuspendedSale.Customer_id = int.Parse(ds.Tables[0].Rows[0]["Customer_id"].ToString());
                    oSuspendedSale.Customer_name = ds.Tables[0].Rows[0]["Customer_name"].ToString();
                    oSuspendedSale.Total = decimal.Parse(ds.Tables[0].Rows[0]["Total"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Product_discount"].ToString()))
                        oSuspendedSale.Product_discount = decimal.Parse(ds.Tables[0].Rows[0]["Product_discount"].ToString());

                    oSuspendedSale.Order_discount_id = ds.Tables[0].Rows[0]["Order_discount_id"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Order_discount"].ToString()))
                        oSuspendedSale.Order_discount = decimal.Parse(ds.Tables[0].Rows[0]["Order_discount"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Total_discount"].ToString()))
                        oSuspendedSale.Total_discount = decimal.Parse(ds.Tables[0].Rows[0]["Total_discount"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Product_tax"].ToString()))
                        oSuspendedSale.Product_tax = decimal.Parse(ds.Tables[0].Rows[0]["Product_tax"].ToString());

                    oSuspendedSale.Order_tax_id = ds.Tables[0].Rows[0]["Order_tax_id"].ToString();
                    oSuspendedSale.Order_tax = decimal.Parse(ds.Tables[0].Rows[0]["Order_tax"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Total_tax"].ToString()))
                        oSuspendedSale.Total_tax = decimal.Parse(ds.Tables[0].Rows[0]["Total_tax"].ToString());

                    oSuspendedSale.Grand_total = decimal.Parse(ds.Tables[0].Rows[0]["Grand_total"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Total_items"].ToString()))
                        oSuspendedSale.Total_items = int.Parse(ds.Tables[0].Rows[0]["Total_items"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Total_quantity"].ToString()))
                        oSuspendedSale.Total_quantity = decimal.Parse(ds.Tables[0].Rows[0]["Total_quantity"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Paid"].ToString()))
                        oSuspendedSale.Paid = decimal.Parse(ds.Tables[0].Rows[0]["Paid"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Created_by"].ToString()))
                        oSuspendedSale.Created_by = int.Parse(ds.Tables[0].Rows[0]["Created_by"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Updated_by"].ToString()))
                        oSuspendedSale.Updated_by = int.Parse(ds.Tables[0].Rows[0]["Updated_by"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Updated_at"].ToString()))
                        oSuspendedSale.Updated_at = DateTime.Parse(ds.Tables[0].Rows[0]["Updated_at"].ToString());
                    oSuspendedSale.Note = ds.Tables[0].Rows[0]["Note"].ToString();

                    oSuspendedSale.Store_id = int.Parse(ds.Tables[0].Rows[0]["Store_id"].ToString());
                    oSuspendedSale.Hold_ref = ds.Tables[0].Rows[0]["Hold_ref"].ToString();

                    if (ds.Tables.Count > 1)
                    {
                        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                        {
                            oSuspendedItem = new SuspendedItem();
                            oSuspendedItem.Id = int.Parse(ds.Tables[1].Rows[i]["Id"].ToString());
                            oSuspendedItem.Suspend_id = int.Parse(ds.Tables[1].Rows[i]["Suspend_id"].ToString());
                            oSuspendedItem.Product_id = int.Parse(ds.Tables[1].Rows[i]["Product_id"].ToString());
                            oSuspendedItem.Quantity = decimal.Parse(ds.Tables[1].Rows[i]["Quantity"].ToString());
                            oSuspendedItem.Unit_price = decimal.Parse(ds.Tables[1].Rows[i]["Unit_price"].ToString());
                            oSuspendedItem.Net_unit_price = decimal.Parse(ds.Tables[1].Rows[i]["Net_unit_price"].ToString());
                            if (!string.IsNullOrEmpty(ds.Tables[1].Rows[i]["Tax"].ToString()))
                                oSuspendedItem.Tax = int.Parse(ds.Tables[1].Rows[i]["Tax"].ToString());
                            if (!string.IsNullOrEmpty(ds.Tables[1].Rows[i]["Item_tax"].ToString()))
                                oSuspendedItem.Item_tax = decimal.Parse(ds.Tables[1].Rows[i]["Item_tax"].ToString());
                            if (!string.IsNullOrEmpty(ds.Tables[1].Rows[i]["Item_discount"].ToString()))
                                oSuspendedItem.Item_discount = decimal.Parse(ds.Tables[1].Rows[i]["Item_discount"].ToString());
                            oSuspendedItem.Discount = ds.Tables[1].Rows[i]["Discount"].ToString();
                            oSuspendedItem.Product_code = ds.Tables[1].Rows[i]["Product_code"].ToString();
                            oSuspendedItem.Product_name = ds.Tables[1].Rows[i]["Product_name"].ToString();
                            oSuspendedItem.Comment = ds.Tables[1].Rows[i]["Comment"].ToString();
                            oSuspendedItem.Subtotal = decimal.Parse(ds.Tables[1].Rows[i]["Subtotal"].ToString());
                            if (!string.IsNullOrEmpty(ds.Tables[1].Rows[i]["TaxClassificationNo"].ToString()))
                                oSuspendedItem.TaxClassificationNo = int.Parse(ds.Tables[0].Rows[i]["TaxClassificationNo"].ToString());
                            if (!string.IsNullOrEmpty(ds.Tables[1].Rows[i]["UnitId"].ToString()))
                                oSuspendedItem.UnitId = int.Parse(ds.Tables[1].Rows[i]["UnitId"].ToString());
                            if (!string.IsNullOrEmpty(ds.Tables[1].Rows[i]["Real_unit_price"].ToString()))
                                oSuspendedItem.Real_unit_price = decimal.Parse(ds.Tables[1].Rows[i]["Real_unit_price"].ToString());

                            oSuspendedSale.SuspendedItems.Add(oSuspendedItem);

                        }
                    }

                }

            }
            return oSuspendedSale;
        }

        /// <summary>
        /// M_SuspendedSale_GetById
        /// </summary>
        /// <param name="Id"></param>
        public void M_SuspendedSale_Delete(int Id)
        {
            DataSet ds = new DataSet();
            SuspendedSale oSuspendedSale = new SuspendedSale();
            ds = oSuspendedSaleDAL.M_SuspendedSale_Delete(Id);
        }

        public SuspendedSale M_Store_Insert(SuspendedSale PoSuspendedSale)
        {
            DataSet ds = new DataSet();
            SuspendedSale oSuspendedSale = new SuspendedSale();
            ds = oSuspendedSaleDAL.M_SuspendedSale_Insert(PoSuspendedSale.Date, PoSuspendedSale.Customer_id, PoSuspendedSale.Customer_name, PoSuspendedSale.Total, PoSuspendedSale.Product_discount, PoSuspendedSale.Order_discount_id, PoSuspendedSale.Order_discount,
            PoSuspendedSale.Total_discount, PoSuspendedSale.Product_tax, PoSuspendedSale.Order_tax_id, PoSuspendedSale.Order_tax, PoSuspendedSale.Total_tax, PoSuspendedSale.Grand_total, PoSuspendedSale.Total_items, PoSuspendedSale.Total_quantity,
            PoSuspendedSale.Paid, PoSuspendedSale.Created_by, PoSuspendedSale.Note,PoSuspendedSale.Store_id, PoSuspendedSale.Hold_ref, ToDataTable(PoSuspendedSale.SuspendedItems));

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    oSuspendedSale.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                    oSuspendedSale.Date = DateTime.Parse(ds.Tables[0].Rows[0]["Date"].ToString());
                    oSuspendedSale.Customer_id = int.Parse(ds.Tables[0].Rows[0]["Customer_id"].ToString());
                    oSuspendedSale.Customer_name = ds.Tables[0].Rows[0]["Customer_name"].ToString();
                    oSuspendedSale.Total = decimal.Parse(ds.Tables[0].Rows[0]["Total"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Product_discount"].ToString()))
                        oSuspendedSale.Product_discount = decimal.Parse(ds.Tables[0].Rows[0]["Product_discount"].ToString());

                    oSuspendedSale.Order_discount_id = ds.Tables[0].Rows[0]["Order_discount_id"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Order_discount"].ToString()))
                        oSuspendedSale.Order_discount = decimal.Parse(ds.Tables[0].Rows[0]["Order_discount"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Total_discount"].ToString()))
                        oSuspendedSale.Total_discount = decimal.Parse(ds.Tables[0].Rows[0]["Total_discount"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Product_tax"].ToString()))
                        oSuspendedSale.Product_tax = decimal.Parse(ds.Tables[0].Rows[0]["Product_tax"].ToString());

                    oSuspendedSale.Order_tax_id = ds.Tables[0].Rows[0]["Order_tax_id"].ToString();
                    oSuspendedSale.Order_tax = decimal.Parse(ds.Tables[0].Rows[0]["Order_tax"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Total_tax"].ToString()))
                        oSuspendedSale.Total_tax = decimal.Parse(ds.Tables[0].Rows[0]["Total_tax"].ToString());

                    oSuspendedSale.Grand_total = decimal.Parse(ds.Tables[0].Rows[0]["Grand_total"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Total_items"].ToString()))
                        oSuspendedSale.Total_items = int.Parse(ds.Tables[0].Rows[0]["Total_items"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Total_quantity"].ToString()))
                        oSuspendedSale.Total_quantity = decimal.Parse(ds.Tables[0].Rows[0]["Total_quantity"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Paid"].ToString()))
                        oSuspendedSale.Paid = decimal.Parse(ds.Tables[0].Rows[0]["Paid"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Created_by"].ToString()))
                        oSuspendedSale.Created_by = int.Parse(ds.Tables[0].Rows[0]["Created_by"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Updated_by"].ToString()))
                        oSuspendedSale.Updated_by = int.Parse(ds.Tables[0].Rows[0]["Updated_by"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Updated_at"].ToString()))
                        oSuspendedSale.Updated_at = DateTime.Parse(ds.Tables[0].Rows[0]["Updated_at"].ToString());
                    oSuspendedSale.Note = ds.Tables[0].Rows[0]["Note"].ToString();

                    oSuspendedSale.Store_id = int.Parse(ds.Tables[0].Rows[0]["Store_id"].ToString());
                    oSuspendedSale.Hold_ref = ds.Tables[0].Rows[0]["Hold_ref"].ToString();
                }

            }
            return oSuspendedSale;
        }

        public SuspendedSale M_Store_Update(SuspendedSale PoSuspendedSale)
        {
            DataSet ds = new DataSet();
            SuspendedSale oSuspendedSale = new SuspendedSale();
            ds = oSuspendedSaleDAL.M_SuspendedSale_Update(PoSuspendedSale.Id, PoSuspendedSale.Updated_at, PoSuspendedSale.Customer_id, PoSuspendedSale.Customer_name, PoSuspendedSale.Total, PoSuspendedSale.Product_discount, PoSuspendedSale.Order_discount_id, PoSuspendedSale.Order_discount,
            PoSuspendedSale.Total_discount, PoSuspendedSale.Product_tax, PoSuspendedSale.Order_tax_id, PoSuspendedSale.Order_tax, PoSuspendedSale.Total_tax, PoSuspendedSale.Grand_total, PoSuspendedSale.Total_items, PoSuspendedSale.Total_quantity,
            PoSuspendedSale.Paid, PoSuspendedSale.Updated_by, PoSuspendedSale.Note, PoSuspendedSale.Store_id, PoSuspendedSale.Hold_ref, ToDataTable(PoSuspendedSale.SuspendedItems));

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    oSuspendedSale.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                    oSuspendedSale.Date = DateTime.Parse(ds.Tables[0].Rows[0]["Date"].ToString());
                    oSuspendedSale.Customer_id = int.Parse(ds.Tables[0].Rows[0]["Customer_id"].ToString());
                    oSuspendedSale.Customer_name = ds.Tables[0].Rows[0]["Customer_name"].ToString();
                    oSuspendedSale.Total = decimal.Parse(ds.Tables[0].Rows[0]["Total"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Product_discount"].ToString()))
                        oSuspendedSale.Product_discount = decimal.Parse(ds.Tables[0].Rows[0]["Product_discount"].ToString());

                    oSuspendedSale.Order_discount_id = ds.Tables[0].Rows[0]["Order_discount_id"].ToString();

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Order_discount"].ToString()))
                        oSuspendedSale.Order_discount = decimal.Parse(ds.Tables[0].Rows[0]["Order_discount"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Total_discount"].ToString()))
                        oSuspendedSale.Total_discount = decimal.Parse(ds.Tables[0].Rows[0]["Total_discount"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Product_tax"].ToString()))
                        oSuspendedSale.Product_tax = decimal.Parse(ds.Tables[0].Rows[0]["Product_tax"].ToString());

                    oSuspendedSale.Order_tax_id = ds.Tables[0].Rows[0]["Order_tax_id"].ToString();
                    oSuspendedSale.Order_tax = decimal.Parse(ds.Tables[0].Rows[0]["Order_tax"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Total_tax"].ToString()))
                        oSuspendedSale.Total_tax = decimal.Parse(ds.Tables[0].Rows[0]["Total_tax"].ToString());

                    oSuspendedSale.Grand_total = decimal.Parse(ds.Tables[0].Rows[0]["Grand_total"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Total_items"].ToString()))
                        oSuspendedSale.Total_items = int.Parse(ds.Tables[0].Rows[0]["Total_items"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Total_quantity"].ToString()))
                        oSuspendedSale.Total_quantity = decimal.Parse(ds.Tables[0].Rows[0]["Total_quantity"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Paid"].ToString()))
                        oSuspendedSale.Paid = decimal.Parse(ds.Tables[0].Rows[0]["Paid"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Created_by"].ToString()))
                        oSuspendedSale.Created_by = int.Parse(ds.Tables[0].Rows[0]["Created_by"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Updated_by"].ToString()))
                        oSuspendedSale.Updated_by = int.Parse(ds.Tables[0].Rows[0]["Updated_by"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Updated_at"].ToString()))
                        oSuspendedSale.Updated_at = DateTime.Parse(ds.Tables[0].Rows[0]["Updated_at"].ToString());
                    oSuspendedSale.Note = ds.Tables[0].Rows[0]["Note"].ToString();

                    oSuspendedSale.Store_id = int.Parse(ds.Tables[0].Rows[0]["Store_id"].ToString());
                    oSuspendedSale.Hold_ref = ds.Tables[0].Rows[0]["Hold_ref"].ToString();
                }

            }
            return oSuspendedSale;
        }
    }
}
