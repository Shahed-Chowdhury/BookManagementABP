import { AuthorDTO } from './../proxy/authors/models';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { AuthorService } from './../proxy/authors/author.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';


@Component({
  selector: 'app-author',
  templateUrl: './author.component.html',
  styleUrls: ['./author.component.scss'],
  providers: [ListService]
})
export class AuthorComponent implements OnInit {
  
  author= {items: [], totalCount: 0} as PagedResultDto<AuthorDTO>
  isModalOpen = false;
  selectedAuthor = {} as AuthorDTO
  form: FormGroup

  constructor(public readonly list: ListService, private fb: FormBuilder, private authorService: AuthorService) {}
  
  ngOnInit(): void {
      const authorStreamCreator = query => this.authorService.getList(query)

      this.list.hookToQuery(authorStreamCreator).subscribe((response) => {
        this.author = response;
        console.log(this.author);
      });
  }

  createAuthor()
  {
    this.selectedAuthor = {}  as AuthorDTO
    this.buildForm()
    this.isModalOpen = true;
  }

  deleteAuthor(authorId: string)
  {
    alert(authorId)
  }

  editAuthor(authorId: string)
  {
    alert(authorId)
  }

  buildForm(){
    this.form = this.fb.group({
      name: [this.selectedAuthor.name || '', Validators.required],
      shortBio: [this.selectedAuthor.shortBio || '', Validators.required],
      dob: [this.selectedAuthor.birthDate ? new Date(this.selectedAuthor.birthDate) : null, Validators.required]
    })
  }

  save(){alert("Ok")}
}
