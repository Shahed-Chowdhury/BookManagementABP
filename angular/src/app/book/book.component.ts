// import { BookType } from './../proxy/books/book-type.enum';
// import { BookService } from './../proxy/books/book.service';
// import { Component, OnInit } from '@angular/core';
// import { ListService } from '@abp/ng.core';

// @Component({
//   selector: 'app-book',
//   templateUrl: './book.component.html',
//   styleUrls: ['./book.component.scss'],
//   providers: [ListService]
// })
// export class BookComponent implements OnInit {
//   // ListService is the utility service of the abp framework that provides
//   // easy sorting, pagination and searching functionality
//   constructor(public readonly list: ListService, private bookService: BookService){}
//   bookItems: object[] = []
//   count: number = 0
//   bookType = BookType

//   ngOnInit(): void {
//     //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
//     //Add 'implements OnInit' to the class.
//     const bookStreamCreator = (query) => this.bookService.getList(query)
//     this.list.hookToQuery(bookStreamCreator).subscribe((res)=>{
//       this.bookItems = res.items
//       this.count = res.totalCount
//     })
//   }
// }

import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { BookService, BookDto, BookType } from '@proxy/books';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.scss'],
  providers: [ListService],
})
export class BookComponent implements OnInit {
  book = { items: [], totalCount: 0 } as PagedResultDto<BookDto>;
  isModalOpen = false; // add this line
  form: FormGroup; // add this line

  // add bookTypes as a list of BookType enum members
  bookTypes = BookType;

  constructor(public readonly list: ListService, private bookService: BookService, private fb: FormBuilder) {}

  ngOnInit() {
    const bookStreamCreator = (query) => this.bookService.getList(query);
    

    this.list.hookToQuery(bookStreamCreator).subscribe((response) => {
      this.book = response;
    });

    
  }

   createBook() {
    this.buildForm(); // add this line
    this.isModalOpen = true;
  }

  // add buildForm method
  buildForm() {
    this.form = this.fb.group({
      name: ['', Validators.required],
      type: [null, Validators.required],
      publishDate: [null, Validators.required],
      price: [null, Validators.required],
    });
  }

  // add save method
  save() {
    if (this.form.invalid) {
      return;
    }

    this.bookService.create(this.form.value).subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    });
  }

  
}
