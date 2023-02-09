using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BookManagementABP.Publishers
{
    public interface IPublisherAppService: ICrudAppService<PublisherDTO, Guid, PagedAndSortedResultRequestDto, CreateUpdatePublisherDTO>
    {
    }
}
