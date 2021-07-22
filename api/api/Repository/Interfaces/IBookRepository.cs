using api.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repository.Interfaces
{
    public interface IBookRepository
    {
        public  List<Book> findAllBook();
        public Book findBookById(int id);
        public void saveBook(Book book);
        public void updateBook(Book book);
        public void deleteBook(int id);
    }
}
