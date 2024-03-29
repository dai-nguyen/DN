﻿using DN.BookStore.Authors;
using DN.BookStore.Books;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace DN.BookStore.EntityFrameworkCore;

[ConnectionStringName(BookStoreDbProperties.ConnectionStringName)]
public class BookStoreDbContext : AbpDbContext<BookStoreDbContext>, IBookStoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureBookStore();
    }
}
