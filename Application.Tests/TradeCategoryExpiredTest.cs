using Application.Domain.Entities;
using Application.Domain.Interfaces;
using Application.Entities.Enums;
using Application.Services;

namespace Application.Tests
{
    public class TradeCategoryExpiredTest
    {
        [Fact]
        public static void IsDateExpired()
        {
            DateTime referenceDate = DateTime.Now.AddDays(0);

            TradeService tradeService = new TradeService();

            ITrade trade = new Trade() 
            {
                ClientSector="PUBLIC",
                IsPoliticalExposed=false,
                NextPaymentDate = DateTime.Now.AddDays(-1),
                Value=1000000
            };

            Assert.Equal(TradeCategoryEnum.Expired,tradeService.GetCategory(trade,referenceDate));
        }
    }
}