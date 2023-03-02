import type { AggregateRoot, Entity } from '../domain/entities/models';

export interface IdentityClaim extends Entity<string> {
  tenantId?: string;
  claimType?: string;
  claimValue?: string;
}

export interface IdentityRole extends AggregateRoot<string> {
  tenantId?: string;
  name?: string;
  normalizedName?: string;
  claims: IdentityRoleClaim[];
  isDefault: boolean;
  isStatic: boolean;
  isPublic: boolean;
}

export interface IdentityRoleClaim extends IdentityClaim {
  roleId?: string;
}
