using api.models;
using api.Repository.Interfaces;
using api.services.Interfaces;
using System;
using System.Collections.Generic;
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

        public Task<Book> findBookById(int id)
        {
            throw new NotImplementedException();
        }

        public void saveBook(Book book)
        {
            throw new NotImplementedException();
        }

        public void updateBook(Book book)
        {
            throw new NotImplementedException();
        }

        public void deleteBook(int id)
        {
            throw new NotImplementedException();
        }
    }
}
