using api.models;
using api.Repository;
using api.services;
using api.services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
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

        public UserController(IUserService userService, ILogger<UserController> logger, IConfiguration configuration) {
            _userService = userService;
            _configuration = configuration;
            _logger = logger;
        }

    private IConfiguration _configuration { get; }
        /// <response code="200">Succès</response>
        /// <response code="204">Echec : Pas de contenu</response>
        /// <response code="500">Echec : Erreur interne</response> 
        ///<param name="email"> </param>
        /// /// <param name="password">ISBN</param>
        [HttpPost]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("auth")]
        public  IActionResult Auth(User user)
        {
            IActionResult response = Unauthorized();

            User result = null;
            result = _userService.Auth(user.Email, user.Password);
            if (result is null) { 
                return new NotFoundResult();
            }
            else
            {
                var tokenString = GenerateJSONWebToken(result);
                response = Ok(new { user=result, token = tokenString });
            }
            return response;

        }
        /// <response code="200">Succès</response>
        /// <response code="204">Echec : Pas de contenu</response>
        /// <response code="500">Echec : Erreur interne</response> 
        ///<param name="email"> </param>
        /// /// <param name="password">ISBN</param>
        [HttpPost]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("auth")]
        public IActionResult   addCustomer(Customer customer)

        {
            IActionResult response = Unauthorized();

            User result = null;
            result = _userService.addCustomer(customer);
            if (result is null)
            {
                return new NotFoundResult();
            }
  
            return Ok("");

        }





        private string GenerateJSONWebToken(User userInfo)
{
    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

    var claims = new[] {
        new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
        new Claim("password",  userInfo.Password),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
        _configuration["Jwt:Issuer"],
        claims,
        expires: DateTime.Now.AddMinutes(120),
        signingCredentials: credentials);

    return new JwtSecurityTokenHandler().WriteToken(token);


}
        }
}
