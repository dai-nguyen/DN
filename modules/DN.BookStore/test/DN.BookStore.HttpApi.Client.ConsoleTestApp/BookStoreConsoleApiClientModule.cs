using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace DN.BookStore;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(BookStoreHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class BookStoreConsoleApiClientModule : AbpModule
{

}
