import type { CreateUpdatePublisherDTO, PublisherDTO } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class PublisherService {
  apiName = 'Default';
  

  create = (input: CreateUpdatePublisherDTO) =>
    this.restService.request<any, PublisherDTO>({
      method: 'POST',
      url: '/api/app/publisher',
      body: input,
    },
    { apiName: this.apiName });
  

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/publisher/${id}`,
    },
    { apiName: this.apiName });
  

  get = (id: string) =>
    this.restService.request<any, PublisherDTO>({
      method: 'GET',
      url: `/api/app/publisher/${id}`,
    },
    { apiName: this.apiName });
  

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<PublisherDTO>>({
      method: 'GET',
      url: '/api/app/publisher',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  update = (id: string, input: CreateUpdatePublisherDTO) =>
    this.restService.request<any, PublisherDTO>({
      method: 'PUT',
      url: `/api/app/publisher/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
