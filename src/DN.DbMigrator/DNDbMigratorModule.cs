using DN.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace DN.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(DNEntityFrameworkCoreModule),
    typeof(DNApplicationContractsModule)
    )]
public class DNDbMigratorModule : AbpModule
{

}
