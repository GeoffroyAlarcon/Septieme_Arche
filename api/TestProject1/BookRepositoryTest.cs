using api;
using api.services.Interfaces;
using System;
using Xunit;
using api.services;
using api.Repository.Interfaces;
using Moq;
using Microsoft.Extensions.Logging;
using api.Repository;
using api.models;
using System.Collections.Generic;

namespace TestProject1
{

    public class BookRepositoryTest : BaseUnitTest
    {
        private readonly IBookRepository _bookRepository;
        private readonly Mock<ILogger<BookRepository>> mockLoggerBookRepository;
        public BookRepositoryTest()
        {

        }

        [Fact]
        public void Test1()
        {
            BookRepository bookRepository = new BookRepository(base.DB);
            bookRepository.findAllBook();
        }
        [Fact]
        public void VerifyTitleBook()
        {
            BookRepository bookRepository = new BookRepository(base.DB);
            Book MockBook = bookRepository.findBookByISBN("103291596X");
            Book book = new Book();
            book.Title = "une histoire du cinéma français";
            Assert.Equal(MockBook.Title, book.Title);

        }
    [Fact]
        public void VerifyListBookCount()
        {
            BookRepository bookRepository = new BookRepository(base.DB);
            List<Book> books = bookRepository.findAllBook();
            Assert.True(books.Count == 7); // la liste longueur de la list est 7
        }
    }
}