using BookManagementABP.Authors;
using BookManagementABP.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace BookManagementABP.Books
{
    public class BookAppService :
        CrudAppService<Book, BookDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateBookDto>,
        IBookAppService
    {
        
        public BookAppService(IRepository<Book, Guid> repository, BookManagementABPDbContext context, AuthorAppService authorsRepository) : base(repository)
        { 
        }

        public async Task<BookDto> GetWithPublishers(Guid id)
        {
            var queryable = await Repository.GetQueryableAsync();
            var bookInfo = queryable.FirstOrDefault(x => x.Id == id);
            var book = new BookDto
            {
                Id = id,
                Name = bookInfo.Name,
                Type = bookInfo.Type,
                PublishDate = bookInfo.PublishDate,
                Price = bookInfo.Price,
                PublisherId = bookInfo.PublisherId
            };
            return book;
        }
    }
}
