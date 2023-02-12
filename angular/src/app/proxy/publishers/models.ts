import type { AuditedEntityDto } from '@abp/ng.core';

export interface CreateUpdatePublisherDTO extends AuditedEntityDto<string> {
  name: string;
}

export interface PublisherDTO extends AuditedEntityDto<string> {
  id?: string;
  name: string;
}
