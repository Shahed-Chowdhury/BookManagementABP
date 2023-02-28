using BookManagementABP.Books;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BookManagementABP.Invited_Users
{
    public interface IinvitedUserAppService: ICrudAppService<InvitedUserDTO, Guid, PagedAndSortedResultRequestDto, CreateUpdateInvitedUserDTO>
    {
    }
}
