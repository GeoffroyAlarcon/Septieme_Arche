using api.models;
using api.Repository;
using api.services;
using api.services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UserController : ControllerBase
    {
        private MySqlConnector Db { get; }
       private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger) {
            _userService = userService;
     
            _logger = logger;
        }


        /// <response code="200">Succès</response>
        /// <response code="204">Echec : Pas de contenu</response>
        /// <response code="500">Echec : Erreur interne</response> 
        ///<param name="email"> </param>
        /// /// <param name="password">ISBN</param>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("auth")]
        public  IActionResult Auth(string email, string password)
        {

         
            var result = _userService.Auth(email, password);
            if (result is null) { 
                return new NotFoundResult();
            }

            return new OkObjectResult(result);

        }
        }
}
