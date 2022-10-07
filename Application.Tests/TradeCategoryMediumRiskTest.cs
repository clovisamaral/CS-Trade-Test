using Application.Domain.Entities;
using Application.Domain.Interfaces;
using Application.Entities.Enums;
using Application.Services;

namespace Application.Tests
{
    public class TradeCategoryMediumRiskTest
    {
        [Fact]
        public static void IsMediumRisk()
        {
            DateTime referenceDate = DateTime.Now.AddDays(0);

            TradeService tradeService = new TradeService();

            ITrade trade = new Trade()
            {
                ClientSector = "PUBLIC",
                IsPoliticalExposed = false,
                NextPaymentDate = DateTime.Now.AddDays(30),
                Value = 1000001
            };

            Assert.Equal(TradeCategoryEnum.Mediumrisk, tradeService.GetCategory(trade, referenceDate));
        }
    }
}
