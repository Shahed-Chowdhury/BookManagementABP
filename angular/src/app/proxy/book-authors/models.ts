import type { AuditedEntityDto } from '@abp/ng.core';

export interface BookAuthorDTO extends AuditedEntityDto<string> {
  bookId?: string;
  authorId?: string;
}

export interface CreateUpdateBookAuthorDTO extends AuditedEntityDto<string> {
  bookId?: string;
  authorId?: string;
}
