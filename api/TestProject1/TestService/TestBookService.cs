using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api.Repository;
using api.Repository.Interfaces;
using api.services;
using api.services.Interfaces;
using Moq;
using Xunit;
namespace TestProject1.TestService
{
   public class TestBookService : BaseUnitTest
    {

        public TestBookService()
        {

        }

        [Fact]
        public void FindifBookIsDigital()
        {
            IBookRepository _mockBookRepositoryService = new BookRepository(base.DB);
            IBookService _bookService = new BookService(_mockBookRepositoryService);
            _bookService.findAllBook();
        } 
    }
}
