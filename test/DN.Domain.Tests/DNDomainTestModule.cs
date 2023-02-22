using DN.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace DN;

[DependsOn(
    typeof(DNEntityFrameworkCoreTestModule)
    )]
public class DNDomainTestModule : AbpModule
{

}
