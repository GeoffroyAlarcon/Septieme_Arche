using api.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.services.Interfaces
{
   public interface IBookService
    {
        public List<Book> findAllBook();
        public Book findBookByISBN(string isbn);
        public List<Book> findBytitleOrAuthor(string search);

    }
}
