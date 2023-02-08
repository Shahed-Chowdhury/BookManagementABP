using BookManagementABP.Authors;
using BookManagementABP.Books;
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

        public BookManagementABPDataSeederContributor(IRepository<Book, Guid> bookRepository, IRepository<Author, Guid> authorRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
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
                        Price = 19.84f
                    },
                    autoSave: true
                );

                await _bookRepository.InsertAsync(
                    new Book
                    {
                        Name = "The Hitchhiker's Guide to the Galaxy",
                        Type = BookType.ScienceFiction,
                        PublishDate = new DateTime(1995, 9, 27),
                        Price = 42.0f
                    },
                    autoSave: true
                );
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
        }
    }
}
