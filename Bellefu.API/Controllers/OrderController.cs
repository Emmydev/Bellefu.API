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
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _order;

        public OrderController(IOrderRepository order)
        {
            _order = order;
        }

        public class OrderObjRespObj
        {
            public IEnumerable<OrderObj> Order { get; set; }
            public ApiResponseStatus Status { get; set; }
        }
        [HttpGet("all-order")]
        public async Task<ActionResult<OrderObjRespObj>> GetAllOrder()
        {
            try
            {
                var response = _order.GetAllOrder();
                return new OrderObjRespObj
                {
                    Order = response,
                    Status = new ApiResponseStatus { IsSuccessful = true, Message = new APIResponseMessage { FriendlyMessage = "Successful" } }
                };
            }
            catch (Exception ex)
            {
                return new OrderObjRespObj
                {
                    Status = new ApiResponseStatus { IsSuccessful = false, Message = new APIResponseMessage { FriendlyMessage = "Error Occurred", TechnicalMessage = ex?.Message } }
                };
            }
        }

        [HttpPost("update-order")]
        public async Task<ActionResult<OrderObjRespObj>> UpdateOrder(OrderObj model)
        {
            try
            {
                var response = _order.UpdateOrder(model);
                return new OrderObjRespObj
                {
                    Status = new ApiResponseStatus { IsSuccessful = response ? true : false, Message = new APIResponseMessage { FriendlyMessage = response ? "Successful" : "Unsuccessful" } }
                };
            }
            catch (Exception ex)
            {
                return new OrderObjRespObj
                {
                    Status = new ApiResponseStatus { IsSuccessful = false, Message = new APIResponseMessage { FriendlyMessage = "Error Occurred", TechnicalMessage = ex?.Message } }
                };
            }
        }
        [HttpDelete("delete-order")]
        public async Task<ActionResult<OrderObjRespObj>> DeleteOrder(int OrderId)
        {
            try
            {
                var response = _order.DeleteOrder(OrderId);
                return new OrderObjRespObj
                {
                    Status = new ApiResponseStatus { IsSuccessful = response ? true : false, Message = new APIResponseMessage { FriendlyMessage = response ? "Successful" : "Unsuccessful" } }
                };
            }
            catch (Exception ex)
            {
                return new OrderObjRespObj
                {
                    Status = new ApiResponseStatus { IsSuccessful = false, Message = new APIResponseMessage { FriendlyMessage = "Error Occurred", TechnicalMessage = ex?.Message } }
                };
            }
        }
        [HttpGet("all/order/OrderId")]
        public async Task<ActionResult<OrderObjRespObj>> GetOrderById(int OrderId)
        {
            try
            {
                var response = _order.GetOrderById(OrderId);
                var respList = new List<OrderObj> { response };
                return new OrderObjRespObj
                {
                    Order = respList,
                    Status = new ApiResponseStatus { IsSuccessful = true, Message = new APIResponseMessage { FriendlyMessage = "Successful" } }
                };
            }
            catch (Exception ex)
            {
                return new OrderObjRespObj
                {
                    Status = new ApiResponseStatus { IsSuccessful = false, Message = new APIResponseMessage { FriendlyMessage = "Error Occurred", TechnicalMessage = ex?.Message } }
                };
            }
        }

        [HttpGet("all/order/MenuId")]
        public async Task<ActionResult<OrderObjRespObj>> GetOrderByMenuId(int MenuId)
        {
            try
            {
                var response = _order.GetOrderByMenuId(MenuId);
                var respList = new List<OrderObj> { response };
                return new OrderObjRespObj
                {
                    Order = respList,
                    Status = new ApiResponseStatus { IsSuccessful = true, Message = new APIResponseMessage { FriendlyMessage = "Successful" } }
                };
            }
            catch (Exception ex)
            {
                return new OrderObjRespObj
                {
                    Status = new ApiResponseStatus { IsSuccessful = false, Message = new APIResponseMessage { FriendlyMessage = "Error Occurred", TechnicalMessage = ex?.Message } }
                };
            }
        }
        [HttpGet("all/order/CustomerId")]
        public async Task<ActionResult<OrderObjRespObj>> GetOrderByCustomerId(int CustomerId)
        {
            try
            {
                var response = _order.GetOrderByCustomerId(CustomerId);
                var respList = new List<OrderObj> { response };
                return new OrderObjRespObj
                {
                    Order = respList,
                    Status = new ApiResponseStatus { IsSuccessful = true, Message = new APIResponseMessage { FriendlyMessage = "Successful" } }
                };
            }
            catch (Exception ex)
            {
                return new OrderObjRespObj
                {
                    Status = new ApiResponseStatus { IsSuccessful = false, Message = new APIResponseMessage { FriendlyMessage = "Error Occurred", TechnicalMessage = ex?.Message } }
                };
            }
        }
        [HttpGet("all/order/customer-name")]
        public async Task<ActionResult<OrderObjRespObj>> GetOrderByCustomerName(string name)
        {
            try
            {
                var response = _order.GetOrderByCustomerName(name);
                var respList = new List<OrderObj> { response };
                return new OrderObjRespObj
                {
                    Order = respList,
                    Status = new ApiResponseStatus { IsSuccessful = true, Message = new APIResponseMessage { FriendlyMessage = "Successful" } }
                };
            }
            catch (Exception ex)
            {
                return new OrderObjRespObj
                {
                    Status = new ApiResponseStatus { IsSuccessful = false, Message = new APIResponseMessage { FriendlyMessage = "Error Occurred", TechnicalMessage = ex?.Message } }
                };
            }
        }
        [HttpGet("all/order/menu-name")]
        public async Task<ActionResult<OrderObjRespObj>> GetOrderByMenuName(string name)
        {
            try
            {
                var response = _order.GetOrderByMenuName(name);
                var respList = new List<OrderObj> { response };
                return new OrderObjRespObj
                {
                    Order = respList,
                    Status = new ApiResponseStatus { IsSuccessful = true, Message = new APIResponseMessage { FriendlyMessage = "Successful" } }
                };
            }
            catch (Exception ex)
            {
                return new OrderObjRespObj
                {
                    Status = new ApiResponseStatus { IsSuccessful = false, Message = new APIResponseMessage { FriendlyMessage = "Error Occurred", TechnicalMessage = ex?.Message } }
                };
            }
        }
    }
}
