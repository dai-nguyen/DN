using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace DN.BookStore;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(BookStoreDomainSharedModule)
)]
public class BookStoreDomainModule : AbpModule
{

}
