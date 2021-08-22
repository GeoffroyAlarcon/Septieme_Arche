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
  private baseApi:string = "https://localhost:44368"
  private _isAuth:boolean = false;
    constructor(private httpClient: HttpClient, private router: Router) {}

    login(email:string,password:string):Observable<any> {
 
      return this.httpClient.post<User>(
       this.baseApi+"/User/auth",{
        "email":  email,
          "password": password}
      )
  }
  addUser(customer:Customer):Observable<any> {
 
    return this.httpClient.post<Customer>(
      this.baseApi+"/User/addCustomer",{
        "firstName":customer.firstName,
        "lastName":customer.lastName,
      "email": customer.Email,
     "password":customer.Password,
     "billingAdress": {},
     "deliveryAdress": {},
     "birthDayDate": customer.BirthdayDate
  
    });
}

isAuthenticated(){
  if( sessionStorage.getItem('token') == null ) return false;
else return true;
 }

}