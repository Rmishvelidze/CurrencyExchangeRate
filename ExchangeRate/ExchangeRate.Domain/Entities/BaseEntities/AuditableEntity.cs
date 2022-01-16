using System;

namespace ExchangeRate.Domain.Entities.BaseEntities
{
    public abstract class AuditableEntity : IBaseEntity, IAuditableBaseEntity
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}
