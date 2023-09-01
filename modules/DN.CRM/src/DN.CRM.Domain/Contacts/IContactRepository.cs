using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace DN.CRM.Contacts
{
    public interface IContactRepository : IRepository<Contact, Guid>
    {        
        Task<List<Contact>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null);
    }
}
