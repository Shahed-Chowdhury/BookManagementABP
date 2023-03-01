using BookManagementABP.Emailing;
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
        public InvitedUserAppServices(IRepository<Invited_User, Guid> repository, BookManagementABPDbContext context, IEmailSender emailSender, EmailService emailService) : base(repository)
        {
            _context = context;
            _emailService = emailService;
            _emailSender = emailSender;
            GetListPolicyName = BookManagementABPPermissions.InvitedUsers.Default;
            CreatePolicyName = BookManagementABPPermissions.InvitedUsers.Create;
            UpdatePolicyName = BookManagementABPPermissions.InvitedUsers.Edit;
            DeletePolicyName = BookManagementABPPermissions.InvitedUsers.Delete;
        }

        public async Task<List<Invited_User>> GetUserList()
        {
            var u = await _context.Invited_Users.ToListAsync();

            await _emailService.InvitedUserEmailAsync("shahed@mailinator.com");

            return u;
        }
    }
}
