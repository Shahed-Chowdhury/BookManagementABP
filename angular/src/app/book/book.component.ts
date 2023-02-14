import { BookAuthorDTO, CreateUpdateBookAuthorDTO } from './../proxy/book-authors/models';
import { BookAuthorServicesService } from './../proxy/book-authors/book-author-services.service';
import { clearPage } from '@abp/ng.core/testing';
import { PublisherService } from './../proxy/publishers/publisher.service';
import { AuthorService } from './../proxy/authors/author.service';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { BookService, BookDto, bookTypeOptions } from '@proxy/books';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
// added this line
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { AuthorDTO } from '@proxy/authors';
import { PublisherDTO } from '@proxy/publishers';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.scss'],
  providers: [ListService, { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter } ],
})
export class BookComponent implements OnInit {
  book = { items: [], totalCount: 0 } as PagedResultDto<BookDto>;
  isModalOpen = false; // add this line
  form: FormGroup; // add this line
  selectedBook = {} as BookDto;
  authorList = {items: [], totalCount: 0} as PagedResultDto<AuthorDTO>;
  publisherList = [];
  selectedPublisher:any;
  selectedAuthors:any;
  bookId: string
  preSelectedAuthors: any

  // add bookTypes as a list of BookType enum members
  bookTypes = bookTypeOptions;

  constructor(
    public readonly list: ListService,
    public readonly list2: ListService,
    public readonly list3: ListService,
    private authorService: AuthorService,
    private publisherService: PublisherService,
    private bookService: BookService,
    private bookAuthorService: BookAuthorServicesService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService) {}

  ngOnInit() {
    const authorStreamCreator = (query) => this.authorService.getList(query);
    const publisherStreamCreator = (query) => this.publisherService.getList(query);
    
    this.getList()

    this.list2.hookToQuery(authorStreamCreator).subscribe((response)=>{
      this.authorList = response;
    })

    this.list3.hookToQuery(publisherStreamCreator).subscribe((response)=>{
      var list = response
      this.publisherList = list.items
    })
  }

  getList(){
    this.bookService.getBookDetails().subscribe(res => {
      var items = res;
      if(items){
        this.book.items = items
        this.book.totalCount = items.length
      }else{
        this.book.items = []
      }
    })
  }

  createBook() {
    this.selectedPublisher = null
    this.selectedBook = {} as BookDto;
    this.selectedAuthors = []
    this.buildForm(); // add this line
    this.isModalOpen = true;
  }

  // Add editBook method
  editBook(id: string) {
    this.bookService.getWithPublisherById(id).subscribe(book => {
      this.selectedBook = book;
      this.selectedPublisher = this.selectedBook.publisher
      this.selectedAuthors = this.selectedBook.author 
      this.preSelectedAuthors = this.selectedAuthors   
      this.buildForm();
      this.isModalOpen = true;
    })
  }

  // add buildForm method
  buildForm() {
    this.form = this.fb.group({
      name: [this.selectedBook.name || '', Validators.required],
      type: [this.selectedBook.type || null, Validators.required],
      publishDate: [
        this.selectedBook.publishDate ? new Date(this.selectedBook.publishDate) : new Date(),
        Validators.required,
      ],
      price: [this.selectedBook.price || null, Validators.required],
    });
  }

  // add save method
  async save() {
    try{

      if (this.form.invalid) { return }
  
      const bookObj = this.form.value
      
      bookObj.publisherId = this.selectedPublisher.id
  
      const request = this.selectedBook.id
      ? await this.bookService.update(this.selectedBook.id, bookObj).toPromise()
      : await this.bookService.create(bookObj).toPromise();

      this.bookId = request.id

      if(!this.selectedBook.id){
        this.selectedAuthors.forEach(author => {
          var obj = {} as CreateUpdateBookAuthorDTO;
          obj = { authorId: author.id, bookId: this.bookId }
          this.bookAuthorService.create(obj).subscribe(res => {})
        })
      }

      // .................................Fix it by tomorrow.................................
      // add and remove bookAuthor
      // ..................................... End ..........................................


      
      
      this.isModalOpen = false;
      this.form.reset();
      this.getList();
  
    }catch(exception){ console.error(exception); }

  }

  // Add a delete method
  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.bookService.delete(id).subscribe((res) => {console.log(res); this.getList()});
      }
    });
  }

  selectedAuthorsFn(event){
    var authors = event
    this.selectedAuthors = authors;
    console.log("Selected authors", this.selectedAuthors);
    console.log("Preselected authors", this.preSelectedAuthors);
  }

  selectedPublisherFn(event){
    this.selectedPublisher = event
  }
}
