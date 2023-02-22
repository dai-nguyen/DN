using DN.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace DN.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class DNController : AbpControllerBase
{
    protected DNController()
    {
        LocalizationResource = typeof(DNResource);
    }
}
