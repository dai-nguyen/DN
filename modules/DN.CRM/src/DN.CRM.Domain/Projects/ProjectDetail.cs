using System;
using System.Diagnostics.CodeAnalysis;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace DN.CRM.Projects
{
    public class ProjectDetail : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateDue { get; set; }

        public ProjectStatus Status { get; set; }
        public ProjectPriority Priority { get; set; }
        public ProjectDifficulty Difficulty { get; set; }

        public string AssignedToId { get; set; }

        internal ProjectDetail(
            Guid id,
            [NotNull] string name,
            [NotNull] string description) 
        { 
            SetName(name);
            SetDescription(description);
        }

        void SetName([NotNull] string val)
        {
            Name = Check.NotNullOrWhiteSpace(
                val,
                nameof(Name),
                maxLength: ProjectDetailConsts.MaxNameLength);
        }

        void SetDescription([NotNull] string val)
        {
            Description = Check.NotNullOrWhiteSpace(
                val,
                nameof(Description),
                maxLength: ProjectDetailConsts.MaxDescriptionLength);
        }
    }
}
