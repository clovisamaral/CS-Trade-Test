using Application.Domain.Interfaces;

namespace Application.Domain.Entities
{
    public class Trade : ITrade
    {
        public double Value { get; set; }
        public string ClientSector { get; set; }
        public DateTime NextPaymentDate { get; set; }
        public bool IsPoliticalExposed { get; set; } = false;
    }
}
