using ExchangeRate.Domain.Entities.BaseEntities;
using System;

namespace ExchangeRate.Domain.Entities.Catalog
{
    public class ExchangeRateData : AuditableEntity
    {

        public DateTime? Date { get; set; }
        public int BankId { get; set; }
        public int BuyCurrencyId { get; set; }
        public int SellCurrencyId { get; set; }
        public decimal? BuyRate { get; set; }
        public decimal? SellRate { get; set; }

        public virtual Bank Bank { get; set; }
        public virtual Currency BuyCurrency { get; set; }
        public virtual Currency SellCurrency { get; set; }
    }
}
