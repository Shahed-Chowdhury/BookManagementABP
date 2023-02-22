using BookManagementABP.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace BookManagementABP.Permissions;

public class BookManagementABPPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var bookManagementGroup = context.AddGroup(BookManagementABPPermissions.GroupName, L("Permission:BookStore"));

        var booksPermission = bookManagementGroup.AddPermission(BookManagementABPPermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(BookManagementABPPermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(BookManagementABPPermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(BookManagementABPPermissions.Books.Delete, L("Permission:Books.Delete"));

        var publishersPermission = bookManagementGroup.AddPermission(BookManagementABPPermissions.Publishers.Default, L("Permission:Publishers"));
        publishersPermission.AddChild(BookManagementABPPermissions.Publishers.Create, L("Permission:Publishers.Create"));
        publishersPermission.AddChild(BookManagementABPPermissions.Publishers.Edit, L("Permission:Publishers.Edit"));
        publishersPermission.AddChild(BookManagementABPPermissions.Publishers.Delete, L("Permission:Publishers.Delete"));

        var authorsPermission = bookManagementGroup.AddPermission(BookManagementABPPermissions.Authors.Default, L("Permission:Authors"));
        authorsPermission.AddChild(BookManagementABPPermissions.Authors.Create, L("Permission:Authors.Create"));
        authorsPermission.AddChild(BookManagementABPPermissions.Authors.Edit, L("Permission:Authors.Edit"));
        authorsPermission.AddChild(BookManagementABPPermissions.Authors.Delete, L("Permission:Authors.Delete"));

        var InvitedUsersPermission = bookManagementGroup.AddPermission(BookManagementABPPermissions.InvitedUsers.Default, L("Permission:InvitedUsers"));
        InvitedUsersPermission.AddChild(BookManagementABPPermissions.InvitedUsers.Create, L("Permission:InvitedUsers.Create"));
        InvitedUsersPermission.AddChild(BookManagementABPPermissions.InvitedUsers.Edit, L("Permission:InvitedUsers.Edit"));
        InvitedUsersPermission.AddChild(BookManagementABPPermissions.InvitedUsers.Delete, L("Permission:InvitedUsers.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BookManagementABPResource>(name);
    }
}
