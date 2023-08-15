using JetBrains.Annotations;
using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace DN.CRM.Contacts
{
    public class Contact : FullAuditedAggregateRoot<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        internal Contact(
            Guid id,
            [NotNull] string firstName,
            [NotNull] string lastName,
            [NotNull] string email,
            [CanBeNull] string phone)
        {

        }

    }

    
}
