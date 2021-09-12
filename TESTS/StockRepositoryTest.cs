using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Repository;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
namespace api.septiemarche.TESTS
{
    public class StockRepositoryTest
    {
        private readonly Mock<ILogger<StockRepository>> MockLogger;
        private readonly StockRepository MockStockRepository;
        private readonly MySqlConnector db;
        public StockRepositoryTest()
        {
            MockLogger = new Mock<ILogger<StockRepository>>();
            MockStockRepository = new StockRepository(db);
        }

        [Fact]

        public  void StockIsValid()
        {
            var result = MockStockRepository.StockIsValid(1, 1, 1);


            Assert.NotNull(result);
            Assert.Equal(true, result);
        }
    }
}
