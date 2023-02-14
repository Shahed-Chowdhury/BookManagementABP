import type { AuditedEntityDto } from '@abp/ng.core';
import type { BookType } from './book-type.enum';
import type { PublisherDTO } from '../publishers/models';
import type { AuthorDTO } from '../authors/models';

export interface BookDto extends AuditedEntityDto<string> {
  name?: string;
  type: BookType;
  publishDate?: string;
  price: number;
  publisherId: string;
  publisher: PublisherDTO;
  author: AuthorDTO[];
}

export interface CreateUpdateBookDto {
  name: string;
  type: BookType;
  publishDate: string;
  price: number;
  publisherId: string;
}
