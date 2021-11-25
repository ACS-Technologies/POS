using DBL;
using POCO;
using POS.Models;
using System;
using System.Web.Mvc;

namespace POS.Controllers
{
    public class GiftCardsController : BaseController
    {
        GiftCardDBL oGiftCardDBL;
        ResultJson result;

        /// <summary>
        /// View
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult View(int Id)
        {
            try
            {
                oGiftCardDBL = new GiftCardDBL();
                var model  = oGiftCardDBL.M_GiftCards_GetById(Id);
                return View(model);
            }
            catch
            {
                return View(new GiftCard());
            }
        }

        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult GetById(int Id)
        {
            result = new ResultJson();

            try
            {
                oGiftCardDBL = new GiftCardDBL();
                result.IsSuccess = true;
                result.Data = oGiftCardDBL.M_GiftCards_GetById(Id);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                result.IsSuccess = false;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAll()
        {
            result = new ResultJson();

            try
            {
                oGiftCardDBL = new GiftCardDBL();
                result.IsSuccess = true;
                result.Data = oGiftCardDBL.M_GiftCards_GetAll();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                result.IsSuccess = false;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int Id)
        {
            result = new ResultJson();

            try
            {
                oGiftCardDBL = new GiftCardDBL();
                oGiftCardDBL.M_GiftCards_Delete(Id);
                result.IsSuccess = true;
                return Json(result);
            }
            catch
            {
                result.IsSuccess = false;
                return Json(result);
            }
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="PoGiftCards"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Insert(GiftCard PoGiftCards)
        {
            result = new ResultJson();
            oGiftCardDBL = new GiftCardDBL();

            try
            {
                if(string.IsNullOrEmpty(PoGiftCards.Card_no))
                {
                    result.IsSuccess = false;
                    result.Errors.Add("Card No is required");
                    return Json(result);
                }

                if (PoGiftCards.Value <= 0)
                {
                    result.IsSuccess = false;
                    result.Errors.Add("Value is required");
                    return Json(result);
                }

                var giftCard = oGiftCardDBL.M_GiftCards_GetByCardNo(PoGiftCards.Card_no.Trim());

                if(giftCard.Id > 0) // exist
                {
                    result.IsSuccess = false;
                    result.Errors.Add("Card No is should be unique");
                    return Json(result);
                }

                PoGiftCards.Balance = PoGiftCards.Value;
                result.IsSuccess = true;
                PoGiftCards.Created_by = SessionManager.GetSessionUserInfo.UserID;
                result.Data = oGiftCardDBL.M_Store_Insert(PoGiftCards);
                return Json(result);

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                return Json(result);
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="PoGiftCards"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update(GiftCard PoGiftCards)
        {
            result = new ResultJson();
            oGiftCardDBL = new GiftCardDBL();

            try
            {
                if (string.IsNullOrEmpty(PoGiftCards.Card_no))
                {
                    result.IsSuccess = false;
                    result.Errors.Add("Card No is required");
                    return Json(result);
                }

                if (PoGiftCards.Value <= 0)
                {
                    result.IsSuccess = false;
                    result.Errors.Add("Value is required");
                    return Json(result);
                }

                var giftCard = oGiftCardDBL.M_GiftCards_GetByCardNo(PoGiftCards.Card_no.Trim());

                if (giftCard.Id > 0 && giftCard.Id != PoGiftCards.Id) // exist
                {
                    result.IsSuccess = false;
                    result.Errors.Add("Card No is should be unique");
                    return Json(result);
                }

                var oldGiftCard = oGiftCardDBL.M_GiftCards_GetById(PoGiftCards.Id);

                PoGiftCards.Balance = PoGiftCards.Value - oldGiftCard.Value + oldGiftCard.Balance; // need to be confirmed
                result.IsSuccess = true;
                result.Data = oGiftCardDBL.M_Store_Update(PoGiftCards);
                return Json(result);

            }
            catch
            {
                result.IsSuccess = false;
                return Json(result);
            }
        }


        [HttpPost]
        public ActionResult SellGiftCard(GiftCard PoGiftCards)
        {
            result = new ResultJson();
            oGiftCardDBL = new GiftCardDBL();

            try
            {
                if (string.IsNullOrEmpty(PoGiftCards.Card_no))
                {
                    result.IsSuccess = false;
                    result.Errors.Add("Card No is required");
                    return Json(result);
                }

                if (PoGiftCards.Value <= 0)
                {
                    result.IsSuccess = false;
                    result.Errors.Add("Value is required");
                    return Json(result);
                }

                var giftCard = oGiftCardDBL.M_GiftCards_GetByCardNo(PoGiftCards.Card_no.Trim());

                if (giftCard.Id > 0) // exist
                {
                    result.IsSuccess = false;
                    result.Errors.Add("Card No is should be unique");
                    return Json(result);
                }

                PoGiftCards.Balance = PoGiftCards.Value;
                result.IsSuccess = true;
                PoGiftCards.Created_by = SessionManager.GetSessionUserInfo.UserID;
                result.Data = oGiftCardDBL.M_Store_Insert(PoGiftCards);
                return Json(result);

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                return Json(result);
            }
        }
    }
}