using BookManagementABP.Book_Authors;
using BookManagementABP.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace BookManagementABP.BookAuthors
{
    public class BookAuthorServices : CrudAppService<Book_Author, BookAuthorDTO, Guid, PagedAndSortedResultRequestDto, CreateUpdateBookAuthorDTO>, IBookAuthorAppService
    {
        public BookAuthorServices(IRepository<Book_Author, Guid> repository) : base(repository)
        {
        }
    }
}
