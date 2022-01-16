using ExchangeRate.Domain.Entities.BaseEntities;
using System.Collections.Generic;

namespace ExchangeRate.Domain.Entities.Catalog
{
    public class Currency : AuditableEntity
    {
        public string? CurrencyName { get; set; }

        public virtual ICollection<BankCurrency> BankCurrencys { get; set; }
        //public virtual ICollection<ExchangeRateData> ExchangeRateDataBuys { get; set; }
        //public virtual ICollection<ExchangeRateData> ExchangeRateDataSells { get; set; }
    }
}
