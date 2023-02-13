using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace BookManagementABP.BookAuthors
{
    public class CreateUpdateBookAuthorDTO: AuditedEntityDto<Guid>
    {
        public Guid BookId { get; set; }
        public Guid AuthorId { get; set; }
    }
}
