using DN.BookStore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DN.BookStore.Books
{
    public class EfCoreBookRepository : EfCoreRepository<BookStoreDbContext, Book, Guid>, IBookRepository
    {
        public EfCoreBookRepository(
            IDbContextProvider<BookStoreDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }

        public async Task<List<Book>> GetListAsync(
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
