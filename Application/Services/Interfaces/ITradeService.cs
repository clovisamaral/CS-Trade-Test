using Application.Domain.Interfaces;
using Application.Entities.Enums;

namespace Application.Services.Interfaces
{
    public interface ITradeService
    {
        TradeCategoryEnum? GetCategory(ITrade trade, DateTime referenceDate);
    }
}