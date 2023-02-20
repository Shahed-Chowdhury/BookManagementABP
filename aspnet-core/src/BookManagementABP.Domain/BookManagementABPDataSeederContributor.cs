using BookManagementABP.Authors;
using BookManagementABP.Book_Authors;
using BookManagementABP.Books;
using BookManagementABP.Publishers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace BookManagementABP
{
    public class BookManagementABPDataSeederContributor: IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Book, Guid> _bookRepository;
        private readonly IRepository<Author, Guid> _authorRepository;
        private readonly IRepository<Publisher, Guid> _publisherRepository;
        private readonly IRepository<Book_Author, Guid> _bookAuthorRepository;

        public BookManagementABPDataSeederContributor(
            IRepository<Book, Guid> bookRepository,
            IRepository<Author, Guid> authorRepository,
            IRepository<Publisher, Guid> publisherRepository,
            IRepository<Book_Author, Guid> bookAuthorRepository
        )
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _publisherRepository = publisherRepository;
            _bookAuthorRepository = bookAuthorRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
           
           if (await _bookRepository.GetCountAsync() <= 0)
            {
                await _bookRepository.InsertAsync(
                    new Book
                    {
                        Name = "1984",
                        Type = BookType.Dystopia,
                        PublishDate = new DateTime(1949, 6, 8),
                        Price = 19.84f,
                        PublisherId = new Guid("19D007DE-2550-676E-A01B-3A098091EA43")
                    },
                    autoSave: true
                );

                await _bookRepository.InsertAsync(
                    new Book
                    {
                        Name = "The Hitchhiker's Guide to the Galaxy",
                        Type = BookType.ScienceFiction,
                        PublishDate = new DateTime(1995, 9, 27),
                        Price = 42.0f,
                        PublisherId = new Guid("398283AE-6191-2A98-EB56-3A098091EA77")
                    },
                    autoSave: true
                ); ;
            }

             if (await _authorRepository.GetCountAsync() <= 0)
             {
                 await _authorRepository.InsertAsync(
                     new Author
                     {
                         Name = "shahed",
                         BirthDate = DateTime.Now,
                         ShortBio = "qwertyuiop"
                     },
                     autoSave: true
                 );

                 await _authorRepository.InsertAsync(
                     new Author
                     {
                         Name = "shahed",
                         BirthDate = DateTime.Now,
                         ShortBio = "qwertyuiop"
                     },
                     autoSave: true
                 );
             } 

            if (await _publisherRepository.GetCountAsync() <= 0)
            {
                await _publisherRepository.InsertAsync(
                    new Publisher
                    {
                        Name = "Macmillan",
                        
                    },
                    autoSave: true
                );

                await _publisherRepository.InsertAsync(
                   new Publisher
                   {
                       Name = "Hachette Book Group",
                   },
                   autoSave: true
               );
            }

            
            if(await _bookAuthorRepository.GetCountAsync() <= 0)
            {
                await _bookAuthorRepository.InsertAsync(
                    new Book_Author
                    {
                        BookId = new Guid("06C7ECFF-0F16-78E8-EBAC-3A0980B1F33C"),
                        AuthorId = new Guid("E3843F9F-8E46-901E-B5EB-3A098091EA13")
                    },
                    autoSave: true
                );
                await _bookAuthorRepository.InsertAsync(
                   new Book_Author
                   {
                       BookId = new Guid("06C7ECFF-0F16-78E8-EBAC-3A0980B1F33C"),
                       AuthorId = new Guid("B6024B2C-CE23-ED02-14D6-3A098091EA36")
                   },
                   autoSave: true
               );
               
            } 


        }
    }
}
