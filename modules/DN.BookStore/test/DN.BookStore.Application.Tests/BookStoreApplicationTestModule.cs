using Volo.Abp.Modularity;

namespace DN.BookStore;

[DependsOn(
    typeof(BookStoreApplicationModule),
    typeof(BookStoreDomainTestModule)
    )]
public class BookStoreApplicationTestModule : AbpModule
{

}
