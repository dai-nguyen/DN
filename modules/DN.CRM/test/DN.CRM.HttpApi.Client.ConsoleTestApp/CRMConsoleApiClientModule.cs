using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace DN.CRM;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(CRMHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class CRMConsoleApiClientModule : AbpModule
{

}
