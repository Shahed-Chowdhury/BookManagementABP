using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BookManagementABP.Book_Authors
{
    public interface IBookAuthorAppService: ICrudAppService<BookAuthorDTO, Guid, PagedAndSortedResultRequestDto, CreateUpdateBookAuthorDTO>
    {
    }
}
