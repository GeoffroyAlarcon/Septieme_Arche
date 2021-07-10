﻿using api.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repository.Interfaces
{
    interface IBookRepository
    {
        public  Task<List<Book>> findAllBook();
        public Task<Book> findBookById(int id);
        public void saveBook(Book book);
        public void updateBook(Book book);
        public void deleteBook(int id);
    }
}
