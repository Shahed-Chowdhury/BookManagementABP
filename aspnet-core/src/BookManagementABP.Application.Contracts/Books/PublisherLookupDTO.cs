using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace BookManagementABP.Books
{
    public class PublisherLookupDTO: EntityDto<Guid>
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        
    }
}
