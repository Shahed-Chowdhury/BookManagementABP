import type { AuditedEntityDto } from '@abp/ng.core';

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
