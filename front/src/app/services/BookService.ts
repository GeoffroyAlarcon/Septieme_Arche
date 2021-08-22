import{Book} from '../models/book';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UserService } from './UserService';
@Injectable({
  providedIn: 'root',
})
export class BookService {
  private books: Book[] = [];
private baseApi:string = "https://localhost:44368"
  messageSubject = new Subject<Book[]>();
  constructor(private httpClient: HttpClient, private router: Router) {}

  getAllNewBook():Observable<Array<Book>> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    })
    return this.httpClient.get<Array<Book>>(
      this.baseApi+'/api/book/findAllBook',{headers:headers}
    );
  }

  getBookByISBN(isbn:string):Observable<Book> {

    return this.httpClient.get<Book>(
      this.baseApi+"/api/book/findBookByISBN/"+isbn
      );
  }


  getBooksByAuthorOrTitle(search:string):Observable<Array<Book>> {

    return this.httpClient.get<Array<Book>>(
      this.baseApi+"/api/book/findByTitleOrAuthor/"+search
    );
  }

}