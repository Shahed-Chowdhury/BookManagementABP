using BookManagementABP.Book_Authors;
using BookManagementABP.Books;
using BookManagementABP.EntityFrameworkCore;
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
        private readonly BookManagementABPDbContext _context;
        public BookAuthorServices(IRepository<Book_Author, Guid> repository, BookManagementABPDbContext context) : base(repository)
        {
            _context = context;
        }

        public bool DeleteById(Guid bookId, Guid authorId)
        {
            var book = _context?.Book_Authors?.Where(x => x.BookId == bookId && x.AuthorId == authorId).FirstOrDefault();
            _context?.Book_Authors?.Remove(book);
            if(_context?.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
