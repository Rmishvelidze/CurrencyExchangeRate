using ExchangeRate.Domain.Entities.BaseEntities;
using System.Collections.Generic;

namespace ExchangeRate.Domain.Entities.Catalog
{
    public class Bank : AuditableEntity
    {
        public string? BankCode { get; set; }
        public string? BankName { get; set; }

        public virtual ICollection<BankCurrency> BankCurrencies { get; set; }
        public virtual ICollection<ExchangeRateData> ExchangeRateDatas { get; set; }
    }
}
