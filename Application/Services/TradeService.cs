using Application.Domain.Interfaces;
using Application.Entities.Enums;
using Application.Services.Interfaces;

namespace Application.Services
{
    public class TradeService : ITradeService
    {
        public TradeCategoryEnum? GetCategory(ITrade trade, DateTime referenceDate)
        {
            if (trade.NextPaymentDate.Date < referenceDate.Date.AddDays(-30))
            {
                return TradeCategoryEnum.Expired;
            }
            if (ResetText(trade.ClientSector) == "PRIVATE" && trade.Value > GenerateHighValue(1, numberOfZero: 6))
            {
                return TradeCategoryEnum.Highrisk;
            }
            if (ResetText(trade.ClientSector) == "PUBLIC" && trade.Value > GenerateHighValue(1, numberOfZero: 6))
            {
                return TradeCategoryEnum.Mediumrisk;
            }

            return null;
        }

        private static int GenerateHighValue(int firstNumber, int numberOfZero)
        {
            return int.Parse(firstNumber + new string('0', numberOfZero));
        }

        private static string ResetText(string text)
        {
            return text.ToUpper().Trim();
        }
    }
}
