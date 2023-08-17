using JetBrains.Annotations;
using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace DN.CRM.Customers
{
    public class Customer : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }        
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string URL { get; set; }

        internal Customer(
            Guid id,
            [NotNull] string name,
            [CanBeNull] string street1,
            [CanBeNull] string street2,
            [CanBeNull] string city,
            [CanBeNull] string zip,
            [CanBeNull] string state,
            [CanBeNull] string country,
            [CanBeNull] string phone,
            [CanBeNull] string email,
            [CanBeNull] string url)
        {
            SetName(name);
            SetStreet1(street1);
            SetStreet2(street2);
            SetCity(city);
        }

        private void SetName([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(
                name,
                nameof(name),
                maxLength: CustomerConsts.MaxNameLength);
        }

        private void SetStreet1([CanBeNull] string street1)
        {
            Street1 = Check.Length(
                street1, 
                nameof(street1), 
                maxLength: CustomerConsts.MaxAddressLength);
        }

        private void SetStreet2([CanBeNull] string street2)
        {
            Street1 = Check.Length(
                street2,
                nameof(street2),
                maxLength: CustomerConsts.MaxAddressLength);
        }

        private void SetCity([CanBeNull] string city)
        {
            City = Check.Length(
                city,
                nameof(city),
                maxLength: CustomerConsts.MaxCityLength);
        }


    }
}
