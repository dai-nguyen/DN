using Volo.Abp.Modularity;

namespace DN.CRM;

[DependsOn(
    typeof(CRMApplicationModule),
    typeof(CRMDomainTestModule)
    )]
public class CRMApplicationTestModule : AbpModule
{

}
