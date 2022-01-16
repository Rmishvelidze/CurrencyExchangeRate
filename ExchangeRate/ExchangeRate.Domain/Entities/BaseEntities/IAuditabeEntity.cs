using System;

namespace ExchangeRate.Domain.Entities.BaseEntities
{
    internal interface IAuditableBaseEntity : IBaseEntity
    {
        string CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }
        string LastModifiedBy { get; set; }
        DateTime? LastModifiedOn { get; set; }
    }
}
