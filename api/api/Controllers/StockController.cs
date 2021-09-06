using api.models;
using api.septiemarche.models;
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
        private MySqlConnector Db { get; }
        public StockController(IStockService stockService, IUserService userservice )
        {
            _stockService = stockService;
            _userService = userservice;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("verifyStock")]
        public IActionResult VerifyStock([FromBody] Cart cart)
        {
            Message message = new Message();
            string result = "";
            User findUser = _userService.Auth(cart.Customer.Email, cart.Customer.Password);
            if (findUser == null) return Ok(message.error="votre compte utilisateur  n'est pas correctes");

            // je vérifie si la méthode me renvoie une chaine vide ou pas. Si la chaine n'est vide alors cela signifie que le stock est invalide
            string VerifyStockString = _stockService.StockIsValid(cart.LinesItemCart, findUser.Id);
            if (VerifyStockString != string.Empty) {
               message.error = "vootrrrraesrjfdsqjdsjdqsjdsjqjsdj qsqsdjzqj rj&&&&&é ";
                return Ok(message);
            }

             message.succces=  cart.LinesItemCart.Sum(elt => elt.Item.PriceExcludingTax * elt.Amount).ToString() ;
            return Ok(message) ;
        }
    }
}