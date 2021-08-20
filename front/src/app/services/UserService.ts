import{Book} from '../models/book';

import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../models/User';
import { Customer } from '../models/Customer';

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
  addUser(customer:Customer):Observable<any> {
 
    return this.httpClient.post<Customer>(
      'https://localhost:44368/User/addCustomer',{
        "firstName":customer.firstName,
        "lastName":customer.lastName,
      "email": customer.Email,
     "password":customer.Password,
     "billingAdress": {},
     "deliveryAdress": {},
     "birthDayDate": customer.BirthdayDate
  
    }
    )
}







    
}