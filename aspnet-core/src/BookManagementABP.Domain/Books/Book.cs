using BookManagementABP.Publishers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using BookManagementABP.Book_Authors;

namespace BookManagementABP.Books
{
    public class Book: AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }

        public BookType Type { get; set; }

        public DateTime PublishDate { get; set; }

        public float Price { get; set; }

        //[Required, ForeignKey("Publisher")]
        public Guid PublisherId { get; set; } 
        //public Publisher Publisher { get; set; }

        //public ICollection<Book_Author> book_Authors { get; set; }

        /*public Book()
        {
            book_Authors = new List<Book_Author>();
        }*/
    }
}
