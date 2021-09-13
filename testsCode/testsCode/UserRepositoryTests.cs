using api.models;
using api.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace api.septiemarche.TESTS
{
    public class UserRepositoryTests
    {
        private readonly MySqlConnector DB;
       private readonly UserRepository MockUserRepository;
        public UserRepositoryTests()
        {
            MockUserRepository = new UserRepository(DB);
        }


        [Fact]
        public void testAuth()
    {
        string email = "leo@gmail.com";
        string password = "098F6BCD4621D373CADE4E832627B4F6";
            User result = MockUserRepository.Auth(email, password);
            Assert.NotNull(result);
        }
}
}