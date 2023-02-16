using BookManagementABP.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace BookManagementABP.Publishers
{
    //[Authorize]
    public class PublisherAppService : CrudAppService<Publisher, PublisherDTO, Guid, PagedAndSortedResultRequestDto, CreateUpdatePublisherDTO>, IPublisherAppService
    {
        public PublisherAppService(IRepository<Publisher, Guid> repository) : base(repository)
        {
            GetListPolicyName = BookManagementABPPermissions.Publishers.Default;
            CreatePolicyName = BookManagementABPPermissions.Publishers.Create;
            UpdatePolicyName = BookManagementABPPermissions.Publishers.Edit;
            DeletePolicyName = BookManagementABPPermissions.Publishers.Delete;
        }
    }
}
