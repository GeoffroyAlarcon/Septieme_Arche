using api.models;
using api.services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.services
{
    public class BookService : IBookService
    {
  

        public Task<List<Book>> findAllBook()
        {
            throw new NotImplementedException();
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
