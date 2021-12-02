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
    public class RegistersDBL
    {
        RegistersDAL oRegistersDAL = new RegistersDAL();

        /// <summary>
        /// OpenRegister
        /// </summary>
        /// <param name="Poegisters"></param>
        /// <returns></returns>
        public Registers OpenRegister(Registers Poegisters)
        {
            DataSet ds = new DataSet();
            Registers oRegisters = new Registers();
            ds = oRegistersDAL.M_Register_OpenRegister(Poegisters.Date, Poegisters.Cash_in_hand, Poegisters.UserId, Poegisters.Store_id, Poegisters.Status);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    oRegisters.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                    oRegisters.Date = DateTime.Parse(ds.Tables[0].Rows[0]["Date"].ToString());
                    oRegisters.Cash_in_hand = decimal.Parse(ds.Tables[0].Rows[0]["Cash_in_hand"].ToString());
                    oRegisters.UserId = int.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
                    oRegisters.Store_id = int.Parse(ds.Tables[0].Rows[0]["Store_id"].ToString());
                    oRegisters.Status = ds.Tables[0].Rows[0]["Status"].ToString();
                }

            }
            return oRegisters;
        }
        public string M_RegisterStatus_Get(int Store_Id, int User_Id)
        {
            DataSet ds = new DataSet();
            ds = oRegistersDAL.M_RegisterStatus_Get(Store_Id, User_Id);
            string Status = "close";
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    Status = ds.Tables[0].Rows[0]["Status"].ToString();
                }

            }
            return Status;
        }
    }
}
