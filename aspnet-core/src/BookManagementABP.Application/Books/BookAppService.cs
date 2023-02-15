using BookManagementABP.Authors;
using BookManagementABP.EntityFrameworkCore;
using BookManagementABP.Publishers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
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


        public async Task<List<BookDto>> GetBookDetails()
        {

            var bookList = new List<BookDto>();

            var book = (from b in _context.Books
                        join p in _context.Publishers on b.PublisherId equals p.Id
                        select
                        new
                        {
                            Id = b.Id,
                            Name = b.Name,
                            Type = b.Type,
                            PublishDate = b.PublishDate,
                            Price = b.Price,
                            PublisherId = b.PublisherId,
                            Publisher = new { Id = p.Id, Name = p.Name }
                        }).OrderByDescending(x => x.Id).ToList();


            if (book.Count == 0) return null;

            

            foreach (var b in book)
            {
                var bookDto = new BookDto();
                var publisherDto = new PublisherDTO();

                publisherDto.Id = b.Publisher.Id;
                publisherDto.Name = b.Publisher.Name;

                bookDto.Id = b.Id;
                bookDto.Name = b.Name;
                bookDto.Type = b.Type;
                bookDto.PublishDate = b.PublishDate;
                bookDto.Price = b.Price;
                bookDto.PublisherId = b.PublisherId;
                bookDto.Publisher = publisherDto;

                // Author list
                var authors = (
                from ba in _context.Book_Authors
                where ba.BookId == b.Id
                join a in _context.Authors on ba.AuthorId equals a.Id
                select
                new
                {
                    Id = a.Id,
                    Name = a.Name,
                    BirthDate = a.BirthDate,
                    ShortBio = a.ShortBio,
                }).ToList();

                foreach (var author in authors)
                {
                    var authorDto = new AuthorDTO();
                    authorDto.Id = author.Id;
                    authorDto.Name = author.Name;
                    authorDto.BirthDate = author.BirthDate;
                    authorDto.ShortBio = author.ShortBio;
                    bookDto.Author.Add(authorDto);
                }

                bookList.Add(bookDto);
            }

            return bookList;

        }

        public int GetPublisherCount(Guid publisher_id)
        {
            var books = _context.Books.Where(x => x.PublisherId == publisher_id).ToList().Count();
            return books;
        }

    }
}