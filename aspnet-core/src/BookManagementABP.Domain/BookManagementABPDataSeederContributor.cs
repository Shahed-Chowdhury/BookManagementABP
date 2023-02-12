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
                        PublisherId = new Guid("7C094DCB-DB1B-170B-6E57-3A09569409BF")
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
                        PublisherId = new Guid("4FA7B546-F0C9-D18F-627B-3A0956940B20")
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
                        BookId = new Guid("78A5006A-09C8-D63E-C047-3A095698E093"),
                        AuthorId = new Guid("6493C524-AA60-F636-9426-3A09569A4EF2")
                    },
                    autoSave: true
                );
                await _bookAuthorRepository.InsertAsync(
                   new Book_Author
                   {
                       BookId = new Guid("78A5006A-09C8-D63E-C047-3A095698E093"),
                       AuthorId = new Guid("0DFAD0B9-B7D9-6B6F-3402-3A09569A5094")
                   },
                   autoSave: true
               );
               await _bookAuthorRepository.InsertAsync(
                   new Book_Author
                   {
                       BookId = new Guid("78A5006A-09C8-D63E-C047-3A095698E093"),
                       AuthorId = new Guid("6493C524-AA60-F636-9426-3A09569A4EF2")
                   },
                   autoSave: true
               );
            }


        }
    }
}
