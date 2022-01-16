using System;

namespace ExchangeRate.Application.Features.BanksByCurrency.Queries.GetExcangeRate
{
    public class GetBankByCurrencyResponce
    {
        public string? BankCode { get; set; }
        public decimal? BuyRate { get; set; }
        public decimal? SellRate { get; set; }
        public DateTime? Date { get; set; }
    }
}
