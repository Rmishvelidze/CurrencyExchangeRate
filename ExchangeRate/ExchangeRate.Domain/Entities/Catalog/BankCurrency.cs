using ExchangeRate.Domain.Entities.BaseEntities;

namespace ExchangeRate.Domain.Entities.Catalog
{
    public class BankCurrency : AuditableEntity
    {
            public int BankId { get; set; }
            public int CurrencyId { get; set; }

            public virtual Bank Bank { get; set; }
            public virtual Currency Currency { get; set; }
    }
}
