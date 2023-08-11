using DN.CRM.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace DN.CRM.Permissions;

public class CRMPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(CRMPermissions.GroupName, L("Permission:CRM"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CRMResource>(name);
    }
}
