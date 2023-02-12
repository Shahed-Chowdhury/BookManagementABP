using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace BookManagementABP.Book_Authors
{
    public class Book_Author: AuditedAggregateRoot<Guid>
    {
        public Guid BookId { get; set; }
        public Guid AuthorId { get; set; }
    }
}
