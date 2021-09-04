import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../models/User';
import { Customer } from '../models/Customer';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root',
})
export class UserService{
  private baseApi:string = "https://localhost:44368"
  private _isAuth:boolean = false;
    constructor(private httpClient: HttpClient, private router: Router, private cookieService:CookieService) {}

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
     "deliveryAdress": {
      "country": customer.DeliveryAdress.country,
      "city": customer.DeliveryAdress.city,
      "zipCode": customer.DeliveryAdress.zipCode,
      "street": customer.DeliveryAdress.street,
      "stretNumber": customer.DeliveryAdress.streetNumber,
      "poneNumber": customer.DeliveryAdress.phoneNumber,
      "digitalcodeNumber": customer.DeliveryAdress.digitalCodeNumber,
      "typeBulding":  customer.DeliveryAdress.typeBuilding

     },
     "billingAdress": customer.DeliveryAdress,
     "birthDayDate": customer.BirthdayDate
  
    });
}

isAuthenticated(){
  if(   this.cookieService.get('user')  == null ) return false;
else return true;
 }

}