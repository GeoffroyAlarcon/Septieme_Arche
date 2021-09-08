using api.models;
using api.septiemarche.models;
using api.services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.septiemarche.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public readonly IOrderService _orderService;
        public readonly IUserService _userService;
        public OrderController(IOrderService orderService, IUserService userService)
        {
            _orderService = orderService;
            _userService = userService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("stockManagerAndValidateOrder")]
        public IActionResult ValidateOrder(User user)
        {
            User findUser = _userService.Auth(user.Email, user.Password);
            if (findUser == null) return Ok("votre compte utilisateur  n'est pas correctes");

            Message message = new Message();
            string result = _orderService.ValidateOrder(findUser.Id);
            message.Success = result;

            return Ok(message);
        }
    }
}
