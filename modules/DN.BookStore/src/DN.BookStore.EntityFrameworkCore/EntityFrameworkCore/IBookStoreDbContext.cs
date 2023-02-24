using DN.BookStore.Books;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace DN.BookStore.EntityFrameworkCore;

[ConnectionStringName(BookStoreDbProperties.ConnectionStringName)]
public interface IBookStoreDbContext : IEfCoreDbContext
{
    DbSet<Book> Books { get; }

    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
