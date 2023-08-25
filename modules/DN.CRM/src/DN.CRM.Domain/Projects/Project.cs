using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace DN.CRM.Projects
{
    public class Project : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string CustomerId { get; set; }
        public string ContactId { get; set; }
    }
}
