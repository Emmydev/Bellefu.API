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
    public class MenuController : ControllerBase
    {
        private readonly IMenuRepository _menu;

        public MenuController(IMenuRepository menu)
        {
            _menu = menu;
        }

        public class MenuObjRespObj
        {
            public IEnumerable<MenuObj> Menu { get; set; }
            public ApiResponseStatus Status { get; set; }

        }

        [HttpGet("all-menu")]
        public async Task<ActionResult<MenuObjRespObj>> GetAllMenu()
        {
            try 
            {
                var response = _menu.GetAllMenu();
                return new MenuObjRespObj
                {
                    Menu = response,
                    Status = new ApiResponseStatus { IsSuccessful = true, Message = new APIResponseMessage { FriendlyMessage = "Successfull" } }

                };
            }
            catch(Exception ex)
            {
                return new MenuObjRespObj
                {
                    Status = new ApiResponseStatus { IsSuccessful = false, Message = new APIResponseMessage { FriendlyMessage = "Error Occurred", TechnicalMessage = ex?.Message} }
                };

            }
        }

        [HttpPost("update-menu")]
        public async Task<ActionResult<MenuObjRespObj>> UpdateMenu(MenuObj model)
        {
            try
            {
                var response = _menu.UpdateMenu(model);
                return new MenuObjRespObj
                {
                    Status = new ApiResponseStatus { IsSuccessful = response ? true : false, Message = new APIResponseMessage { FriendlyMessage = response ? "Successful" : "UnSuccessful" } }
                };
            }
            catch(Exception ex)
            {
                return new MenuObjRespObj
                {
                    Status = new ApiResponseStatus { IsSuccessful = false, Message = new APIResponseMessage { FriendlyMessage = "Error Occurred", TechnicalMessage = ex?.Message } }
                };
            }
        }

        [HttpDelete("delete-menu")]
        public async Task<ActionResult<MenuObjRespObj>> DeleteMenu(int MenuId)
        {
            try
            {
                var response = _menu.DeleteMenu(MenuId);
                return new MenuObjRespObj
                {
                    Status = new ApiResponseStatus { IsSuccessful = response ? true : false, Message = new APIResponseMessage { FriendlyMessage = response ? "Successful" : "UnSuccessful" } }
                };
            }
            catch(Exception ex)
            {
                return new MenuObjRespObj
                {
                    Status = new ApiResponseStatus { IsSuccessful = false, Message = new APIResponseMessage { FriendlyMessage = "Error Occurred", TechnicalMessage = ex?.Message } }
                };
            }
        }

        [HttpGet("all/menu/id")]
        public async Task<ActionResult<MenuObjRespObj>> GetMenuById(int MenuId)
        {
            try
            {
                var response = _menu.GetMenuById(MenuId);
                var respList = new List<MenuObj> { response };
                return new MenuObjRespObj
                {
                    Menu = respList,
                    Status = new ApiResponseStatus { IsSuccessful = true, Message = new APIResponseMessage { FriendlyMessage = "Successful"} }
                   
                };
            }
            catch(Exception ex)
            {
                return new MenuObjRespObj
                {
                    Status = new ApiResponseStatus { IsSuccessful = false, Message = new APIResponseMessage { FriendlyMessage = "Error Occurred", TechnicalMessage = ex?.Message} }
                };
            }

        }

    }
}
