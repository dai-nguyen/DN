using DN.CRM.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DN.CRM.Contacts
{
    public class EfCoreContactRepository : EfCoreRepository<CRMDbContext, Contact, Guid>, IContactRepository
    {
        public EfCoreContactRepository(
            IDbContextProvider<CRMDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }

        public async Task<List<Contact>> GetListAsync(
            int skipCount, 
            int maxResultCount, 
            string sorting, 
            string filter = null)
        {
            var dbSet = await GetDbSetAsync();

            return await dbSet
                .WhereIf(!filter.IsNullOrWhiteSpace(), _ => _.FirstName.Contains(filter) || _.LastName.Contains(filter) || _.Email.Contains(filter))
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
