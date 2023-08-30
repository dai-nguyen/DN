using JetBrains.Annotations;
using System;
using Volo.Abp;
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
            SetFirstName(firstName);
            SetLastName(lastName);
            SetEmail(email);
            SetPhone(phone);
        }
        
        void SetFirstName([NotNull] string val) 
        {
            FirstName = Check.NotNullOrWhiteSpace(
                val,
                nameof(FirstName),
                maxLength: ContactConsts.MaxFirstNameLength);
        }

        void SetLastName([NotNull] string val)
        {
            LastName = Check.NotNullOrWhiteSpace(
                val,
                nameof(LastName),
                maxLength: ContactConsts.MaxLastNameLength);
        }

        void SetEmail([NotNull] string val)
        {
            Email = Check.NotNullOrWhiteSpace(
                val,
                nameof(Email),
                maxLength: ContactConsts.MaxEmailLength);
        }

        void SetPhone([CanBeNull] string val)
        {
            Phone = Check.Length(
                val,
                nameof(Phone),
                maxLength: ContactConsts.MaxPhoneLength);
        }
    }

    
}
