import { Component, OnInit } from '@angular/core';
import { Book } from 'src/app/models/book';
import { BookService } from 'src/app/services/BookService';

@Component({
  selector: 'app-book-list-search',
  templateUrl: './book-list-search.component.html',
  styleUrls: ['./book-list-search.component.scss']
})
export class BookListSearchComponent implements OnInit {
 _books:Book[] = []
  constructor(private _bookService:BookService ) { }

  ngOnInit(): void {
    this.getallResultBySearch();
  }

getallResultBySearch(){

this._bookService.getBooksByAuthorOrTitle('le').subscribe((res)=>{
this._books= res;
})
}
}
