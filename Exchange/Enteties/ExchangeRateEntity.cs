namespace ExchangeRate.Api.Entities
{
    public class ExchangeRateEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal BuyRate { get; set; }
        public decimal SellRate { get; set; }
        public decimal MidRate { get; set; }
        public required string Currency { get; set; }
    }
}