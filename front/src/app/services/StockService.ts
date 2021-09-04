import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Customer } from "../models/Customer";
import { User } from "../models/User";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CartLine } from "../models/cartline";
@Injectable({
    providedIn: 'root',
  })
  export class StockService{
    private baseApi:string = "https://localhost:44368"
constructor(private httpClient:HttpClient){

}

    public  StockIsValid( customer:Customer, cart:CartLine[]):Observable<any> {
        return this.httpClient.post<any>(
            this.baseApi+"/User/addCustomer",{
"cart":cart,
            "email": customer.Email,
           "password":customer.Password
    })
}
}
  