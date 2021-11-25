using POS.API.Models;
using DBL;
using System;
using System.Web.Http;
using POCO;
using Swashbuckle.Swagger.Annotations;

namespace POS.API.Controllers
{
    public class SalesController : ApiController
    {
        [HttpGet]
        public Response GetById(int Id)
        {
            try
            {
                var oSalesDBL = new SalesDBL();
                var result = oSalesDBL.M_Sales_GetById(Id);

                Response response = new Response
                {
                    IsScusses = true,
                    ResponseDetails = result
                };
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public Response GetAll(int? UserId)
        {
            try
            {
                var oSalesDBL = new SalesDBL();
                var result = oSalesDBL.M_Sales_GetAll(UserId);

                Response response = new Response
                {
                    IsScusses = true,
                    ResponseDetails = result
                };
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public Response Delete(int Id)
        {
            try
            {
                var oSalesDBL = new SalesDBL();
                oSalesDBL.M_Sales_Delete(Id);

                Response response = new Response
                {
                    IsScusses = true
                };
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public Response Insert(Sales PoSales)
        {
            try
            {
                var oSalesDBL = new SalesDBL();
                var result = oSalesDBL.M_Store_Insert(PoSales);

                Response response = new Response
                {
                    IsScusses = true,
                    ResponseDetails = result
                };
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public Response Update(Sales PoSales)
        {
            try
            {
                var oSalesDBL = new SalesDBL();
                var result = oSalesDBL.M_Store_Update(PoSales);

                Response response = new Response
                {
                    IsScusses = true,
                    ResponseDetails = result
                };
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
