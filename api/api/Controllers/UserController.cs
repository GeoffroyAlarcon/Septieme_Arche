using api.models;
using api.Repository;
using api.services;
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
        public MySqlConnector Db { get; }

        private readonly ILogger<UserController> _logger;

        public UserController(  MySqlConnector db)
        {
  
            Db = db;
        }

      

        
        /// <response code="200">Succès</response>
        /// <response code="204">Echec : Pas de contenu</response>
        /// <response code="500">Echec : Erreur interne</response> 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("auth")]
        public async Task<IActionResult> Auth()
        {

            await Db.Connection.OpenAsync();
            var query = new UserRepository(Db);
            var result = await query.Auth();
            if (result is null)
                return new NotFoundResult();
            return new OkObjectResult(result);



        }
        }
}
