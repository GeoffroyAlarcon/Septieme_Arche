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

  messageSubject = new Subject<Book[]>();
  constructor(private httpClient: HttpClient, private router: Router) {}

  getAllNewBook():Observable<Array<Book>> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    })
    return this.httpClient.get<Array<Book>>(
      'https://localhost:44368/api/book/findAllBook',{headers:headers}
    );
  }

  getBookByISBN(isbn:string):Observable<Array<Book>> {

    return this.httpClient.get<Array<Book>>(
      'https://localhost:44368/api/book/findBookByISBN?ISBN ='+isbn
      );
  }




  getBooksByAuthorOrTitle(search:string):Observable<Array<Book>> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: `Bearer ${JSON.parse(sessionStorage.getItem("token") ??'')}`,
        });
    return this.httpClient.get<Array<Book>>(
      'http://localhost:3000/api/message/getAllMessage'+"?seach="+search,
    );
  }

}