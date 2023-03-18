using DN.BookStore.Authors;
using DN.BookStore.Books;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace DN.BookStore.EntityFrameworkCore;

public static class BookStoreDbContextModelCreatingExtensions
{
    public static void ConfigureBookStore(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        builder.Entity<Book>(b =>
        {
            b.ToTable(BookStoreDbProperties.DbTablePrefix + "Books",
                BookStoreDbProperties.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(128);
        });

        builder.Entity<Author>(b =>
        {
            b.ToTable(BookStoreDbProperties.DbTablePrefix + "Authors",
                BookStoreDbProperties.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(AuthorConsts.MaxNameLength);
            b.HasIndex(x => x.Name);
        });

        /* Configure all entities here. Example:

        builder.Entity<Question>(b =>
        {
            //Configure table & schema name
            b.ToTable(BookStoreDbProperties.DbTablePrefix + "Questions", BookStoreDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Properties
            b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);

            //Relations
            b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

            //Indexes
            b.HasIndex(q => q.CreationTime);
        });
        */
    }
}
