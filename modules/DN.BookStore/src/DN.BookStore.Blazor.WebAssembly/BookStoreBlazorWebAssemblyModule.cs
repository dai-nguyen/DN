using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace DN.BookStore.Blazor.WebAssembly;

[DependsOn(
    typeof(BookStoreBlazorModule),
    typeof(BookStoreHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class BookStoreBlazorWebAssemblyModule : AbpModule
{

}
