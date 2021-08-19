import{Book} from '../models/book';

import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../models/User';

@Injectable({
  providedIn: 'root',
})
export class UserService{

    constructor(private httpClient: HttpClient, private router: Router) {}

    login(email:string,password:string):Observable<any> {
 
      return this.httpClient.post<User>(
        'https://localhost:44368/User/auth',{
        "email":  email,
          "password": password}
      )
  }
  






    
}