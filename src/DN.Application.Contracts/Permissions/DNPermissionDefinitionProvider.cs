using DN.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace DN.Permissions;

public class DNPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(DNPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(DNPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<DNResource>(name);
    }
}
