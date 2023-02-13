import type { BookAuthorDTO, CreateUpdateBookAuthorDTO } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class BookAuthorServicesService {
  apiName = 'Default';
  
  create = (input: CreateUpdateBookAuthorDTO) =>
    this.restService.request<any, BookAuthorDTO>({
      method: 'POST',
      url: '/api/app/book-author-services',
      body: input,
    },
    { apiName: this.apiName });
  

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/book-author-services/${id}`,
    },
    { apiName: this.apiName });
  

  get = (id: string) =>
    this.restService.request<any, BookAuthorDTO>({
      method: 'GET',
      url: `/api/app/book-author-services/${id}`,
    },
    { apiName: this.apiName });
  

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<BookAuthorDTO>>({
      method: 'GET',
      url: '/api/app/book-author-services',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  update = (id: string, input: CreateUpdateBookAuthorDTO) =>
    this.restService.request<any, BookAuthorDTO>({
      method: 'PUT',
      url: `/api/app/book-author-services/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
