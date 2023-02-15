import type { AuthorDTO, CreateUpdateAuthorDTO } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AuthorService {
  apiName = 'Default';
  

  create = (input: CreateUpdateAuthorDTO) =>
    this.restService.request<any, AuthorDTO>({
      method: 'POST',
      url: '/api/app/author',
      body: input,
    },
    { apiName: this.apiName });
  

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/author/${id}`,
    },
    { apiName: this.apiName });
  

  get = (id: string) =>
    this.restService.request<any, AuthorDTO>({
      method: 'GET',
      url: `/api/app/author/${id}`,
    },
    { apiName: this.apiName });
  

  getAuthorCountBeforeDeleteByAuthor_id = (author_id: string) =>
    this.restService.request<any, number>({
      method: 'GET',
      url: '/api/app/author/author-count-before-delete',
      params: { author_id },
    },
    { apiName: this.apiName });
  

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<AuthorDTO>>({
      method: 'GET',
      url: '/api/app/author',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  update = (id: string, input: CreateUpdateAuthorDTO) =>
    this.restService.request<any, AuthorDTO>({
      method: 'PUT',
      url: `/api/app/author/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
