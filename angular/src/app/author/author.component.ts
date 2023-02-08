import { AuthorDTO } from './../proxy/authors/models';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { AuthorService } from './../proxy/authors/author.service';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-author',
  templateUrl: './author.component.html',
  styleUrls: ['./author.component.scss'],
  providers: [ListService]
})
export class AuthorComponent implements OnInit {
  
  author= {items: [], totalCount: 0} as PagedResultDto<AuthorDTO>

  constructor(public readonly list: ListService, private authorService: AuthorService) {}
  
  ngOnInit(): void {
      const authorStreamCreator = query => this.authorService.getList(query)

      this.list.hookToQuery(authorStreamCreator).subscribe((response) => {
        this.author = response;
        console.log(this.author);
      });
  }
}
