﻿using api.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repository.Interfaces
{
    public interface IBookRepository
    {
        public List<Book> findAllBook();
        public Book findBookByISBN(string isbn);
        public List<Book> findBytitleOrAuthor(string search);
    }

}