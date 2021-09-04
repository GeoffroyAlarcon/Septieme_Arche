using api.models;
using api.septiemarche.services.Interfaces;
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
    public class StockController : ControllerBase
    {
        private readonly IUserService  _userService;
        private readonly IStockService _stockService;
    
        public StockController(IStockService stockService, IUserService userservice )
        {
            _stockService = stockService;
            _userService = userservice;
        }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("auth")]
    public string VerifyStock(List<lineItemCart> cart,u customer)
    {
        User findUser = _userService.Auth(customer.Email, customer.Password);
        if (findUser == null) return "votre compte utilisateur  n'est pas correctes";
    }
}
}