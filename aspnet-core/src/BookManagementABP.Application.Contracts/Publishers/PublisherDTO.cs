﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace BookManagementABP.Publishers
{
    public class PublisherDTO: AuditedEntityDto<Guid>
    {
        [Required]
        public string Name { get; set; }
    }
}
