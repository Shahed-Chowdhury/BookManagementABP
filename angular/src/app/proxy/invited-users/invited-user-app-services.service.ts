import type { CreateUpdateInvitedUserDTO, InvitedUserDTO } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class InvitedUserAppServicesService {
  apiName = 'Default';
  

  create = (input: CreateUpdateInvitedUserDTO) =>
    this.restService.request<any, InvitedUserDTO>({
      method: 'POST',
      url: '/api/app/invited-user-app-services',
      body: input,
    },
    { apiName: this.apiName });
  

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/invited-user-app-services/${id}`,
    },
    { apiName: this.apiName });
  

  get = (id: string) =>
    this.restService.request<any, InvitedUserDTO>({
      method: 'GET',
      url: `/api/app/invited-user-app-services/${id}`,
    },
    { apiName: this.apiName });
  

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<InvitedUserDTO>>({
      method: 'GET',
      url: '/api/app/invited-user-app-services',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  update = (id: string, input: CreateUpdateInvitedUserDTO) =>
    this.restService.request<any, InvitedUserDTO>({
      method: 'PUT',
      url: `/api/app/invited-user-app-services/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
