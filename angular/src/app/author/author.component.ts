import { AuthorDTO } from './../proxy/authors/models';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { AuthorService } from './../proxy/authors/author.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';

@Component({
  selector: 'app-author',
  templateUrl: './author.component.html',
  styleUrls: ['./author.component.scss'],
  providers: [ListService, { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter } ]
})

export class AuthorComponent implements OnInit {
  
  author= {items: [], totalCount: 0} as PagedResultDto<AuthorDTO>
  isModalOpen = false;
  selectedAuthor = {} as AuthorDTO
  form: FormGroup

  constructor(public readonly list: ListService,
    private fb: FormBuilder,
    private authorService: AuthorService,
    private confirmation: ConfirmationService) {}
  
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
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.authorService.delete(authorId).subscribe(() => this.list.get());
      }
    });
  }

  editAuthor(authorId: string)
  {
    this.authorService.get(authorId).subscribe((author)=>{
      this.selectedAuthor = author
      this.buildForm();
      this.isModalOpen = true
    })
  }

  buildForm(){
    this.form = this.fb.group({
      name: [this.selectedAuthor.name || '', Validators.required],
      shortBio: [this.selectedAuthor.shortBio || '', Validators.required],
      birthDate: [this.selectedAuthor.birthDate ? new Date(this.selectedAuthor.birthDate) : null, Validators.required]
    })
  }

  save(){
    if(this.form.invalid){
      return;
    }

    const request = this.selectedAuthor.id
    ? this.authorService.update(this.selectedAuthor.id, this.form.value)
    : this.authorService.create(this.form.value);

    // console.log(this.form.value);

    request.subscribe(()=>{
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    })
  }
}
