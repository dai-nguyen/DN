using DN.Localization;
using Volo.Abp.AspNetCore.Components;

namespace DN.Blazor;

public abstract class DNComponentBase : AbpComponentBase
{
    protected DNComponentBase()
    {
        LocalizationResource = typeof(DNResource);
    }
}
