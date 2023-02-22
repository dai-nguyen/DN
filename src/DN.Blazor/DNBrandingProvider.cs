using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace DN.Blazor;

[Dependency(ReplaceServices = true)]
public class DNBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "DN";
}
