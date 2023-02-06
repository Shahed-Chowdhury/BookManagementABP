using BookManagementABP.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace BookManagementABP.Permissions;

public class BookManagementABPPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(BookManagementABPPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(BookManagementABPPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BookManagementABPResource>(name);
    }
}
