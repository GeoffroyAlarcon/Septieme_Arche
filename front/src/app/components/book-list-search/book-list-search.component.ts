import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Book } from 'src/app/models/book';
import { BookService } from 'src/app/services/BookService';

@Component({
  selector: 'app-book-list-search',
  templateUrl: './book-list-search.component.html',
  styleUrls: ['./book-list-search.component.scss']
})
export class BookListSearchComponent implements OnInit {
 _books:Book[] = []

  constructor(private _bookService:BookService,private route: ActivatedRoute ) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe((value) => {
    let search= value.get("search")??"".toString();
      this.getallResultBySearch(search);
    });
 
  }

getallResultBySearch(_search:string){

 this._bookService.getBooksByAuthorOrTitle(_search).subscribe((res)=>{
this._books= res;
})
}
}