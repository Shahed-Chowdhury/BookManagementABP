using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BookManagementABP.BookAuthors
{
    public interface IBookAuthorAppService: ICrudAppService<BookAuthorDTO, Guid, PagedAndSortedResultRequestDto, CreateUpdateBookAuthorDTO>
    {
    }
}
