using Volo.Abp.Settings;

namespace DN.Settings;

public class DNSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(DNSettings.MySetting1));
    }
}
