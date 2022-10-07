namespace Application.Domain.Interfaces
{
    public interface ITrade
    {
        public double Value { get; set; }
        public string ClientSector { get; set; }
        public DateTime NextPaymentDate { get; set; }
        public bool IsPoliticalExposed { get; set; }
    }
}
