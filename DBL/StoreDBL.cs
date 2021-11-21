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
    public class StoreDBL
    {
        StoreDAL oStoreDAL = new StoreDAL();

        /// <summary>
        /// M_Store_GetAll
        /// </summary>
        /// <returns></returns>
        public List<Store> M_Store_GetAll()
        {
            DataSet ds = new DataSet();
            Store oStore;
            List<Store> oLStore = new List<Store>();
            ds = oStoreDAL.M_Store_GetAll();
            if (ds.Tables.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    oStore = new Store();
                    oStore.Id = int.Parse(ds.Tables[0].Rows[i]["Id"].ToString());
                    oStore.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                    oStore.Code = ds.Tables[0].Rows[i]["Code"].ToString();
                    oStore.Logo = ds.Tables[0].Rows[i]["Logo"].ToString();
                    oStore.Email = ds.Tables[0].Rows[i]["Email"].ToString();
                    oStore.Phone = ds.Tables[0].Rows[i]["Phone"].ToString();
                    oStore.Address1 = ds.Tables[0].Rows[i]["Address1"].ToString();
                    oStore.Address2 = ds.Tables[0].Rows[i]["Address2"].ToString();
                    oStore.City = ds.Tables[0].Rows[i]["City"].ToString();
                    oStore.State = ds.Tables[0].Rows[i]["State"].ToString();
                    oStore.Postal_code = ds.Tables[0].Rows[i]["Postal_code"].ToString();
                    oStore.Country = ds.Tables[0].Rows[i]["Country"].ToString();
                    oStore.Currency_code = ds.Tables[0].Rows[i]["Currency_code"].ToString();
                    oStore.Receipt_header = ds.Tables[0].Rows[i]["Receipt_header"].ToString();
                    oStore.Receipt_footer = ds.Tables[0].Rows[i]["Receipt_footer"].ToString();

                    oLStore.Add(oStore);
                }
            }
            return oLStore;
        }

        /// <summary>
        /// M_Store_Insert
        /// </summary>
        /// <param name="PoStore"></param>
        /// <returns></returns>
        public Store M_Store_Insert(Store PoStore)
        {
            DataSet ds = new DataSet();
            Store oStore = new Store();
            ds = oStoreDAL.M_Store_Insert(PoStore.Name, PoStore.Code, PoStore.Logo, PoStore.Email, PoStore.Phone, PoStore.Address1, PoStore.Address2, PoStore.City,
                PoStore.State, PoStore.Postal_code, PoStore.Country, PoStore.Currency_code, PoStore.Receipt_header, PoStore.Receipt_footer);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    oStore.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                    oStore.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                    oStore.Code = ds.Tables[0].Rows[0]["Code"].ToString();
                    oStore.Logo = ds.Tables[0].Rows[0]["Logo"].ToString();
                    oStore.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                    oStore.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                    oStore.Address1 = ds.Tables[0].Rows[0]["Address1"].ToString();
                    oStore.Address2 = ds.Tables[0].Rows[0]["Address2"].ToString();
                    oStore.City = ds.Tables[0].Rows[0]["City"].ToString();
                    oStore.State = ds.Tables[0].Rows[0]["State"].ToString();
                    oStore.Postal_code = ds.Tables[0].Rows[0]["Postal_code"].ToString();
                    oStore.Country = ds.Tables[0].Rows[0]["Country"].ToString();
                    oStore.Currency_code = ds.Tables[0].Rows[0]["Currency_code"].ToString();
                    oStore.Receipt_header = ds.Tables[0].Rows[0]["Receipt_header"].ToString();
                    oStore.Receipt_footer = ds.Tables[0].Rows[0]["Receipt_footer"].ToString();
                }

            }
            return oStore;
        }

        /// <summary>
        /// M_Store_GetById
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Store M_Store_GetById(int Id)
        {
            DataSet ds = new DataSet();
            Store oStore = new Store();
            ds = oStoreDAL.M_Store_GetById(Id);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    oStore.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                    oStore.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                    oStore.Code = ds.Tables[0].Rows[0]["Code"].ToString();
                    oStore.Logo = ds.Tables[0].Rows[0]["Logo"].ToString();
                    oStore.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                    oStore.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                    oStore.Address1 = ds.Tables[0].Rows[0]["Address1"].ToString();
                    oStore.Address2 = ds.Tables[0].Rows[0]["Address2"].ToString();
                    oStore.City = ds.Tables[0].Rows[0]["City"].ToString();
                    oStore.State = ds.Tables[0].Rows[0]["State"].ToString();
                    oStore.Postal_code = ds.Tables[0].Rows[0]["Postal_code"].ToString();
                    oStore.Country = ds.Tables[0].Rows[0]["Country"].ToString();
                    oStore.Currency_code = ds.Tables[0].Rows[0]["Currency_code"].ToString();
                    oStore.Receipt_header = ds.Tables[0].Rows[0]["Receipt_header"].ToString();
                    oStore.Receipt_footer = ds.Tables[0].Rows[0]["Receipt_footer"].ToString();
                }

            }
            return oStore;
        }

        /// <summary>
        /// M_Store_Delete
        /// </summary>
        /// <param name="Id"></param>
        public void M_Store_Delete(int Id)
        {
            DataSet ds = new DataSet();
            Store oStore = new Store();
            ds = oStoreDAL.M_Store_Delete(Id);
        }

        /// <summary>
        /// M_Store_Update
        /// </summary>
        /// <param name="PoStore"></param>
        /// <returns></returns>
        public Store M_Store_Update(Store PoStore)
        {
            DataSet ds = new DataSet();
            Store oStore = new Store();
            ds = oStoreDAL.M_Store_Update(PoStore.Id, PoStore.Name, PoStore.Code, PoStore.Logo, PoStore.Email, PoStore.Phone, PoStore.Address1, PoStore.Address2, PoStore.City,
                PoStore.State, PoStore.Postal_code, PoStore.Country, PoStore.Currency_code, PoStore.Receipt_header, PoStore.Receipt_footer);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    oStore.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                    oStore.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                    oStore.Code = ds.Tables[0].Rows[0]["Code"].ToString();
                    oStore.Logo = ds.Tables[0].Rows[0]["Logo"].ToString();
                    oStore.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                    oStore.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                    oStore.Address1 = ds.Tables[0].Rows[0]["Address1"].ToString();
                    oStore.Address2 = ds.Tables[0].Rows[0]["Address2"].ToString();
                    oStore.City = ds.Tables[0].Rows[0]["City"].ToString();
                    oStore.State = ds.Tables[0].Rows[0]["State"].ToString();
                    oStore.Postal_code = ds.Tables[0].Rows[0]["Postal_code"].ToString();
                    oStore.Country = ds.Tables[0].Rows[0]["Country"].ToString();
                    oStore.Currency_code = ds.Tables[0].Rows[0]["Currency_code"].ToString();
                    oStore.Receipt_header = ds.Tables[0].Rows[0]["Receipt_header"].ToString();
                    oStore.Receipt_footer = ds.Tables[0].Rows[0]["Receipt_footer"].ToString();

                }

            }
            return oStore;
        }
    }
}
