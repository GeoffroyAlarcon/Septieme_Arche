using api.services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }


        /// <summary>
        /// Cette méthode permet de récupérer la liste des  50 deriners livres ajoutées dans la base de données.
        /// </summary>
        /// <returns>Liste des livres</returns>
        /// <response code="200">Succès</response>
        /// <response code="204">Echec : Pas de contenu</response>
        /// <response code="500">Echec : Erreur interne</response> 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("api/book/findAllBook")]
        public IActionResult FindAllBook()
        {
            var result = _bookService.findAllBook();
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);


        }



        public IActionResult FindAllBook(int id)
        {
            var result = _bookService.findBookById(id);
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);


        }
    }
}
