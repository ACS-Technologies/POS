using DAL;
using POCO;
using System;
using System.Collections.Generic;
using System.Data;

namespace DBL
{
    public class SupplierDBL
    {
        SupplierDAL oSuppliersDAL = new SupplierDAL();

        /// <summary>
        /// M_Suppliers_GetAll
        /// </summary>
        /// <returns></returns>
        public List<Supplier> M_Suppliers_GetAll()
        {
            DataSet ds = new DataSet();
            Supplier oSuppliers;
            List<Supplier> oLSuppliers = new List<Supplier>();
            ds = oSuppliersDAL.M_Suppliers_GetAll();
            if (ds.Tables.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    oSuppliers = new Supplier();
                    oSuppliers.Id = int.Parse(ds.Tables[0].Rows[i]["Id"].ToString());
                    oSuppliers.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                    oSuppliers.Phone = ds.Tables[0].Rows[i]["Phone"].ToString();
                    oSuppliers.Cf1 = ds.Tables[0].Rows[i]["Cf1"].ToString();
                    oSuppliers.Cf2 = ds.Tables[0].Rows[i]["Cf2"].ToString();
                    oSuppliers.Email = ds.Tables[0].Rows[i]["Email"].ToString();

                    oLSuppliers.Add(oSuppliers);
                }
            }
            return oLSuppliers;
        }

        /// <summary>
        /// M_Suppliers_GetById
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Supplier M_Suppliers_GetById(int Id)
        {
            DataSet ds = new DataSet();
            Supplier oSuppliers = new Supplier();

            ds = oSuppliersDAL.M_Suppliers_GetById(Id);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    oSuppliers.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                    oSuppliers.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                    oSuppliers.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                    oSuppliers.Cf1 = ds.Tables[0].Rows[0]["Cf1"].ToString();
                    oSuppliers.Cf2 = ds.Tables[0].Rows[0]["Cf2"].ToString();
                    oSuppliers.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                }

            }
            return oSuppliers;
        }

        /// <summary>
        /// M_Suppliers_Delete
        /// </summary>
        /// <param name="Id"></param>
        public void M_Suppliers_Delete(int Id)
        {
            DataSet ds = new DataSet();
            Supplier oSuppliers = new Supplier();
            ds = oSuppliersDAL.M_Suppliers_Delete(Id);
        }

        public Supplier M_Store_Insert(Supplier PoSuppliers)
        {
            DataSet ds = new DataSet();
            Supplier oSuppliers = new Supplier();
            ds = oSuppliersDAL.M_Suppliers_Insert(PoSuppliers.Name,PoSuppliers.Cf1, PoSuppliers.Cf2, PoSuppliers.Phone, PoSuppliers.Email);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    oSuppliers.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                    oSuppliers.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                    oSuppliers.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                    oSuppliers.Cf1 = ds.Tables[0].Rows[0]["Cf1"].ToString();
                    oSuppliers.Cf2 = ds.Tables[0].Rows[0]["Cf2"].ToString();
                    oSuppliers.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                }

            }
            return oSuppliers;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="PoSuppliers"></param>
        /// <returns></returns>
        public Supplier M_Store_Update(Supplier PoSuppliers)
        {
            DataSet ds = new DataSet();
            Supplier oSuppliers = new Supplier();
            ds = oSuppliersDAL.M_Suppliers_Update(PoSuppliers.Id, PoSuppliers.Name, PoSuppliers.Cf1, PoSuppliers.Cf2, PoSuppliers.Phone, PoSuppliers.Email);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    oSuppliers.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                    oSuppliers.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                    oSuppliers.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                    oSuppliers.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                    oSuppliers.Cf1 = ds.Tables[0].Rows[0]["Cf1"].ToString();
                    oSuppliers.Cf2 = ds.Tables[0].Rows[0]["Cf2"].ToString();
                    oSuppliers.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                }

            }
            return oSuppliers;
        }
    }
}
