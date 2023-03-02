using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BookManagementABP.Emailing.Templates.InvitedUser;
using BookManagementABP.Invited_Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Volo.Abp;
using Volo.Abp.Account;
using Volo.Abp.Account.Settings;
using Volo.Abp.Account.Web.Pages.Account;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.Settings;
using Volo.Abp.Validation;
using IdentityUser = Volo.Abp.Identity.IdentityUser;

namespace BookManagementABP.Pages.Account;


public class CustomRegistrationModel : AccountPageModel
{

    [BindProperty(SupportsGet = true)]
    public string ReturnUrl { get; set; }

    [BindProperty(SupportsGet = true)]
    public string ReturnUrlHash { get; set; }

    [BindProperty]
    public PostInput Input { get; set; }

    [BindProperty(SupportsGet = true)]
    public bool IsExternalLogin { get; set; }

    [BindProperty(SupportsGet = true)]
    public string ExternalLoginAuthSchema { get; set; }

    private readonly IRepository<Invited_User, Guid> _invitedUserRepository;

    //private static Guid? invitationId { get; set; } 

    public CustomRegistrationModel(
        IAccountAppService accountAppService,
        IRepository<Invited_User, Guid> invitedUserRepository
    )
    {
        AccountAppService = accountAppService;
        _invitedUserRepository = invitedUserRepository;
    }

    public virtual async Task<IActionResult> OnGetAsync(Guid? id)
    {
        var invitationId = id;

        if (id == null)
        {

            Input = new PostInput
            {
                Name = "",
                Surname = "",
                PhoneNumber = "",
                EmailAddress = "",
                Role = "public"
            };

            await CheckSelfRegistrationAsync();
            await TrySetEmailAsync();
            return Page();
        }

        await CheckSelfRegistrationAsync();
        GetInvitationInfo(invitationId);
        return Page();

    }

    private async void GetInvitationInfo(Guid? invitationId)
    {
        var invited = await _invitedUserRepository.FirstOrDefaultAsync(x => x.Id == invitationId);
        if (invited != null) { 
            Input = new PostInput
            {
                Name = invited.FirstName,
                Surname = invited.LastName,
                PhoneNumber = invited.PhoneNumber,
                EmailAddress= invited.Email,
                Role = invited.Role
            };
        }

        return;
    }

    private async Task TrySetEmailAsync()
    {
        if (IsExternalLogin)
        {
            var externalLoginInfo = await SignInManager.GetExternalLoginInfoAsync();
            if (externalLoginInfo == null)
            {
                return;
            }

            if (!externalLoginInfo.Principal.Identities.Any())
            {
                return;
            }

            var identity = externalLoginInfo.Principal.Identities.First();
            var emailClaim = identity.FindFirst(ClaimTypes.Email);

            if (emailClaim == null)
            {
                return;
            }

            Input = new PostInput { EmailAddress = emailClaim.Value };
        }
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        try
        {
            await CheckSelfRegistrationAsync();

            if (IsExternalLogin)
            {
                var externalLoginInfo = await SignInManager.GetExternalLoginInfoAsync();
                if (externalLoginInfo == null)
                {
                    Logger.LogWarning("External login info is not available");
                    return RedirectToPage("./Login");
                }

                await RegisterExternalUserAsync(externalLoginInfo, Input.EmailAddress);
            }
            else
            {
                await RegisterLocalUserAsync();
            }

            return Redirect(ReturnUrl ?? "~/"); //TODO: How to ensure safety? IdentityServer requires it however it should be checked somehow!
        }
        catch (BusinessException e)
        {
            Alerts.Danger(GetLocalizeExceptionMessage(e));
            return Page();
        }
    }

    protected virtual async Task RegisterLocalUserAsync()
    {
        //ValidateModel();

        var userDto = await AccountAppService.RegisterAsync(
            new RegisterDto
            {
                AppName = "MVC",
                EmailAddress = Input.EmailAddress,
                Password = Input.Password,
                UserName = Input.UserName
            }
        );

        var user = await UserManager.GetByIdAsync(userDto.Id);
        
        user.Name = Input.Name;
        user.Surname = Input.Surname;
        user.SetPhoneNumber(Input.PhoneNumber,true);
        if(Input.Role!= null)
        {
            await UserManager.AddToRoleAsync(user, Input.Role);
        }
        else
        {
            await UserManager.AddToRoleAsync(user, "public");
        }
         //adds to the userRole
        await UserManager.UpdateAsync(user);
        await SignInManager.SignInAsync(user, isPersistent: true);
    }

    protected virtual async Task RegisterExternalUserAsync(ExternalLoginInfo externalLoginInfo, string emailAddress)
    {
        await IdentityOptions.SetAsync();

        var user = new IdentityUser(GuidGenerator.Create(), emailAddress, emailAddress, CurrentTenant.Id);

        (await UserManager.CreateAsync(user)).CheckErrors();
        (await UserManager.AddDefaultRolesAsync(user)).CheckErrors();

        var userLoginAlreadyExists = user.Logins.Any(x =>
            x.TenantId == user.TenantId &&
            x.LoginProvider == externalLoginInfo.LoginProvider &&
            x.ProviderKey == externalLoginInfo.ProviderKey);

        if (!userLoginAlreadyExists)
        {
            (await UserManager.AddLoginAsync(user, new UserLoginInfo(
                externalLoginInfo.LoginProvider,
                externalLoginInfo.ProviderKey,
                externalLoginInfo.ProviderDisplayName
            ))).CheckErrors();
        }

        await SignInManager.SignInAsync(user, isPersistent: true);
    }

    protected virtual async Task CheckSelfRegistrationAsync()
    {
        if (!await SettingProvider.IsTrueAsync(AccountSettingNames.IsSelfRegistrationEnabled) ||
            !await SettingProvider.IsTrueAsync(AccountSettingNames.EnableLocalLogin))
        {
            throw new UserFriendlyException(L["SelfRegistrationDisabledMessage"]);
        }
    }

    public class PostInput
    {
        [Required]
        [DynamicStringLength(typeof(IdentityUserConsts), nameof(IdentityUserConsts.MaxUserNameLength))]
        public string UserName { get; set; }

        [Required]
        [DynamicStringLength(typeof(IdentityUserConsts), nameof(IdentityUserConsts.MaxUserNameLength))]
        public string Surname { get; set; }

        [Required]
        [DynamicStringLength(typeof(IdentityUserConsts), nameof(IdentityUserConsts.MaxUserNameLength))]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^(?:(?:\+|00)88|01)?\d{11}$", ErrorMessage = "Number should be bangladeshi")]
        [DynamicStringLength(typeof(IdentityUserConsts), nameof(IdentityUserConsts.MaxPhoneNumberLength))]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [DynamicStringLength(typeof(IdentityUserConsts), nameof(IdentityUserConsts.MaxEmailLength))]
        public string EmailAddress { get; set; }

        [Required]
        [DynamicStringLength(typeof(IdentityUserConsts), nameof(IdentityUserConsts.MaxPasswordLength))]
        [DataType(DataType.Password)]
        [DisableAuditing]
        public string Password { get; set; }


        [Required]
        [DynamicStringLength(typeof(IdentityUserConsts), nameof(IdentityUserConsts.MaxPasswordLength))]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [DisableAuditing]
        public string ConfirmPassword { get; set; }

        [Required]
        [DisableAuditing]
        //[DynamicStringLength(typeof(IdentityUserConsts), nameof(IdentityUserConsts.MaxUserNameLength))]
        public string Role { get; set; }
    }
}