using DAL;
using POCO;
using System;
using System.Collections.Generic;
using System.Data;

namespace DBL
{
    public class GiftCardDBL
    {
        GiftCardDAL oGiftCardsDAL = new GiftCardDAL();

        /// <summary>
        /// M_GiftCards_GetAll
        /// </summary>
        /// <returns></returns>
        public List<GiftCard> M_GiftCards_GetAll()
        {
            DataSet ds = new DataSet();
            GiftCard oGiftCards;
            List<GiftCard> oLGiftCards = new List<GiftCard>();
            ds = oGiftCardsDAL.M_GiftCards_GetAll();
            if (ds.Tables.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    oGiftCards = new GiftCard();
                   
                    oGiftCards.Id = int.Parse(ds.Tables[0].Rows[i]["Id"].ToString());
                    oGiftCards.Card_no = ds.Tables[0].Rows[i]["Card_no"].ToString();
                    oGiftCards.Balance = decimal.Parse(ds.Tables[0].Rows[i]["Balance"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[i]["Customer_id"].ToString()))
                        oGiftCards.Customer_id = int.Parse(ds.Tables[0].Rows[i]["Customer_id"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[i]["Expiry"].ToString()))
                        oGiftCards.Expiry = DateTime.Parse(ds.Tables[0].Rows[i]["Expiry"].ToString());
                   
                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[i]["Created_by"].ToString()))
                        oGiftCards.Created_by = int.Parse(ds.Tables[0].Rows[i]["Created_by"].ToString());
                    
                    oGiftCards.Date = DateTime.Parse(ds.Tables[0].Rows[i]["Date"].ToString());
                    oGiftCards.Store_id = int.Parse(ds.Tables[0].Rows[i]["Store_id"].ToString());
                    oGiftCards.Value = decimal.Parse(ds.Tables[0].Rows[i]["Value"].ToString());

                    oLGiftCards.Add(oGiftCards);
                }
            }
            return oLGiftCards;
        }

        /// <summary>
        /// M_GiftCards_GetById
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public GiftCard M_GiftCards_GetById(int Id)
        {
            DataSet ds = new DataSet();
            GiftCard oGiftCards = new GiftCard();

            ds = oGiftCardsDAL.M_GiftCards_GetById(Id);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    oGiftCards.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                    oGiftCards.Card_no = ds.Tables[0].Rows[0]["Card_no"].ToString();
                    oGiftCards.Balance = decimal.Parse(ds.Tables[0].Rows[0]["Balance"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Customer_id"].ToString()))
                        oGiftCards.Customer_id = int.Parse(ds.Tables[0].Rows[0]["Customer_id"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Expiry"].ToString()))
                        oGiftCards.Expiry = DateTime.Parse(ds.Tables[0].Rows[0]["Expiry"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Created_by"].ToString()))
                        oGiftCards.Created_by = int.Parse(ds.Tables[0].Rows[0]["Created_by"].ToString());

                    oGiftCards.Date = DateTime.Parse(ds.Tables[0].Rows[0]["Date"].ToString());
                    oGiftCards.Store_id = int.Parse(ds.Tables[0].Rows[0]["Store_id"].ToString());
                    oGiftCards.Value = decimal.Parse(ds.Tables[0].Rows[0]["Value"].ToString());
                }

            }
            return oGiftCards;
        }

        /// <summary>
        /// M_GiftCards_Delete
        /// </summary>
        /// <param name="Id"></param>
        public void M_GiftCards_Delete(int Id)
        {
            DataSet ds = new DataSet();
            GiftCard oGiftCards = new GiftCard();
            ds = oGiftCardsDAL.M_GiftCards_Delete(Id);
        }

        public GiftCard M_Store_Insert(GiftCard PoGiftCards)
        {
            DataSet ds = new DataSet();
            GiftCard oGiftCards = new GiftCard();
            ds = oGiftCardsDAL.M_GiftCards_Insert(PoGiftCards.Card_no.Trim(), PoGiftCards.Value, PoGiftCards.Customer_id, PoGiftCards.Balance, PoGiftCards.Expiry
                , PoGiftCards.Created_by, PoGiftCards.Store_id);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    oGiftCards.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                    oGiftCards.Card_no = ds.Tables[0].Rows[0]["Card_no"].ToString();
                    oGiftCards.Balance = decimal.Parse(ds.Tables[0].Rows[0]["Balance"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Customer_id"].ToString()))
                        oGiftCards.Customer_id = int.Parse(ds.Tables[0].Rows[0]["Customer_id"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Expiry"].ToString()))
                        oGiftCards.Expiry = DateTime.Parse(ds.Tables[0].Rows[0]["Expiry"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Created_by"].ToString()))
                        oGiftCards.Created_by = int.Parse(ds.Tables[0].Rows[0]["Created_by"].ToString());

                    oGiftCards.Date = DateTime.Parse(ds.Tables[0].Rows[0]["Date"].ToString());
                    oGiftCards.Store_id = int.Parse(ds.Tables[0].Rows[0]["Store_id"].ToString());
                    oGiftCards.Value = decimal.Parse(ds.Tables[0].Rows[0]["Value"].ToString());
                }

            }
            return oGiftCards;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="PoGiftCards"></param>
        /// <returns></returns>
        public GiftCard M_Store_Update(GiftCard PoGiftCards)
        {
            DataSet ds = new DataSet();
            GiftCard oGiftCards = new GiftCard();
            ds = oGiftCardsDAL.M_GiftCards_Update(PoGiftCards.Id,PoGiftCards.Card_no, PoGiftCards.Value, PoGiftCards.Customer_id, PoGiftCards.Balance, PoGiftCards.Expiry
                , PoGiftCards.Store_id);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    oGiftCards.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                    oGiftCards.Card_no = ds.Tables[0].Rows[0]["Card_no"].ToString();
                    oGiftCards.Balance = decimal.Parse(ds.Tables[0].Rows[0]["Balance"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Customer_id"].ToString()))
                        oGiftCards.Customer_id = int.Parse(ds.Tables[0].Rows[0]["Customer_id"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Expiry"].ToString()))
                        oGiftCards.Expiry = DateTime.Parse(ds.Tables[0].Rows[0]["Expiry"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Created_by"].ToString()))
                        oGiftCards.Created_by = int.Parse(ds.Tables[0].Rows[0]["Created_by"].ToString());

                    oGiftCards.Date = DateTime.Parse(ds.Tables[0].Rows[0]["Date"].ToString());
                    oGiftCards.Store_id = int.Parse(ds.Tables[0].Rows[0]["Store_id"].ToString());
                    oGiftCards.Value = decimal.Parse(ds.Tables[0].Rows[0]["Value"].ToString());
                }

            }
            return oGiftCards;
        }

        /// <summary>
        /// M_GiftCards_GetById
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public GiftCard M_GiftCards_GetByCardNo(string CardNo)
        {
            DataSet ds = new DataSet();
            GiftCard oGiftCards = new GiftCard();

            ds = oGiftCardsDAL.M_GiftCards_GetByCardNo(CardNo);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    oGiftCards.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                    oGiftCards.Card_no = ds.Tables[0].Rows[0]["Card_no"].ToString();
                    oGiftCards.Balance = decimal.Parse(ds.Tables[0].Rows[0]["Balance"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Customer_id"].ToString()))
                        oGiftCards.Customer_id = int.Parse(ds.Tables[0].Rows[0]["Customer_id"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Expiry"].ToString()))
                        oGiftCards.Expiry = DateTime.Parse(ds.Tables[0].Rows[0]["Expiry"].ToString());

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Created_by"].ToString()))
                        oGiftCards.Created_by = int.Parse(ds.Tables[0].Rows[0]["Created_by"].ToString());

                    oGiftCards.Date = DateTime.Parse(ds.Tables[0].Rows[0]["Date"].ToString());
                    oGiftCards.Store_id = int.Parse(ds.Tables[0].Rows[0]["Store_id"].ToString());
                    oGiftCards.Value = decimal.Parse(ds.Tables[0].Rows[0]["Value"].ToString());
                }

            }
            return oGiftCards;
        }
    }
}
