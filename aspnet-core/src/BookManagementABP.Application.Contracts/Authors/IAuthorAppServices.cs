using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BookManagementABP.Authors
{
    internal interface IAuthorAppServices: ICrudAppService<AuthorDTO, Guid, PagedAndSortedResultRequestDto, CreateUpdateAuthorDTO>
    {
    }
}
