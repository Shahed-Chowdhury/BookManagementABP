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
    public class PublisherAppService : CrudAppService<Publisher, PublisherDTO, Guid, PagedAndSortedResultRequestDto, CreateUpdatePublisherDTO>, IPublisherAppService
    {
        public PublisherAppService(IRepository<Publisher, Guid> repository) : base(repository)
        {
        }
    }
}
