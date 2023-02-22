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
using Volo.Abp.Domain.Repositories;

namespace BookManagementABP.InvitedUsers
{
    public class InvitedUserAppServices : CrudAppService<Invited_User, InvitedUserDTO, Guid, PagedAndSortedResultRequestDto, CreateUpdateInvitedUserDTO>, IinvitedUserAppService
    {
        private readonly BookManagementABPDbContext _context;
        public InvitedUserAppServices(IRepository<Invited_User, Guid> repository, BookManagementABPDbContext context) : base(repository)
        {
            _context = context;
            GetListPolicyName = BookManagementABPPermissions.InvitedUsers.Default;
            CreatePolicyName = BookManagementABPPermissions.InvitedUsers.Create;
            UpdatePolicyName = BookManagementABPPermissions.InvitedUsers.Edit;
            DeletePolicyName = BookManagementABPPermissions.InvitedUsers.Delete;
        }

        public async Task<List<Invited_User>> GetList()
        {
            var u =  await _context.Invited_Users.ToListAsync();

            return u;
        }
    }
}
