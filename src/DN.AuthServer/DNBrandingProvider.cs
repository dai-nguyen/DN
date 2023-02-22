using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace DN;

[Dependency(ReplaceServices = true)]
public class DNBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "DN";
}
