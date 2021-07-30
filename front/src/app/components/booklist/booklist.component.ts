import { Component,OnInit,ViewChild } from '@angular/core';
import { Book } from 'src/app/models/book';
import { BookService } from 'src/app/services/BookService';

@Component({
  selector: 'app-booklist',
  templateUrl: './booklist.component.html',
  styleUrls: ['./booklist.component.scss']
})
export class BooklistComponent implements OnInit {
constructor(private _bookService:BookService){

}
authorsToString:string[] =[]
   books: Book[] = [];

  
  ngOnInit(): void { 
    this.displayGetAll();
  }

  displayGetAll() {
    this._bookService.getAllNewBook().subscribe((res) => {
      this.books = res;

});
}
}


