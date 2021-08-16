using api.models;
using api.Repository.Interfaces;
using api.services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace api.services
{
    public class BookService : IBookService
    {
  private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public List<Book> findAllBook()
        {
            var result = _bookRepository.findAllBook();
            return result;

        }

        public  Book findBookByISBN(string isbn)
        {
            Book result = null;
            bool isDigital = _bookRepository.isDigital(isbn);


            if   (isDigital == false){ 

             result = _bookRepository.findBookByISBN(isbn);
            }
            else
            {
                result = _bookRepository.findDigitalBookByISBN(isbn);
            }

            return result;
        }

        public List<Book> findBytitleOrAuthor(string search)
        {
            var result = _bookRepository.findBytitleOrAuthor(search);

            return result;

        }
    }
}
