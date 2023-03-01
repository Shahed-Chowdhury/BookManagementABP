using BookManagementABP.Emailing;
using BookManagementABP.Emailing.Templates.InvitedUser;
using BookManagementABP.EntityFrameworkCore;
using BookManagementABP.Invited_Users;
using BookManagementABP.Permissions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Emailing;

namespace BookManagementABP.Invited_Users
{
    public class InvitedUserAppServices:CrudAppService<Invited_User, InvitedUserDTO, Guid, PagedAndSortedResultRequestDto, CreateUpdateInvitedUserDTO>, IinvitedUserAppService, ITransientDependency
    {
        private readonly BookManagementABPDbContext _context;
        private readonly IEmailSender _emailSender;
        private readonly EmailService _emailService;
        private readonly IRepository<Invited_User> _invitedUserRepository;
        public InvitedUserAppServices(
            IRepository<Invited_User,Guid> repository,
            BookManagementABPDbContext context,
            IEmailSender emailSender,
            EmailService emailService,
            IRepository<Invited_User> invitedUserRepository) : base(repository)
        {
            _context = context;
            _emailService = emailService;
            _emailSender = emailSender;
            GetListPolicyName = BookManagementABPPermissions.InvitedUsers.Default;
            CreatePolicyName = BookManagementABPPermissions.InvitedUsers.Create;
            UpdatePolicyName = BookManagementABPPermissions.InvitedUsers.Edit;
            DeletePolicyName = BookManagementABPPermissions.InvitedUsers.Delete;
            _invitedUserRepository = invitedUserRepository;
        }

        public async Task<List<Invited_User>> GetUserList()
        {
            var u = await _context.Invited_Users.ToListAsync();
            return u;
        }

        public async Task<bool> AddInvitedUser(CreateUpdateInvitedUserDTO dto)
        {
            try
            {
                var invitedUser = new Invited_User();
                invitedUser.FirstName = dto.FirstName;
                invitedUser.LastName = dto.LastName;
                invitedUser.Email = dto.Email;
                invitedUser.Role = dto.Role;
                invitedUser.PhoneNumber = dto.PhoneNumber;

                var u = await _invitedUserRepository.InsertAsync(invitedUser, true);

                var iuser = new InvitedUser();
                iuser.FirstName = u.FirstName;
                iuser.LastName = u.LastName;
                iuser.Email = u.Email;
                iuser.UserId = u.Id;
                iuser.PhoneNumber = u.PhoneNumber;

                await _emailService.InvitedUserEmailAsync(iuser);

                return true;

            }
            catch(Exception ex)
            {
                throw new UserFriendlyException(ex.Message);
            }
        }
    }
}
