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
        public string State { get; set; }
        public string Zip { get; set; }        
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
            SetZip(zip);
            SetState(state);
            SetCountry(country);
            SetPhone(phone);
            SetEmail(email);
            SetUrl(url);
        }
        
        void SetName([NotNull] string val)
        {
            Name = Check.NotNullOrWhiteSpace(
                val,
                nameof(Name),
                maxLength: CustomerConsts.MaxNameLength);
        }

        void SetStreet1([CanBeNull] string val)
        {
            Street1 = Check.Length(
                val, 
                nameof(Street1), 
                maxLength: CustomerConsts.MaxAddressLength);
        }

        void SetStreet2([CanBeNull] string val)
        {
            Street1 = Check.Length(
                val,
                nameof(Street2),
                maxLength: CustomerConsts.MaxAddressLength);
        }

        void SetCity([CanBeNull] string val)
        {
            City = Check.Length(
                val,
                nameof(City),
                maxLength: CustomerConsts.MaxCityLength);
        }

        void SetZip([CanBeNull] string val)
        {
            Zip = Check.Length(
                val,
                nameof(Zip),
                maxLength: CustomerConsts.MaxZipLength);
        }

        void SetState([CanBeNull] string val)
        {
            State = Check.Length(
                val,
                nameof(State),
                maxLength: CustomerConsts.MaxStateLength);
        }

        void SetCountry([CanBeNull] string val)
        {
            Country = Check.Length(
                val,
                nameof(Country),
                maxLength: CustomerConsts.MaxCountryLength);
        }

        void SetPhone([CanBeNull] string val)
        {
            Phone = Check.Length(
                val,
                nameof(Phone),
                maxLength: CustomerConsts.MaxPhoneLength);
        }

        void SetEmail([CanBeNull] string val)
        {
            Email = Check.Length(
                val,
                nameof(Email),
                maxLength: CustomerConsts.MaxEmailLength);
        }

        private void SetUrl(string val)
        {
            URL = Check.Length(
                val,
                nameof(URL),
                maxLength: CustomerConsts.MaxUrlLength);
        }
    }
}
