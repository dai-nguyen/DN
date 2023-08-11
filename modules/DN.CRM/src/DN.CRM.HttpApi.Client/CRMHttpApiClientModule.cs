using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace DN.CRM;

[DependsOn(
    typeof(CRMApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class CRMHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(CRMApplicationContractsModule).Assembly,
            CRMRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<CRMHttpApiClientModule>();
        });

    }
}
