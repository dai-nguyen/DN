using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace DN.BookStore;

[DependsOn(
    typeof(BookStoreApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class BookStoreHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(BookStoreApplicationContractsModule).Assembly,
            BookStoreRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<BookStoreHttpApiClientModule>();
        });

    }
}
