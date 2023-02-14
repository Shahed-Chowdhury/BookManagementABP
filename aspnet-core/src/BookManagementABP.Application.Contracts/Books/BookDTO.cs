using BookManagementABP.Authors;
using BookManagementABP.Publishers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;


namespace BookManagementABP.Books
{
    public class BookDto: AuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public BookType Type { get; set; }

        public DateTime PublishDate { get; set; }

        public float Price { get; set; }

        [Required]
        public Guid PublisherId { get; set; }

        public PublisherDTO Publisher { get; set; }

        public ICollection<AuthorDTO> Author { get; set; }  

        public BookDto()
        {
            Author = new List<AuthorDTO>();
        }
    }
}
