using BookManagementABP.Authors;
using BookManagementABP.EntityFrameworkCore;
using BookManagementABP.Publishers;
using Microsoft.EntityFrameworkCore;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        private readonly BookManagementABPDbContext _context;
        
        public BookAppService(
            IRepository<Book, Guid> repository,
            BookManagementABPDbContext context,
            AuthorAppService authorsRepository
        ) : base(repository)
        {
            _context = context;
        }

        public async Task<BookDto> GetWithPublisher(Guid id)
        {
            
            var bookDTO = new BookDto();
            var publisherDto = new PublisherDTO();

            var book = ( from b in _context.Books where b.Id == id
                         join p in _context.Publishers on b.PublisherId equals p.Id select
                         new {
                                Id = b.Id,
                                Name = b.Name,
                                Type = b.Type,
                                PublishDate = b.PublishDate,
                                Price = b.Price,
                                PublisherId = b.PublisherId,
                                Publisher = new { Id=p.Id, Name = p.Name }
                         }).SingleOrDefault();

            var authors = (
                from ba in _context.Book_Authors where ba.BookId == id
                join a in _context.Authors on ba.AuthorId equals a.Id select
                new
                {
                    Id = a.Id,
                    Name = a.Name,
                    BirthDate = a.BirthDate,
                    ShortBio = a.ShortBio,
                 }
            ).ToList();

            
            foreach (var author in authors)
            {
                var authorDto = new AuthorDTO();
                authorDto.Id = author.Id;
                authorDto.Name = author.Name;
                authorDto.BirthDate = author.BirthDate;
                authorDto.ShortBio = author.ShortBio;
                bookDTO.Author.Add(authorDto);
            }

            

            if (book == null) return null;

            

            publisherDto.Id = book.Publisher.Id;
            publisherDto.Name = book.Publisher.Name;

            bookDTO.Id = book.Id;
            bookDTO.Name = book.Name;   
            bookDTO.Type = book.Type;
            bookDTO.PublishDate = book.PublishDate;
            bookDTO.Price = book.Price;
            bookDTO.PublisherId = book.PublisherId;
            bookDTO.Publisher = publisherDto;

            return bookDTO;

        }


        /*
        from b in _context.Books
            where b.Id == id
            select b).Include(x => x.Publisher).SingleOrDefault();
        
        var queryable = await Repository.GetQueryableAsync();
        var bookInfo = queryable.Include(a => a.Publisher).FirstOrDefault(x => x.Id == id);

        var publisherDTO = new PublisherDTO();

        publisherDTO.Id = bookInfo.Publisher.Id;
        publisherDTO.Name = bookInfo.Publisher.Name;


        var book = new BookDto
        {
            Id = id,
            Name = bookInfo.Name,
            Type = bookInfo.Type,
            PublishDate = bookInfo.PublishDate,
            Price = bookInfo.Price,
            PublisherId = bookInfo.PublisherId,
            Publisher = publisherDTO
        };
        return book; */

    }
}