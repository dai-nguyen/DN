using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace DN.CRM.Projects
{
    public class Project : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateDue { get; set; }        
        public ProjectStatus Status { get; set; }
        public ProjectPriority Priority { get; set; }
        public ProjectDifficulty Difficulty { get; set; }

        public string CustomerId { get; set; }
        public string ContactId { get; set; }
        public string ProjectManagerId { get; set; }
    }
}
