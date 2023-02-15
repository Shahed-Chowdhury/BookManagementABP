import type { BookDto, CreateUpdateBookDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class BookService {
  apiName = 'Default';
  

  create = (input: CreateUpdateBookDto) =>
    this.restService.request<any, BookDto>({
      method: 'POST',
      url: '/api/app/book',
      body: input,
    },
    { apiName: this.apiName });
  

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/book/${id}`,
    },
    { apiName: this.apiName });
  

  get = (id: string) =>
    this.restService.request<any, BookDto>({
      method: 'GET',
      url: `/api/app/book/${id}`,
    },
    { apiName: this.apiName });
  

  getBookDetails = () =>
    this.restService.request<any, BookDto[]>({
      method: 'GET',
      url: '/api/app/book/book-details',
    },
    { apiName: this.apiName });
  

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<BookDto>>({
      method: 'GET',
      url: '/api/app/book',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  getPublisherCountByPublisher_id = (publisher_id: string) =>
    this.restService.request<any, number>({
      method: 'GET',
      url: '/api/app/book/publisher-count',
      params: { publisher_id },
    },
    { apiName: this.apiName });
  

  getWithPublisherById = (id: string) =>
    this.restService.request<any, BookDto>({
      method: 'GET',
      url: `/api/app/book/${id}/with-publisher`,
    },
    { apiName: this.apiName });
  

  update = (id: string, input: CreateUpdateBookDto) =>
    this.restService.request<any, BookDto>({
      method: 'PUT',
      url: `/api/app/book/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
