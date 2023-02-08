import type { AuditedEntityDto } from '@abp/ng.core';

export interface AuthorDTO extends AuditedEntityDto<string> {
  name?: string;
  birthDate?: string;
  shortBio?: string;
}

export interface CreateUpdateAuthorDTO extends AuditedEntityDto<string> {
  name: string;
  birthDate: string;
  shortBio: string;
}
