using DN.CRM.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace DN.CRM;

public abstract class CRMController : AbpControllerBase
{
    protected CRMController()
    {
        LocalizationResource = typeof(CRMResource);
    }
}
