using System;
using System.Collections.Generic;
using System.Text;
using DN.Localization;
using Volo.Abp.Application.Services;

namespace DN;

/* Inherit your application services from this class.
 */
public abstract class DNAppService : ApplicationService
{
    protected DNAppService()
    {
        LocalizationResource = typeof(DNResource);
    }
}
