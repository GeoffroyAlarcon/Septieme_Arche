import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { User } from "../models/User";

@Injectable({
    providedIn: 'root',
  })
  export class OrderService{
    private baseApi:string = "https://localhost:44368"
    constructor(private httpClient:HttpClient){

    }
validateOrder(user:User):Observable<any>{
 return this.httpClient.post<any> (  this.baseApi+ "/api/Order/stockManagerAndValidateOrder",user);
}
}