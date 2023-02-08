using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace BookManagementABP.Authors
{
    public class AuthorAppService : CrudAppService<Author, AuthorDTO, Guid, PagedAndSortedResultRequestDto, CreateUpdateAuthorDTO>
    {
        public AuthorAppService(IRepository<Author, Guid> repository) : base(repository)
        {
        }
    }
}
