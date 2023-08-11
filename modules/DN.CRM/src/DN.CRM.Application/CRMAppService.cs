using DN.CRM.Localization;
using Volo.Abp.Application.Services;

namespace DN.CRM;

public abstract class CRMAppService : ApplicationService
{
    protected CRMAppService()
    {
        LocalizationResource = typeof(CRMResource);
        ObjectMapperContext = typeof(CRMApplicationModule);
    }
}
