using ExchangeRate.Domain.Entities.BaseEntities;
using System.Collections.Generic;

namespace ExchangeRate.Domain.Entities.Catalog
{
    public class Currency : AuditableEntity
    {
        public static Currency Gel = new Currency() { CurrencyName = "Gel",Id=1 };
        public static Currency Usd = new Currency() { CurrencyName = "Usd",Id=2 };
  public   static   Currency[] Currencies = new Currency[] { Gel, Usd };
        public string CurrencyName { get; set; }

        public virtual ICollection<BankCurrency> BankCurrencys { get; set; }
        //public virtual ICollection<ExchangeRateData> ExchangeRateDataBuys { get; set; }
        //public virtual ICollection<ExchangeRateData> ExchangeRateDataSells { get; set; }
    }
}
