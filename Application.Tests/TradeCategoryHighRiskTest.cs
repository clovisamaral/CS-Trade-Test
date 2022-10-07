using Application.Domain.Entities;
using Application.Domain.Interfaces;
using Application.Entities.Enums;
using Application.Services;

namespace Application.Tests
{
    public class TradeCategoryHighRiskTest
    {
        [Fact]
        public static void IsHighRisk()
        {
            DateTime referenceDate = DateTime.Now.AddDays(0);

            TradeService tradeService = new TradeService();

            ITrade trade = new Trade()
            {
                ClientSector = "PRIVATE",
                IsPoliticalExposed = false,
                NextPaymentDate = DateTime.Now.AddDays(60),
                Value = 1000001
            };

            Assert.Equal(TradeCategoryEnum.Highrisk, tradeService.GetCategory(trade,referenceDate));
        }
    }
}
