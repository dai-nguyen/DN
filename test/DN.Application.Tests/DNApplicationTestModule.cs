using Volo.Abp.Modularity;

namespace DN;

[DependsOn(
    typeof(DNApplicationModule),
    typeof(DNDomainTestModule)
    )]
public class DNApplicationTestModule : AbpModule
{

}
