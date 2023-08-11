using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace DN.CRM.Blazor.WebAssembly;

[DependsOn(
    typeof(CRMBlazorModule),
    typeof(CRMHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class CRMBlazorWebAssemblyModule : AbpModule
{

}
