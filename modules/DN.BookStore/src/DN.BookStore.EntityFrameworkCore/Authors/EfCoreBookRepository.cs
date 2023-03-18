using DN.BookStore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DN.BookStore.Authors
{
    public class EfCoreBookRepository : EfCoreRepository<BookStoreDbContext, Author, Guid>, IAuthorRepository
    {
        public EfCoreBookRepository(
            IDbContextProvider<BookStoreDbContext> dbContextProvider)
            : base(dbContextProvider)
        { }

        public async Task<Author> FindByNameAsync(string name)
        {
            var dbSet = await GetDbSetAsync();

            return await dbSet.FirstOrDefaultAsync(_ => _.Name == name);
        }

        public async Task<List<Author>> GetListAsync(
            int skipCount, 
            int maxResultCount, 
            string sorting, 
            string filter = null)
        {
            var dbSet = await GetDbSetAsync();

            return await dbSet
                .WhereIf(!filter.IsNullOrWhiteSpace(), _ => _.Name.Contains(filter))
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
