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
    public class ReportingController : ControllerBase
    {
      private readonly  IReportingService _reportingService;
      private readonly  IUserService _userService;
        public ReportingController(IReportingService reportingService, IUserService userService)
        {
            _reportingService = reportingService;
            _userService = userService;
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
        [Route("Stockisempty")]
       
        public IActionResult Stockisempty(User user)
        {

            Message message = new Message();
            User findUser = _userService.AuthbyMarketing(user.Email, user.Password);
            if (findUser == null) return Ok(message.Error = "Vous n'avez pas l'autorisation d'accéder à cette fonctionnalité");
            var result = _reportingService.Stockisempty();
          return  Ok(result);
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
        [Route("TopTenItemMostSold")]

        public IActionResult TopTenItemMostSold(User user)
        {

            Message message = new Message();
            User findUser = _userService.AuthbyMarketing(user.Email, user.Password);
            if (findUser == null) return Ok(message.Error = "Vous n'avez pas l'autorisation d'accéder à cette fonctionnalité");
            var result = _reportingService.TopTenItemMostSold();
        return     Ok(result);
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
        [Route("TopTenItemMostView")]

        public IActionResult TopTenItemMostView(User user)
        {
            Message message = new Message();
           User findUser= _userService.AuthbyMarketing(user.Email, user.Password);
            if (findUser == null) return Ok(message.Error="Vous n'avez pas l'autorisation d'accéder à cette fonctionnalité");
            var result = _reportingService.TopTenItemMostView();
            return Ok(result);
        }
    }

   
}
