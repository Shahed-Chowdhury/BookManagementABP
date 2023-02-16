using BookManagementABP.EntityFrameworkCore;
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

namespace BookManagementABP.Authors
{
    //[Authorize]
    public class AuthorAppService : CrudAppService<Author, AuthorDTO, Guid, PagedAndSortedResultRequestDto, CreateUpdateAuthorDTO>
    {
        private readonly BookManagementABPDbContext _context;
        public AuthorAppService(IRepository<Author, Guid> repository, BookManagementABPDbContext context) : base(repository)
        {
            _context = context;
            GetListPolicyName = BookManagementABPPermissions.Authors.Default;
            CreatePolicyName = BookManagementABPPermissions.Authors.Create;
            UpdatePolicyName = BookManagementABPPermissions.Authors.Edit;
            DeletePolicyName = BookManagementABPPermissions.Authors.Delete;
        }
        public int GetAuthorCountBeforeDelete(Guid author_id)
        {
            var authors = _context.Book_Authors.Where(x => x.AuthorId == author_id).ToList().Count();
            return authors;
        }
    }
}
