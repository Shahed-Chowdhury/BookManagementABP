import type { AuditedEntityDto } from '@abp/ng.core';
import type { AuditedAggregateRoot } from '../volo/abp/domain/entities/auditing/models';

export interface CreateUpdateInvitedUserDTO {
  firstName: string;
  lastName: string;
  email: string;
  role: string;
  phoneNumber: string;
}

export interface InvitedUserDTO extends AuditedEntityDto<string> {
  firstName?: string;
  lastName?: string;
  email?: string;
  role?: string;
  phoneNumber?: string;
}

export interface Invited_User extends AuditedAggregateRoot<string> {
  firstName?: string;
  lastName?: string;
  email?: string;
  role?: string;
  phoneNumber?: string;
}
