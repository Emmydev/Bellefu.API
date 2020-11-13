using Bellefu.API.Dtos;
using Bellefu.API.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bellefu.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customer;

        public CustomerController(ICustomerRepository customer)
        {
            _customer = customer;
        }

        public class CustomerObjRespObj
        {
            public IEnumerable<CustomerObj> Customers { get; set; }
            public ApiResponseStatus Status { get; set; }
        }
        [HttpGet("all-customers")]
        public async Task<ActionResult<CustomerObjRespObj>> GetAllCustomers()
        {
            try
            {
                var response = _customer.GetAllCustomers();
                return new CustomerObjRespObj
                {
                    Customers = response,
                    Status = new ApiResponseStatus { IsSuccessful = true, Message = new APIResponseMessage { FriendlyMessage = "Successful" } }
                };
            }
            catch (Exception ex)
            {
                return new CustomerObjRespObj
                {
                    Status = new ApiResponseStatus { IsSuccessful = false, Message = new APIResponseMessage { FriendlyMessage = "Error Occurred", TechnicalMessage = ex?.Message } }
                };
            }
        }

        [HttpPost("update-customer")]
        public async Task<ActionResult<CustomerObjRespObj>> UpdateCustomer(CustomerObj model)
        {
            try
            {
                var response = _customer.UpdateCustomer(model);
                return new CustomerObjRespObj
                {
                    Status = new ApiResponseStatus { IsSuccessful = response ? true : false, Message = new APIResponseMessage { FriendlyMessage = response ? "Successful" : "Unsuccessful" } }
                };
            }
            catch (Exception ex)
            {
                return new CustomerObjRespObj
                {
                    Status = new ApiResponseStatus { IsSuccessful = false, Message = new APIResponseMessage { FriendlyMessage = "Error Occurred", TechnicalMessage = ex?.Message } }
                };
            }
        }


        [HttpDelete("delete-customer")]
        public async Task<ActionResult<CustomerObjRespObj>> DeleteCustomer(int CustomerId)
        {
            try
            {
                var response = _customer.DeleteCustomer(CustomerId);
                return new CustomerObjRespObj
                {
                    Status = new ApiResponseStatus { IsSuccessful = response ? true : false, Message = new APIResponseMessage { FriendlyMessage = response ? "Successful" : "Unsuccessful" } }
                };
            }
            catch (Exception ex)
            {
                return new CustomerObjRespObj
                {
                    Status = new ApiResponseStatus { IsSuccessful = false, Message = new APIResponseMessage { FriendlyMessage = "Error Occurred", TechnicalMessage = ex?.Message } }
                };
            }
        }

        [HttpDelete("delete-multi-customer")]
        public async Task<ActionResult<CustomerObjRespObj>> DeleteMultiCustomer(int[] Id)
        {
            try
            {
                foreach(int i in Id)
                {
                    var response = _customer.DeleteMultiCustomer(Id);
                    return new CustomerObjRespObj
                    {
                        Status = new ApiResponseStatus { IsSuccessful = response ? true : false, Message = new APIResponseMessage { FriendlyMessage = response ? "Successful" : "Unsuccessful" } }
                    };

                }
                
            }
            catch (Exception ex)
            {
                return new CustomerObjRespObj
                {
                    Status = new ApiResponseStatus { IsSuccessful = false, Message = new APIResponseMessage { FriendlyMessage = "Error Occurred", TechnicalMessage = ex?.Message } }
                };
            }

            return null;

        }

        [HttpGet("all/customers/Id")]
        public async Task<ActionResult<CustomerObjRespObj>> GetCustomerById(int CustomerId)
        {
            try
            {
                var response = _customer.GetCustomerById(CustomerId);
                var respList = new List<CustomerObj> { response };
                return new CustomerObjRespObj
                {
                    Customers = respList,
                    Status = new ApiResponseStatus { IsSuccessful = true, Message = new APIResponseMessage { FriendlyMessage = "Successful" } }
                };
            }
            catch (Exception ex)
            {
                return new CustomerObjRespObj
                {
                    Status = new ApiResponseStatus { IsSuccessful = false, Message = new APIResponseMessage { FriendlyMessage = "Error Occurred", TechnicalMessage = ex?.Message } }
                };
            }
        }

    }
       
}
